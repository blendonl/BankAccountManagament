using System;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;

namespace BankAccountManagamentLibrary.Models {
    public class Loan {
        public string LoanId { get; set; }
        public Client Client { get; set; }
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public decimal Paid { get; set; }
        public DateTime StartingDate { get; set; }
        public int ExperationDateInMonths { get; set; }
        public decimal InteresRate { get; set; }
        public decimal MonthlyFee() {
            return Amount / ExperationDateInMonths + InteresRate;
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
