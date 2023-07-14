using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Following the Domain Driven Design, the Currency can be used as a member data/ property for business entites. 
    /// There should be more functionality to be added, like airthmatic and comparission.
    /// </summary>
    public struct Currency : IEquatable<Currency>
    {
        private decimal _Value;

        public Currency(decimal value)
        {
            if (value > int.MaxValue)
                throw new ArgumentOutOfRangeException("Currency value should be in a range of " + int.MinValue + " to " + int.MaxValue);

            _Value = value;
        }

        /// <summary>
        /// To convert the currency value in Words
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int value = Math.Abs((int)_Value);
            string whole = Wordable.InWords(value).Trim() + (value == 1 ? " Dollor" : " Dollors");

            int centValue = Math.Abs( (int)((_Value - (int)_Value) * 100));
            string cents = Wordable.InWords(centValue) + (centValue == 1 ? " Cent" : " Cents");

            return whole + " and " + cents;
        }

        /// <summary>
        /// Good to implement for custom types
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Currency other)
        {
            return this._Value == other._Value;
        }

        ///TODO: The following and similar operators should be overloaded for the Currency
        public static Currency operator +(Currency a, Currency b) => throw new NotImplementedException();
        public static Currency operator -(Currency a, Currency b) => throw new NotImplementedException();
        public static Currency operator *(Currency a, Currency b) => throw new NotImplementedException();
        public static Currency operator /(Currency a, Currency b) => throw new NotImplementedException();

    }
}
