using Claro.Feature.Blog.Models;
using Claro.Foundation.Content.Repositories;
using Claro.Foundation.Settings.Models;
using Glass.Mapper.Sc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Claro.Feature.Blog.Services
{
    public class QuoteService : IQuoteService
    {

        private readonly IContentRepository _contentRepository;
        private readonly IContextRepository _contextRepository;
        public QuoteService(IContentRepository contentRepository, IContextRepository contextRepository)
        {
            _contentRepository = contentRepository;
            _contextRepository = contextRepository;
        }
        public IQuote GetQuotes(int level)
        {
            try
            {
                IItemPathSettings quotePath = _contextRepository.GetRootItem<IItemPathSettings>();
                if (quotePath != null)
                {
                    var quotes = _contentRepository.GetItem<IQuoteFolder>(new GetItemByPathOptions { Path = quotePath.QuoteUrl });
                    if (quotes != null)
                    {
                        List<IQuote> quotesList = quotes.Quotes.ToList();
                        if (quotesList.Count > level)
                        {
                            return quotesList.ElementAt(level);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
            return null;
        }
    }
}