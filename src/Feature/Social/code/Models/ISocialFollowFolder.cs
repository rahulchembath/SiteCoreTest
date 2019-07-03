using Claro.Foundation.ORM.Models;
using System.Collections.Generic;

namespace Claro.Feature.Social.Models
{
    public interface ISocialFollowFolder: IGlassBase
    {
        IEnumerable<ISocialFollow> SocialFollow { get; set; }
    }
}
