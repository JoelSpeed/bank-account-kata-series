﻿using BankingKata;
using NSubstitute;
using NUnit.Framework;
using System;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void AccountRecordsDepositInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var account = new Account(ledger);

            account.Deposit(DateTime.Now, money);

            CreditEntry deposit = new CreditEntry(DateTime.Now, money);
            ledger.Received().Record(deposit);
        }

        [Test]
        public void AccountRecordsWithdrawalInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var account = new Account(ledger);

            account.Withdraw(DateTime.Now, money);

            var debitEntry = new DebitEntry(DateTime.Now, money);
            ledger.Received().Record(debitEntry);
        }

        [Test]
        public void AccountRecordsChequeWithdrawalInTransactionLog()
        {
            var ledger = Substitute.For<ILedger>();
            var money = new Money(3m);
            var cheque = new Cheque(money, new ChequeCode("123456"));
            var account = new Account(ledger);

            account.WithdrawCheque(DateTime.Now, cheque);

            var chequeDebitEntry = new ChequeDebitEntry(DateTime.Now, cheque);
            ledger.Received().Record(chequeDebitEntry);
        }

        [Test]
        public void CalculateBalanceTotalsAllDepositsMadeToTheAccount()
        {
            var ledger = Substitute.For<ILedger>();
            var account = new Account(ledger);

            account.CalculateBalance();

            ledger.Received().Accept(Arg.Any<BalanceCalculatingVisitor>(), new Money(0m));
        }

        [Test]
        public void LedgerTotalIsReturnedByCalculate()
        {
            var expectedBalance = new Money(13m);
            var ledger = Substitute.For<ILedger>();
            ledger.Accept(Arg.Any<BalanceCalculatingVisitor>(), new Money(0m)).Returns(expectedBalance);
            var account = new Account(ledger);

            var actualBalance = account.CalculateBalance();

            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }
    }
}
