using Claro.Foundation.ORM.Models;

namespace Claro.Feature.Blog.Models
{
    public interface IComment: IGlassBase
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string CompanyName { get; set; }
        string Comment { get; set; }
    }
}
