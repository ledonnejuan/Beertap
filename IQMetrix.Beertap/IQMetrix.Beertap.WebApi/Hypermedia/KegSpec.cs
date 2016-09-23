using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.WebApi.Hypermedia
{
    public class KegSpec : ResourceSpec<Keg, KegState, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Kegs({Id})");

        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId, c => c.Id);
        }
        protected override IEnumerable<IResourceStateSpec<Keg, KegState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.New)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs.GetBeer, GetBeerSpec.Uri, c => c.OfficeId, c => c.Id)
                },
                Operations =
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.GoinDown)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs.GetBeer, GetBeerSpec.Uri, c => c.OfficeId, c => c.Id)
                },
                Operations =
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.AlmostEmpty)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs.ReplaceKeg, ReplaceKegSpec.Uri, c => c.OfficeId, c => c.Id),
                    CreateLinkTemplate(LinkRelations.Kegs.GetBeer, GetBeerSpec.Uri, c => c.OfficeId, c => c.Id)
                },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.SheIsDryMate)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Kegs.ReplaceKeg, ReplaceKegSpec.Uri, c => c.OfficeId, c => c.Id)
                },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete
                }
            };
        }
    }
}