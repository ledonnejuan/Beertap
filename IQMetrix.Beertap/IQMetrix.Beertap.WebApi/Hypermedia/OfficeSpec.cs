using System.Collections.Generic;
using IQMetrix.Beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IQMetrix.Beertap.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }

        protected override IEnumerable<ResourceLinkTemplate<Office>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id);
        }
        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<Office, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Keg , ResourceUriTemplate.Create("Offices({OfficeId})/Kegs"), r => r.Id),
                           CreateLinkTemplate(LinkRelations.Office , ResourceUriTemplate.Create("Offices"))
                      },
                      Operations = new StateSpecOperationsSource<Office, int>
                      {
                          Get = ServiceOperations.Get,
                          InitialPost = ServiceOperations.Create,
                          Post = ServiceOperations.Update,
                          Put = ServiceOperations.Update,
                          Delete = ServiceOperations.Delete
                      },
                  };
            }
        }

    }
}