using System;
using System.Globalization;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.TransactionModel;

namespace BankAccountManagamentLibrary.Services {
    public static class LoanServices {

        public static bool Add(long accountNumber, decimal amount, int months, decimal intresRate) {

            if (amount <= Bank.BankBalance && Get(accountNumber) == null) {
                Loan loan = new Loan() {
                    AccountNumber = accountNumber,
                    Amount = amount,
                    StartingDate = new DateTime(),
                    ExperationDateInMonths = months,
                    InteresRate = intresRate
                };

                Database.Loans.Add(loan);
                BankServices.UpdateBalance(amount, TransactionType.Loan);
                AccountServices.Get(accountNumber).Deposit(loan.Amount, 0);
                return true;
            }
            return false;

        }

        public static void MonthlyFee(long loanId) {
            Loan loan = Get(loanId);
            if (loan.Paid < loan.Amount) {
                if (loan.IsMonth()) {
                    if (!AccountServices.Get(loan.AccountNumber).WithDraw(loan.MonthlyFee(), loan.InteresRate)) {
                        loan.InteresRate++;
                    } 
                }
            }
        }

        public static bool Remove(string loanId) {
            int index = Database.Loans.FindIndex(loan => loan.LoanId == loanId);

            if (index != -1) {
                return Database.Loans.Remove(Database.Loans[index]);
                return true;
            }
            return false;
        }

        public static Loan Get(string loanId) {
            int index = Database.Loans.FindIndex(loan => loan.LoanId == loanId);

            if (index != -1) {
                return Database.Loans[index];
            }
            
            return null;
        }
        public static Loan Get(long accountNumber) {
            int index = Database.Loans.FindIndex(loan => loan.AccountNumber == accountNumber);

            if (index != -1) {
                return Database.Loans[index];
            }
            
            return null;
        }

        public static bool Update(long loanId, decimal amount) {
            return false;
        }


    }
}
