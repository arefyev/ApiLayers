using Sample7.Common;
using Sample7.Data;
using Sample7.Models;
using Sample7.Models.Common;
using Sample7.Models.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample7.Biz
{
    public sealed class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Task<Product> Get(int id)
        {
            return _productsRepository.Get(id);
        }

        public Task<IEnumerable<Product>> List()
        {
            return _productsRepository.List();
        }

        public async Task<SearchResultView> List(SearchParams searchParams)
        {
            var _products = await _productsRepository.List();

            if (searchParams.Asc)
                _products = _products.OrderByName(searchParams.SortField);
            else
                _products = _products.OrderByDescendingName(searchParams.SortField);

            var products = _products.Skip(searchParams.Page * searchParams.Count).Take(searchParams.Count);

            return new SearchResultView(products, _products.Count());
        }
    }
}