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
    public class GetBeerSpec : SingleStateResourceSpec<GetBeer, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Kegs({Id})/GetBeer");

        public override IResourceStateSpec<GetBeer, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<GetBeer, int>
                    {
                        Operations = new StateSpecOperationsSource<GetBeer, int>
                        {
                            Post = ServiceOperations.Update
                        }
                    };
            }
        }
        protected override IEnumerable<ResourceLinkTemplate<GetBeer>> Links()
        {
            yield return
                CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId,
                    c => c.Id);
        }
    }
}