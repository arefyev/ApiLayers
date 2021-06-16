using Microsoft.Extensions.Options;
using Sample7.Models;
using Sample7.Models.Common;

namespace Sample7.Data
{
    public sealed class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public ProductsRepository(IOptions<AppSettings> settings)
        {
            _contoller = "products";
            _url = settings.Value.RepoExternalUrl;
        }
    }
}
