using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioMeta.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayController : ControllerBase
    {
        private readonly IArrayAppService _arrayAppService;

        public ArrayController(IArrayAppService arrayAppService)
        {
            _arrayAppService = arrayAppService;
        }

        [HttpGet]
        [Route("GetIndexArrayTarget")]
        public List<int> GetIndexArrayTarget(int NumberTarget)
        {
            return _arrayAppService.GetIndexArrayTarget(NumberTarget);
        }

        [HttpGet]
        [Route("BracketsIsBalanced")]
        public string BracketsIsBalanced(string brackets)
        {
            return _arrayAppService.BracketsIsBalanced(brackets);
        }

        [HttpPost]
        [Route("PurchaseAndSaleStockExchange")]
        public string PurchaseAndSaleStockExchange(string CpfUser, int DayToday)
        {
            return _arrayAppService.PurchaseAndSaleStockExchange(CpfUser, DayToday);
        }

        [HttpPost]
        [Route("CalculateWaterByRain")]
        public int CalculateWaterByRain([FromBody] int?[] numbers)
        {
            return _arrayAppService.CalculateWaterByRain(numbers);
        }


    }
}