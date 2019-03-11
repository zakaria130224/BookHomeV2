using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nut;

namespace EnterpriseSolution.Infrastructure.Helpers
{
    public class AmountToTextConverter
    {
        public static string ConvertAmountToText(double amount)
        {
            if (amount<0) {
                amount = amount * (-1);
            }

            string amountInWords = "";
            var amountStringList = Math.Round(amount, 2).ToString().Split('.');
            if (amountStringList.Length == 1)
            {
                amountInWords = Int32.Parse(amountStringList[0]).ToText(Currency.USD, Language.English).Substring(0, Int32.Parse(amountStringList[0]).ToText(Currency.USD, Language.English).Length - 17) + "Taka";
                return amountInWords.First().ToString().ToUpper() +  amountInWords.Substring(1);
            }
            amountInWords = Int32.Parse(amountStringList[0]).ToText(Currency.USD, Language.English).Substring(0, Int32.Parse(amountStringList[0]).ToText(Currency.USD, Language.English).Length - 17) + "Taka";
            amountInWords = amountInWords + " " + Int32.Parse(amountStringList[1]).ToText(Currency.USD, Language.English).Substring(0, Int32.Parse(amountStringList[1]).ToText(Currency.USD, Language.English).Length - 17) + "Poisa";
            return amountInWords.First().ToString().ToUpper() + amountInWords.Substring(1);
        }
    }
}
