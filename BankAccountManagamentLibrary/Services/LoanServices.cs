using System;
using System.Globalization;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;

namespace BankAccountManagamentLibrary.Services {
    public static class LoanServices {

        public static bool Add(Account account, decimal amount, int months, decimal intresRate) {

            if (amount <= Bank.BankBalance && Get(account.AccountNumber) == null) {
                Loan loan = new Loan() {
                    Account= account,
                    Amount = amount,
                    StartingDate = new DateTime(),
                    ExperationDateInMonths = months,
                    InteresRate = intresRate
                };

                Database.Loans.Add(loan);
                BankServices.UpdateBalance(amount, TransactionType.Loan);
                account.Deposit(loan.Amount, 0);
                return true;
            }
            return false;

        }

        public static void MonthlyFee(long loanId) {
            Loan loan = Get(loanId);
            if (loan.Paid < loan.Amount) {
                if (loan.IsMonth()) {
                    if (!loan.Account.WithDraw(loan.MonthlyFee(), loan.InteresRate)) {
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
            int index = Database.Loans.FindIndex(loan => loan.Account.AccountNumber== accountNumber);

            if (index != -1) {
                return Database.Loans[index];
            }
            
            return null;
        }

        public static bool Update(long loanId, decimal amount) {
            return false;
        }
        
        
          public static string GetAll(long accountNumber) {
              string rez = "";
                     
                 
            foreach (var loan in Database.Loans) {
                 if(accountNumber == loan.Account.AccountNumber)
                    rez += loan.ToString() + "\n"; 
            }
            
            return rez;
                                 
          }

    }
}
