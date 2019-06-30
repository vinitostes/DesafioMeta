using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Application
{
    public class ArrayAppService : IArrayAppService
    {
        public List<int> GetIndexArrayTarget(int NumberTarget)
        {
            List<int> arrayReturn = new List<int>();

            int[] arrayNumbers = { 1, 3, 5, 10};

            if (arrayNumbers[0] + arrayNumbers[1] == NumberTarget)
            {
                arrayReturn.Add(0);
                arrayReturn.Add(1);
            }
            else if (arrayNumbers[0] + arrayNumbers[2] == NumberTarget)
            {
                arrayReturn.Add(0);
                arrayReturn.Add(2);
            }
            else if (arrayNumbers[0] + arrayNumbers[3] == NumberTarget)
            {
                arrayReturn.Add(0);
                arrayReturn.Add(3);
            }
            else if (arrayNumbers[1] + arrayNumbers[2] == NumberTarget)
            {
                arrayReturn.Add(1);
                arrayReturn.Add(2);
            }
            else if (arrayNumbers[1] + arrayNumbers[3] == NumberTarget)
            {
                arrayReturn.Add(1);
                arrayReturn.Add(3);
            }
            else if (arrayNumbers[2] + arrayNumbers[3] == NumberTarget)
            {
                arrayReturn.Add(2);
                arrayReturn.Add(3);
            }

            return arrayReturn;
        }

        public string BracketsIsBalanced(string brackets)
        {
            string isBalanced = "SIM";
            string isNotBalanced = "NÃO";            

            if (brackets.Length % 2 != 0)
                return isNotBalanced;

            if (VerifyIfCharIsBalanceada(brackets) == true)
            {
                return isBalanced;
            }

            return isNotBalanced;
        }

        private bool VerifyIfCharIsBalanceada(string brackets)
        { 
            string ChavesBegin = "{";
            string ChavesClose = "}";

            string ParantesesBegin = "(";
            string ParantesesClose = ")";

            string ColchetesBegin = "[";
            string ColchetesClose = "]";

            var lenghtString = brackets.Length;

            var position = (lenghtString - 1);

            for (int i = 0; i <= (lenghtString / 2) - 1; i++)
            {
                if (brackets.Substring(i, 1) == ChavesBegin)
                {
                    if (brackets.Substring(position, 1) != ChavesClose)
                        return false;
                }

                if (brackets.Substring(i, 1) == ParantesesBegin)
                {
                    if (brackets.Substring(position, 1) != ParantesesClose)
                        return false;
                }

                if (brackets.Substring(i, 1) == ColchetesBegin)
                {
                    if (brackets.Substring(position, 1) != ColchetesClose)
                        return false;
                }

                position -= 1;
            }

            return true;
        }

        public string PurchaseAndSaleStockExchange(string CpfUser, int DayToday)
        {
            Dictionary<string,int> user = GetInformationUserByCpf(CpfUser);

            var priceToday = GetPriceDay(DayToday);
            if (!user.Any())
                return "Purchase Success in Value: " + string.Format("{0:0.00}", priceToday.ToString());

            double pricePurchase = new double();

            int dayPurchase = new int();
            foreach (var item in user)
            {
                dayPurchase = item.Value;
            }

            pricePurchase = GetPriceDay(dayPurchase);

            var profit = GetProfitFromPurchase(pricePurchase, priceToday);
            return "Total profit was: " + string.Format("{0:0.00}", profit.ToString());
        }

        private double GetProfitFromPurchase(double pricePurchase, double priceToday)
        {
            if (pricePurchase > priceToday)
            {
                return 0.00;
            }
            else
            {
                return priceToday - pricePurchase;
            }
        }

        private Dictionary<string, int> GetInformationUserByCpf(string cpfUser)
        {
            Dictionary<string, int> userReturn = new Dictionary<string, int>();

            Dictionary<string, int> user = new Dictionary<string, int>();
            user.Add("12345678987", 1);
            user.Add("12345678952", 4);
            user.Add("11640950729", 2);

            foreach (var item in user)
            {
                if (item.Key == cpfUser)
                {
                    userReturn.Add(item.Key, item.Value);
                }
            }

            return userReturn;
        }

        private double GetPriceDay(int day)
        {
            double[] PriceByDayStockExchange = { 2.0, 1.0, 6.0, 10.0, 3.0, 5.0 };

            double priceOfSaleOrPurchase = new double();
            for (int i = 0; i < (PriceByDayStockExchange.Count() - 1); i++)
            {
                if (i == (day - 1))
                    priceOfSaleOrPurchase = PriceByDayStockExchange[i];
            }

            return priceOfSaleOrPurchase;
        }

        public int CalculateWaterByRain(int?[] numbers)
        {
            //int?[] numbers = new int?[400];
            int value = 0;
            int[] analisedNumbers = new int[400];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == null)
                    continue;

                if (!analisedNumbers.Contains(numbers[i].Value))
                    analisedNumbers[i] = numbers[i].Value;
            }

            for (int i = 0; i < analisedNumbers.Length; i++)
            {
                if (analisedNumbers[i] == 0)
                    continue;

                value += analisedNumbers[i];
            }

            return value;
        }
    }
}
