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
    public class BeerMugSpec : SingleStateResourceSpec<BeerMug, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("BeerMug({Id})");

        public override IResourceStateSpec<BeerMug, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<BeerMug, int>
                    {
                        Operations = new StateSpecOperationsSource<BeerMug, int>
                        {
                            Post = ServiceOperations.Update
                        }
                    };
            }
        }
        protected override IEnumerable<ResourceLinkTemplate<BeerMug>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id);
        }
    }
}