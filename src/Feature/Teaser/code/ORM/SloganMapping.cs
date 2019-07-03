using Claro.Feature.Teaser.Models;
using Glass.Mapper.Sc.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Claro.Feature.Teaser.ORM
{
    public class SloganMapping : SitecoreGlassMap<ISlogan>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Slogan.ID);
                config.Field(item => item.SloganImage).FieldId(Templates.Slogan.Fields.SloganImage);
            });
        }
    }
}