using Claro.Feature.Blog.Models;
using Glass.Mapper.Sc.Maps;

namespace Claro.Feature.Blog.ORM
{
    public class AuthorMapping : SitecoreGlassMap<IAuthor>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Templates.Author.ID);
                config.Field(item => item.FirstName).FieldId(Templates.Author.Fields.FirstName);
                config.Field(item => item.LastName).FieldId(Templates.Author.Fields.LastName);
                config.Field(item => item.AuthorSummary).FieldId(Templates.Author.Fields.Summary);
                config.Field(item => item.Image).FieldId(Templates.Author.Fields.Image);
                config.Field(item => item.LinkedinUrl).FieldId(Templates.Author.Fields.LinkedinUrl);
                config.Field(item => item.TwitterUrl).FieldId(Templates.Author.Fields.TwitterUrl);

            });
        }
    }
}