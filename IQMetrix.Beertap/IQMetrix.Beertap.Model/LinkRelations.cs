namespace IQMetrix.Beertap.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string Office = "iq:Office";
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string Keg = "iq:Keg";
        /// <summary>
        /// 
        /// </summary>
        public static class Kegs
        {
            /// <summary>
            /// 
            /// </summary>
            public const string ReplaceKeg = "iq:ReplaceKeg";
            /// <summary>
            /// 
            /// </summary>
            public const string GetBeer = "iq:GetBeer";
        }

    }
}
