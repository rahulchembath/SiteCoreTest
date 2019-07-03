using Sitecore.Data;

namespace Claro.Foundation.Indexing
{
    public struct Constants
    {
        public struct IndexFields
        {
            public const string BlogCategories = "blog_categories";
            public const string BlogCreatedDate = "blog_created_tdt";
            public const string BlogCategories_Text = "blog_categories_text";
            public const string BlogAuthor = "blog_author_t";
            public const string BlogTitle = "blog_title_t";
            public const string BlogIntro = "blog_intro_t";
            public const string BlogDescription = "blog_description_t";
        }
        public struct Blog
        {
            public struct Fields
            {
                public static readonly ID BlogCategoryField = new ID("{EE125AA7-7E10-4DB9-B36F-259C5C08EFF7}");
                public static readonly ID BlogAuthorField = new ID("{C7A807AF-F4C0-4294-8CE9-29551C8D7F0D}");
            }
        }
        public struct Category
        {
            public struct Fields
            {
                public static readonly ID CategoryName = new ID("{01C53B2A-B6EC-45AF-A29E-1F791DC9641D}");
            }
        }
        public struct Author
        {
            public struct Fields
            {
                public static readonly ID FirstName = new ID("{CDB2BF63-B8D3-4B2A-8E09-B53F63D3F1B0}");
                public static readonly ID LastName = new ID("{9FDDE5C4-AA51-4FBB-BCA2-6F2B715A30CB}");
            }
        }
        public static readonly ID ArticlePage = new ID("{3BEC49FB-DF36-4551-86CF-D3C04E58C506}");

        public const string Claro_Blog_Index = "claro_blog_index";
    }
}