using Sitecore.Data;

namespace Claro.Feature.Blog
{
    public struct Templates
    {
        public struct Author
        {
            public static readonly ID ID = new ID("{D4F7A392-01B1-4DFB-A136-A68150662F2B}");
            public struct Fields
            {
                public static readonly ID FirstName = new ID("{CDB2BF63-B8D3-4B2A-8E09-B53F63D3F1B0}");
                public static readonly ID LastName = new ID("{9FDDE5C4-AA51-4FBB-BCA2-6F2B715A30CB}");
                public static readonly ID Summary = new ID("{87F74BD8-3D19-43A7-8791-F9F50BA0C7AA}");
                public static readonly ID Image = new ID("{7A4CDCD3-3E51-4388-8EF4-EBFB7B67289F}");
                public static readonly ID LinkedinUrl = new ID("{6E8B6309-3B7D-49E1-AEE6-CCEF6876E921}");
                public static readonly ID TwitterUrl = new ID("{BE8A7B82-2C23-4648-98FB-F201058B8156}");
            }
        }
        public struct Category
        {
            public static readonly ID ID = new ID("{3ECDE112-5A06-4FD5-828C-3E829B8F5A14}");
            public struct Fields
            {
                public static readonly ID Title = new ID("{01C53B2A-B6EC-45AF-A29E-1F791DC9641D}");
                public static readonly ID Url = new ID("{0B216AC4-BD7C-4468-8BC6-F89C8E9DF7C0}");
                public static readonly ID DisplayOrder = new ID("{B6E6601D-4236-460A-BA0C-7815A04660FB}");
            }
        }
        public struct Blog
        {
            public static readonly ID ID = new ID("{245B1A8E-4393-46B0-8A26-1FFC13275955}");
            public struct Fields
            {
                public static readonly ID Title = new ID("{B13291FC-BE7F-4344-8318-82A83F0AF21C}");
                public static readonly ID Intro = new ID("{0F89F034-960D-4F0D-9EDA-3570D064B592}");
                public static readonly ID Description = new ID("{3761D754-0C37-4864-95EC-7658DD089B6B}");
                public static readonly ID FeatureImage = new ID("{3835A22F-8E14-4712-9873-30667EC7FD7A}");
                public static readonly ID HeroImage = new ID("{3CB1FFD6-C4E2-43F7-A4AA-97356B6C30DC}");
                public static readonly ID LandingBoxImage = new ID("{07585CB4-F907-4BD6-8AA1-32AB83EEACFD}");
                public static readonly ID BlogCreated = new ID("{F82A2A6C-CF30-478F-9676-46170E5C7746}");
                public const string BlogAuthorFieldName = "Blog Author";
                public const string BlogCategoryFieldName = "Blog Category";
                public const string SocialShare = "Blog Social Share";
            }
        }
        public struct Quote
        {
            public static readonly ID ID = new ID("{4935E05B-DBA7-461B-B9D2-05650A50700C}");
            public struct Fields
            {
                public static readonly ID Summary = new ID("{0A66AC07-AE60-4234-9876-BB0C76843F45}");
                public const string AuthorFieldName = "Author";
            }
        }
        public struct QuoteFolder
        {
            public static readonly ID ID = new ID("{82A5F383-1CF8-48B2-A19A-4C9765BA64BC}");
        }
        public struct CategoryFolder
        {
            public static readonly ID ID = new ID("{194AC088-0FC9-4120-B644-DB3A8EB61EAB}");
        }
        public struct Comment
        {
            public static readonly ID ID = new ID("{7BF5654A-D501-406A-9F04-73DF21F29F2B}");
            public struct Fields
            {
                public static readonly ID FirstName = new ID("{13CC1FD3-4380-48EB-BFF8-CEDCB3559F62}");
                public static readonly ID LastName = new ID("{8704636F-B7A4-4A54-81C9-0ACD6F773ED1}");
                public static readonly ID Email = new ID("{FA019E72-A15E-47AB-969F-DA75AADB58BC}");
                public static readonly ID CompanyName = new ID("{DE3F4AC5-3C21-41F6-8A88-0393792298EC}");
                public static readonly ID Comment = new ID("{0ACF5D5B-DE47-4E45-8ED3-6693F75CD6F7}");
            }
        }
    }
}