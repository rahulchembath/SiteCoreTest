using Sitecore.Data;

namespace Claro.Foundation.Settings
{
    public struct Templates
    {
        public struct ItemPathSettings
        {
            public static readonly ID ID = new ID("{CDF85460-6419-4403-ABD6-88A644505B22}");
            public struct Fields
            {
                public static readonly ID QuoteUrl = new ID("{203F37CA-FD9A-4FC1-BB6A-75273702CB8B}");
            }
        }
        public struct SearchSettings
        {
            public static readonly ID ID = new ID("{68754EC2-BE46-48A8-8AD2-C9AE87597C0C}");
            public struct Fields
            {
                public static readonly ID SearchPageUrl = new ID("{0DA7D4D4-526E-4103-93B6-B360CD7F95D8}");
            }
        }
    }
}