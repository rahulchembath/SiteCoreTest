using Sitecore.Data;

namespace Claro.Foundation.Dictionary
{
    public struct Templates
    {
        public struct Dictionary
        {
            public static readonly ID ID = new ID("{D87106F5-4B2A-461B-A92F-303EFE2A1D2C}");
            public struct Fields
            {
                public static readonly ID key = new ID("{F1DB7AD6-2719-4D5E-999C-9268D1DC8730}");
                public static readonly ID Phrase = new ID("{04E658EE-A9C3-42DC-9457-C96250B4FFF4}");
                public static string PharseFieldName = "Pharse";
            }
        }
        public struct DictionarySetting
        {
            public static readonly ID ID = new ID("{A03DDFB6-5952-471A-945E-50A52A5E0C73}");
            public struct Fields
            {
                public static readonly ID DictionaryPath = new ID("{7AD51A9A-C22D-4E8A-A7C2-4BCE5A8A4CCE}");
            }
        }


    }
}