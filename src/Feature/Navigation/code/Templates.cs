using Sitecore.Data;

namespace Claro.Feature.Navigation
{
    public struct Templates
    {
        public struct Navigable
        {
            public static readonly ID ID = new ID("{31978245-B101-479C-BA92-43D5EB00E60E}");
            public struct Fields
            {
                public static ID NavigationTitle = new ID("{9D3C1CD4-44C1-4B86-A3CC-444A9A96608E}");
                public static ID NavigationUrl = new ID("{24B051D7-4080-4C98-AC69-1F386EC40906}");
                public static ID IncludeInNavigation = new ID("{EF37FF38-43BB-4F73-917C-F834AC8635BE}");
                public static ID DisplayOrder = new ID("{40A574E7-A317-4AB1-AACF-DE046FEEA93F}");
            }
        }
        public struct NavigableFolder
        {
            public static ID ID = new ID("{5788B2EA-194D-4C53-A2E6-175E06A36366}");
        }
    }
}