namespace Claro.Feature.Blog.Interface
{
    public interface IConverter<TSource, TDesc>
    {
        TDesc ConvertTo(TSource source, bool isFeaturedArticle=false);
    }
}
