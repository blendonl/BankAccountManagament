using System;
using System.Collections.Generic;
using System.Globalization;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;

namespace BankAccountManagamentLibrary.Services {
    public class LoanServices {
        private List<Loan> Loans;

        public LoanServices() {
            Loans = new List<Loan>();
        }
        

        public bool Add(Loan loan) {
            Loans.Add(loan); 
            BankServices.UpdateBalance(loan.Amount, TransactionType.Loan);
            loan.Account.Deposit(loan.Amount, 0);
            return true;
        
            return false;

        }

        public void MonthlyFee(string loanId) {
            
            Loan loan = Get(loanId);
            if (loan.Paid < loan.Amount) {
                if (loan.IsMonth()) {
                    if (!loan.Account.WithDraw(loan.MonthlyFee(), loan.InteresRate)) {
                        loan.InteresRate++;
                    } 
                }
            }
        }

        public bool Remove(string loanId) {
            int index =Loans.FindIndex(loan => loan.LoanId == loanId);

            if (index != -1) {
                return Loans.Remove(Database.Loans[index]);
                return true;
            }
            return false;
        }

        public Loan Get(string loanId) {
            int index = Loans.FindIndex(loan => loan.LoanId == loanId);

            if (index != -1) {
                return Loans[index];
            }
            
            return null;
        }
        public Loan GetFromAccount(long accountNumber) {
            int index =Loans.FindIndex(loan => loan.Account.AccountNumber== accountNumber);

            if (index != -1) {
                return Loans[index];
            }
            
            return null;
        }

        public bool Update(long loanId, decimal amount) {
            return false;
        }
        
        
          public string GetAll(long accountNumber) {
              string rez = "";
                     
                 
            foreach (var loan in Loans) {
                 if(accountNumber == loan.Account.AccountNumber)
                    rez += loan.ToString() + "\n"; 
            }
            
            return rez;
                                 
          }

    }
}
