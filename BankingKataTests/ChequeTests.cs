using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingKata;
using NUnit.Framework;

namespace BankingKataTests
{
    [TestFixture]
    public class ChequeTests
    {
        [Test]
        public void TwoChequesWithTheSameValuesAreEqual()
        {
            Money amountOfMoney = new Money(3m);
            ChequeCode code = new ChequeCode("123456");
            var cheque1 = new Cheque(amountOfMoney, code);
            var cheque2 = new Cheque(amountOfMoney, code);
            Assert.That(cheque1, Is.EqualTo(cheque2));
        }

        [Test]
        public void TwoChequesWithDifferentMoneyValuesAreNotEqual()
        {
            Money money1 = new Money(3m);
            Money money2 = new Money(5m);
            ChequeCode code = new ChequeCode("123456");
            var cheque1 = new Cheque(money1, code);
            var cheque2 = new Cheque(money2, code);

            Assert.That(cheque1, Is.Not.EqualTo(cheque2));
        }

        [Test]
        public void TwoChequesWithDifferentCodeValuesAreNotEqual()
        {
            Money money = new Money(3m);
            ChequeCode code1 = new ChequeCode("123456");
            ChequeCode code2 = new ChequeCode("456456");
            var cheque1 = new Cheque(money, code1);
            var cheque2 = new Cheque(money, code2);

            Assert.That(cheque1, Is.Not.EqualTo(cheque2));
        }
        [Test]
        public void ToStringConvertsTheDecimalValueToAString()
        {
            Assert.That(new Cheque(new Money(4m), new ChequeCode("123456")).ToString(), Is.EqualTo("$4.00"));
        }
    }
}
