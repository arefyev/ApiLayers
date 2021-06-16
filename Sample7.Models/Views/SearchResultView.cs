using System.Collections.Generic;

namespace Sample7.Models.Views
{
    public class SearchResultView
    {
        public SearchResultView(IEnumerable<IModel> results, int count)
        {
            Results = results;
            Count = count;
        }

        public IEnumerable<IModel> Results { get; set; }
        public int Count { get; set; }

    }
}
