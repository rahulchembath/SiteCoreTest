using Glass.Mapper.Sc.Fields;
namespace Claro.Feature.Blog.Models
{
    public interface ICategory:IBlogBase
    {
        string CategoryTitle { get; set; }
        Link CategoryUrl { get; set; }
        int DisplayOrder { get; set; }
    }
}
