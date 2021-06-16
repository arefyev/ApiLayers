using Microsoft.AspNetCore.Mvc;
using Sample7.Biz;
using Sample7.Models;
using Sample7.Models.Common;
using Sample7.Models.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample7.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userService.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<User>> List()
        {
            return await _userService.List();
        }

        /// <summary>
        /// Осуществляет сортировку и фильтрацию
        /// </summary>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<SearchResultView> FilteredList(SearchParams searchParams)
        {
            return await _userService.List(searchParams);
        }
    }
}
