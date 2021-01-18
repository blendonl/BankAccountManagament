using System;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;

namespace BankAccountManagamentLibrary.Models {
    public class Loan {
        public string LoanId { get;  }
        public Client Client { get; set; }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public decimal _Paid { get; set; }
        
        
        public DateTime StartingDate { get; set; }
        public int ExperationDateInMonths { get; set;  }
        public decimal _InteresRate { get; set; }

        private static int count;

        public Loan() {
            LoanId = count++.ToString();
        }
        
        
        public decimal MonthlyFee() {
            return Amount / ExperationDateInMonths + _InteresRate * Amount / ExperationDateInMonths;
        }

        public bool IsMonth() {
            if (!new DateTime().Month.Equals(StartingDate.Month) && new DateTime().Year.Equals(StartingDate.Year)) {
                return true;
            }

            return false;
        }

        public override string ToString() {
            return $"LoanId: {LoanId} " +
                   $"ClientId: {Client.PersoniId} " +
                   $"AccountNumber: {Account.AccountNumber} " +
                   $"StartingDate: {StartingDate.Day}/{StartingDate.Month}/{StartingDate.Year} " +
                   $"Month: {MonthlyFee()}";
        }
    }
}
