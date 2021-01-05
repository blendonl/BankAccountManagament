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
            Loan loan = (Loan)Container.GetDependency("LoanServices").InvokeMethod("GetFromAccount", Account.AccountNumber);
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
