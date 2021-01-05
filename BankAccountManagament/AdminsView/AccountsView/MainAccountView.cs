using System;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Services;


namespace BankAccountManagament.AdminsView.AccountsView {

    class MainAccountAdminView: MainAccountView {
        public override Account Account { get; }

        
        public Account GoToBalanceAdminView() {
            return Account;
        }

        public MainAccountAdminView(Account account) {
            this.Account = account;
        }

        public void CheckStatus() {
            ClientUtils.ChangeAccountStatus(Account);
        }

        public void CreditCard() {
            ClientUtils.AddCreditCard(Account);
        }

            
        public void Loan() {
                if (LoanServices.Get(Account.AccountNumber) == null) {
                     ClientUtils.AddLoan(Account); 
                }
                else {
                    Loan loan= LoanServices.Get(Account.AccountNumber);
                    Console.WriteLine("Loan Status: " + loan.ToString());
                    if (loan.Paid < loan.Amount) {
                        Console.Write("Do you want to make a payment: (Y/N) ");
                        char c = char.Parse(Console.ReadLine());
                        if (c == 'Y' || c == 'y') {
                            LoanServices.MonthlyFee(loan.Account.AccountNumber);
                            loan.Account.WithDraw(loan.MonthlyFee(), 0);
                            Console.WriteLine("Succesfully");
                        }
                    }
                    else {
                        ClientUtils.AddLoan(Account);
                    }
                } 
           }    

      
    
    }
}
