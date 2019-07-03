using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration;
using Claro.Foundation.Control.Models;

namespace Claro.Feature.Blog.Models
{
    public interface IBlog : IBlogBase
    {
        string Title { get; set; }
        string Intro { get; set; }
        string Description { get; set; }

        Image LandingBoxImage { get; set; }
        Image HeroImage { get; set; }
        Image FeatureImage { get; set; }
        DateTime BlogCreated { get; set; }

        [SitecoreField(FieldName = Templates.Blog.Fields.BlogAuthorFieldName, Setting = SitecoreFieldSettings.InferType)]
        IAuthor Author { get; set; }

        [SitecoreField(FieldName = Templates.Blog.Fields.BlogCategoryFieldName, Setting = SitecoreFieldSettings.InferType)]
        IEnumerable<ICategory> Categories { get; set; }

        [SitecoreField(FieldName = Templates.Blog.Fields.SocialShare, Setting = SitecoreFieldSettings.InferType)]
        IEnumerable<IOptionItem> SocialShares { get; set; }
    }
}
