using Microsoft.Extensions.Options;
using Sample7.Data;
using Sample7.Models;
using Sample7.Models.Common;
using Sample7.Models.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample7.Biz
{
    public sealed class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository, IOptions<AppSettings> settings)
        {
            _usersRepository = usersRepository;
            _usersRepository.SetConfig(settings.Value.RepoExternalUrl);
        }

        public Task<User> Get(int id)
        {
            return _usersRepository.Get(id);
        }

        public Task<object> Import(SearchParams searchParams)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> List()
        {
            return _usersRepository.List();
        }

        public Task<SearchResultView> List(SearchParams searchParams)
        {
            //we don't need this
            throw new System.NotImplementedException();
        }
    }
}
