using Microsoft.AspNetCore.Mvc;
using Sample7.Api.Actions;
using Sample7.Biz;
using Sample7.Models;
using Sample7.Models.Common;
using Sample7.Models.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample7.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// Возвращает определенный продукт
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productsService.Get(id);
        }

        /// <summary>
        /// Возвращает все продукты
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Product>> List()
        {
            return await _productsService.List();
        }

        /// <summary>
        /// Осуществляет сортировку и фильтрацию
        /// </summary>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<SearchResultView> FilteredList(SearchParams searchParams)
        {
            return await _productsService.List(searchParams);
        }

        /// <summary>
        /// Импорт продуктов
        /// </summary>
        /// <returns></returns>
        [HttpGet("Import")]
        public async Task<object> Import()
        {
            var list = await _productsService.List();
            return new EmployeeCsvResult(list, $"products_{DateTime.Now.Ticks}.csv");
        }
    }
}
