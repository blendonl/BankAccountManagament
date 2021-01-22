using System;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagamentLibrary.Models.TransactionModel {
    public class Loan : ITransaction {
        public int TransactionId { get; set; }
        public Account Account { get; set; }
        public decimal Provision { get; set; }
        public bool TransactionStatus { get; set; }
        public decimal Amount { get; set; }
        public decimal _Paid { get; set; }
        
        public DateTime Date { get; set; }
        public int ExperationDateInMonths { get; set;  }
        public decimal _InteresRate { get; set; }

        private static int count;
        public Loan() {
            TransactionId = count++;
        }
        public bool MakeTransaction() {
            if (!Account.Active) return false;
            
            _InteresRate = Bank.IntresRate;
            Amount += Amount - Provision;
            return true;
            
        }
        
        public bool MonthlyFee() {
            
            decimal monthlyFee = Amount / ExperationDateInMonths + _InteresRate * Amount / ExperationDateInMonths;
            
            if (_Paid < Amount) {
                if (IsMonth()) {
                    Account.Balance -= (monthlyFee + _InteresRate);
                    return true;
                }
            }

            return false;
        }

        public bool IsMonth() {
            if (!new DateTime().Month.Equals(Date.Month) && new DateTime().Year.Equals(Date.Year)) {
                return true;
            }

            return false;
        }

        public override string ToString() {
            return $"LoanId: {TransactionId} " +
                   $"ClientId: {Account.Client.PersoniId} " +
                   $"AccountNumber: {Account.AccountNumber} " +
                   $"StartingDate: {Date.Day}/{Date.Month}/{Date.Year} " +
                   $"Month: {MonthlyFee()}";
        }
    }
}
