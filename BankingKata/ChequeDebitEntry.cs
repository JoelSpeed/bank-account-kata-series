using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingKata
{
    public class ChequeDebitEntry : ITransaction
    {
        private readonly DateTime transactionDate;
        private readonly Cheque transactionCheque;

        public ChequeDebitEntry(DateTime transactionDate, Cheque transactionCheque)
        {
            this.transactionDate = transactionDate;
            this.transactionCheque = transactionCheque;
        }

        public Money ApplyTo(Money balance)
        {
            return balance - transactionCheque;
        }

        public override bool Equals(object obj)
        {
            var transaction = (obj as ChequeDebitEntry);
            return transaction != null && transactionCheque.Equals(transaction.transactionCheque);
        }

        public override string ToString()
        {
            return string.Format("CHQ {0} {1} ({2})", (ChequeCode) transactionCheque, transactionDate.ToString("dd MMM yyyy"), (Money) transactionCheque);
        }
    }
}
