using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IQ.Platform.Framework.Logging;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Formatting;
using IQ.Platform.Framework.WebApi.Infrastructure;
using IQ.Platform.Framework.WebApi.Security;
using IQ.Platform.Framework.WebApi.Services.Installers;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQMetrix.Beertap.ApiServices;
using IQMetrix.Beertap.ApiServices.Security;
using IQMetrix.Beertap.Data;
using IQMetrix.Beertap.Data.Providers;
using IQMetrix.Beertap.Documentation.Installers;
using IQMetrix.Beertap.Model;
using IQMetrix.Beertap.WebApiInfra.Handlers;
using IQMetrix.Beertap.WebApiInfra.Installers;

namespace IQMetrix.Beertap.WebApiInfra
{
    public class DefaultApiContainer : ApiContainer
    {

        readonly IDomainServiceResolver _domainServiceResolver;
        readonly Assembly _apiDomainServicesAssembly = typeof(IOfficeApiService).Assembly;
        readonly Assembly _resourceMappersAssembly = typeof(OfficeApiService).Assembly;
        readonly Assembly _resourceSpecsAssembly;
        readonly Assembly _resourceStateProvidersAssembly;


        public DefaultApiContainer(HttpConfiguration configuration, IWindsorContainer windsorContainer, 
            Assembly resourceSpecsAssembly,
            Assembly resourceStateProvidersAssembly,
            IDomainServiceResolver domainServiceResolver = null)
            : base(configuration, windsorContainer)
        {
            _domainServiceResolver = domainServiceResolver;
            _resourceSpecsAssembly = resourceSpecsAssembly;
            _resourceStateProvidersAssembly = resourceStateProvidersAssembly;
        }

        public override Assembly ResourceAssembly { get { return typeof(LinkRelations).Assembly; } }
        protected override Assembly ResourceSpecsAssembly { get { return _resourceSpecsAssembly; } }
        protected override Assembly ResourceStateProvidersAssembly { get { return _resourceStateProvidersAssembly; } }
        protected override Assembly ApiAppServicesAssembly { get { return typeof(OfficeApiService).Assembly; } }


        protected override void RegisterCustomDependencies()
        {

            _windsorContainer
                .Install(new IWindsorInstaller[]
                         {
                             new DomainServicesInstaller(_domainServiceResolver, _apiDomainServicesAssembly, _apiDomainServicesAssembly),
                             new ResourceMapperInstaller(_resourceMappersAssembly),
                             new HelpControllerInstaller(),
							 //TODO: It requires the "IQ.Auth.OAuth2.ProtectedResource.ZeroMQ.ZeroMQServerAddress" app setting. The AlwaysAuthenticateRequestAuthenticator has to be commented out as well
							 new OAuthProtectedResourceComponentsInstaller(),
                             new SecurityMessageHandlersInstaller(Assembly.GetExecutingAssembly()),
                         })
                         .InstallLogging();

            //_windsorContainer.Register(Component.For<IApiUserFactory<ApiUser<UserAuthData>>>().ImplementedBy<DefaultApiUserFactory<UserAuthData>>());
            _windsorContainer.Register(Component.For<IRequestAuthenticator<UserAuthData>>().ImplementedBy<DefaultSsoBasedRequestAuthenticator>());
            _windsorContainer.Register(Component.For(typeof(IBeertapRepository<>)).ImplementedBy(typeof(BeertapRepository<>)));
            _windsorContainer.Register(Component.For<IOfficeProvider>().ImplementedBy<OfficeProvider>());
            _windsorContainer.Register(Component.For<IKegProvider>().ImplementedBy<KegProvider>());
            _windsorContainer.Register(Component.For<IDataContext>().ImplementedBy<BeertapContext>());

        }

        protected override IEnumerable<DelegatingHandler> ResolveMessageHandlersInternal()
        {

            yield return ResolveTraceContextHandler();
            yield return ResolveAuthenticationMessageHandler();
            yield return ResolveSecurityContextMessageHandler();

        }

        DelegatingHandler ResolveAuthenticationMessageHandler()
        {
            return
                //TODO: could it be registered entirely with .IsDefault() and if necessary, overrode in tests by FakeRequestAuthenticator?
                new DefaultAuthenticationMessageHandler<UserAuthData>(
                    _windsorContainer.Resolve<IRequestAuthenticator<UserAuthData>>());
        }

        DelegatingHandler ResolveSecurityContextMessageHandler()
        {
            return
                _windsorContainer.Resolve<ApiSecurityContextProvidingHandler<BeertapApiUser, NullUserContext>>();
        }

        TraceContextHandler ResolveTraceContextHandler()
        {
            return new TraceContextHandler(_configuration.GetHypermediaConfiguration());
        }

        protected override IEnumerable<MediaTypeFormatter> ResolveMediaTypeFormattersInternal()
        {
            yield return HalJsonFormatter.Create();
            yield return PlainJsonFormatter.Create();
        }


    }
}
