using Claro.Foundation.ORM.Models;
using Glass.Mapper.Sc.Fields;

namespace Claro.Feature.Blog.Models
{
    public interface IAuthor:IGlassBase
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string AuthorSummary { get; set; }
        Image Image { get; set; }
        Link LinkedinUrl { get; set; }
        Link TwitterUrl { get; set; }
    }
}
