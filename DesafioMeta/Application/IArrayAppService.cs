using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Application
{
    public interface IArrayAppService
    {
        List<int> GetIndexArrayTarget(int NumberTarget);

        string BracketsIsBalanced(string brackets);

        string PurchaseAndSaleStockExchange(string CpfUser, int DayToday);

        int CalculateWaterByRain(int?[] numbers);
    }
}
