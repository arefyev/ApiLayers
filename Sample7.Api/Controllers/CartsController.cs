using Microsoft.AspNetCore.Mvc;
using Sample7.Api.Actions;
using Sample7.Biz;
using Sample7.Models.Common;
using Sample7.Models.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample7.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartsService _cardsService;

        public CartsController(ICartsService cardsService)
        {
            _cardsService = cardsService;
        }

        /// <summary>
        /// Возвращает определенный заказ
        /// </summary>
        /// <param name="id">Id заказа</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<CartView> Get(int id)
        {
            return await _cardsService.Get(id);
        }

        /// <summary>
        /// Возвращает все заказы
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CartView>> List()
        {
            return await _cardsService.List();
        }

        /// <summary>
        /// Осуществляет сортировку и фильтрацию
        /// </summary>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<SearchResultView> FilteredList(SearchParams searchParams)
        {
            return await _cardsService.List(searchParams);
        }

        /// <summary>
        /// Импорт заказов
        /// </summary>
        /// <returns></returns>
        [HttpGet("Import")]
        public async Task<object> Import()
        {
            var list = await _cardsService.List();
            return new EmployeeCsvResult(list, $"carts_{DateTime.Now.Ticks}.csv");
        }
    }
}
