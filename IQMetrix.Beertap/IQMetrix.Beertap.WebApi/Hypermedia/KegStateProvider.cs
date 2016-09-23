using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.WebApi.Hypermedia
{
    public class KegStateProvider : ResourceStateProviderBase<Keg, KegState>
    {
        public override KegState GetFor(Keg resource)
        {
            return resource.KegState;
        }

        protected override IDictionary<KegState, IEnumerable<KegState>> GetTransitions()
        {
            return new Dictionary<KegState, IEnumerable<KegState>>
            {
                {
                    KegState.New, new[]
                    {
                        KegState.GoinDown,
                        KegState.AlmostEmpty,
                        KegState.SheIsDryMate
                    }
                },
                {
                    KegState.GoinDown, new[]
                    {
                        KegState.New,
                        KegState.AlmostEmpty,
                        KegState.SheIsDryMate
                    }
                },
                {
                    KegState.AlmostEmpty, new[]
                    {
                        KegState.New,
                        KegState.GoinDown,
                        KegState.SheIsDryMate
                    }
                },
                {
                    KegState.SheIsDryMate, new[]
                    {
                        KegState.New,
                    }
                }
            };
        }

        public override IEnumerable<KegState> All => EnumEx.GetValuesFor<KegState>();
    }
}