using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingKata
{
    public class Cheque
    {
        private readonly Money _chequeAmount;
        private readonly ChequeCode _chequeCode;

        public Cheque(Money amount, ChequeCode code)
        {
            _chequeAmount = amount;
            _chequeCode = code;
        }

        public override bool Equals(object @object)
        {
            var other = @object as Cheque;
            return other != null 
                && _chequeAmount.Equals(other._chequeAmount) 
                && _chequeCode.Equals(other._chequeCode);
        }

        public static implicit operator Money(Cheque cheque)
        {
            return cheque._chequeAmount;
        }

        public static implicit operator ChequeCode(Cheque cheque)
        {
            return cheque._chequeCode;
        }

        public override string ToString()
        {
            return _chequeAmount.ToString();
        }
    }
}
