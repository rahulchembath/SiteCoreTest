using Sitecore.Data;

namespace Claro.Feature.Social
{
    public struct Templates
    {
        public struct SocialFollow
        {
            public static readonly ID ID = new ID("{1CF61C16-8297-43FD-A0BD-2AC1136C9088}");
            public struct Fields
            {
                public static readonly ID SocialMediaName = new ID("{3EF2AB76-FE62-4051-824D-5B3E0CB30AF2}");
                public static readonly ID SocialMediaUrl = new ID("{674DBACF-D342-436B-BE6A-E0DF2A489BFF}");
                public static readonly ID DisplayOrder = new ID("{3A5686AF-440A-4280-A612-4C50EEDDE164}");
            }
        }
        public struct SocialFollowFolder
        {
            public static readonly ID ID = new ID("{4C456CE1-5DA9-43CB-8217-28F48C55B05D}");
        }
    }
}