using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    /// <summary>
    /// A reusable class to return the number in Words. It can be used for Currencies, Count etc. 
    /// </summary>
    public struct Wordable
    {
        readonly static string[] _tillTwenty = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        readonly static string[] _tens = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        readonly static int BILLION     = 1000000000;
        readonly static int MILLION     = 1000000;
        readonly static int THOUSAND    = 1000;
        readonly static int HUNDRED     = 100;
        readonly static int TWENTIES    = 20;

        /// <summary>
        /// Static function to use the functionality, easily
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static string InWords(int aValue)
        {
            return Convert(aValue).Trim();
        }

        /// <summary>
        /// Client can also create an instance of this or inherit it
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        private static string Convert(int aValue)
        {
            if (aValue == 0)
                return "Zero";

            return Wording(aValue);
        }

        /// <summary>
        /// recursive function to convert the integer in Words
        /// </summary>
        /// <param name="aValue"></param>
        /// <returns></returns>
        private static string Wording(int aValue)
        {
            if (aValue >= BILLION)
                return Convert(aValue / BILLION) + " Billion" + Wording(aValue % BILLION);
            if (aValue >= MILLION)
                return Convert(aValue / MILLION) + " Million" + Wording(aValue % MILLION);
            if (aValue >= THOUSAND)
                return Convert(aValue / THOUSAND) + " Thousand" + Wording(aValue % THOUSAND);
            if (aValue >= HUNDRED)
                return Convert(aValue / HUNDRED) + " Hundred" + Wording(aValue % HUNDRED);
            if (aValue >= TWENTIES)
                return " " + _tens[(aValue / 10)] + Wording(aValue % 10);

            if (aValue == 0)
                return "";

            return " " + _tillTwenty[aValue];
        }
    }
}
