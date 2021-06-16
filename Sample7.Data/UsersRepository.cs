using Microsoft.Extensions.Options;
using Sample7.Models;
using Sample7.Models.Common;

namespace Sample7.Data
{
    public sealed class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(IOptions<AppSettings> settings)
        {
            _contoller = "users";
            _url = settings.Value.RepoExternalUrl;
        }
    }
}
