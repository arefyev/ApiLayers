using Microsoft.Extensions.Options;
using Sample7.Models;
using Sample7.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample7.Data
{
    public sealed class CartsRepository : Repository<Cart>, ICartsRepository
    {
        public CartsRepository(IOptions<AppSettings> settings)
        {
            _contoller = "carts";
            _url = settings.Value.RepoExternalUrl;
        }

        public override Task<IEnumerable<Cart>> List()
        {
            return base.List();
        }
    }
}
