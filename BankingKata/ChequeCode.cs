using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingKata
{
    public class ChequeCode
    {
        private string _code;

        public ChequeCode(string code)
        {
            _code = code;
        }

        public override bool Equals(object @object)
        {
            var other = @object as ChequeCode;
            return other != null && _code == other._code;
        }

        public override string ToString()
        {
            return _code;
        }
    }
}
