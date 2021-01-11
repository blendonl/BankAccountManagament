using System;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Services;
using Controller;

namespace BankAccountManagament.AdminsView.AccountsView {

    class EditAccountAdminView : MainAccountView {
        public override Account Account { get; }

        
        public Account GoToBalanceAdminView() {
            return Account;
        }
        public EditAccountAdminView(Account account) {
            this.Account = account;
        }

        public void CheckStatus() {
            ClientUtils.ChangeAccountStatus(Account);
        }

        public Account CreateCreditCard() {
            //TODO Fix Creating Credit Card Dinamicly
            //ClientUtils.AddCreditCard(Account);
            return Account;
        }

            
        public void Loan() {
            //TODO: Fix creating loan automaticly
            Loan loan = (Loan)Container.GetDependency(typeof(LoanServices)).InvokeMethod("GetFromAccount", Account.AccountNumber);
                if (loan == null) {
                    
                     ClientUtils.AddLoan(Account); 
                }
                else {
                    Console.WriteLine("Loan Status: " + loan.ToString());
                    if (loan.Paid < loan.Amount) {
                        Console.Write("Do you want to make a payment: (Y/N) ");
                        char c = char.Parse(Console.ReadLine()); 
                        if (c == 'Y' || c == 'y') {
                            Container.GetDependency("LoanServices").InvokeMethod("MonthlyFee", loan.LoanId);
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
