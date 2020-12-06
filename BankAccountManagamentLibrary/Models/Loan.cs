using System;
using BankAccountManagamentLibrary.DataAccess;

namespace BankAccountManagamentLibrary.Models {
    public class Loan {
        
        public string LoanId { get; set; }
        public string ClientId { get; set; }
        public long AccountNumber { get; set; }
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
            return $"LoanId: {LoanId} ClientId: {ClientId} AccountNumber: {AccountNumber} StartingDate: {StartingDate.Day}/{StartingDate.Month}/{StartingDate.Year} Month: {MonthlyFee().ToString()}";
        }
    }
}
