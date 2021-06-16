using Sample7.Models.Common;
using Sample7.Models.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample7.Biz
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> List();

        Task<T> Get(int id);

        Task<SearchResultView> List(SearchParams searchParams);
    }
}
