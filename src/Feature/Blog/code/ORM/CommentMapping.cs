using Claro.Feature.Blog.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Blog.ORM
{
    public class CommentMapping : SitecoreGlassMap<IComment>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Comment.ID);
                config.Field(item => item.FirstName).FieldId(Templates.Comment.Fields.FirstName);
                config.Field(item => item.LastName).FieldId(Templates.Comment.Fields.LastName);
                config.Field(item => item.Email).FieldId(Templates.Comment.Fields.Email);
                config.Field(item => item.CompanyName).FieldId(Templates.Comment.Fields.CompanyName);
                config.Field(item => item.Comment).FieldId(Templates.Comment.Fields.Comment);
            });
        }
    }
}