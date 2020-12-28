using System;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView.AccountsView {

    /// <summary>
    /// The view to edit account
    /// </summary>
    class MainAccountAdminView: MainAccountView {
        public override long AccountNumber { get; }

       

        public void GoToBalanceAdminView() {
        }

        public MainAccountAdminView(long accountNumber) {
            this.AccountNumber = accountNumber;
        }

        public void CheckStatus() {

            Common.Title("Status");
            ClientUtils.ChangeAccountStatus(AccountNumber);
        }

        public void AddCreditCard() {
            Common.Title("CreditCard");
            ClientUtils.AddCreditCard(AccountNumber);
        }

        public void SendMoney() {
            Common.Title("Sending Money");
            ClientUtils.SendingMoney(AccountNumber, Bank.Provision);
        }

        public void Loan() {
            Common.Title("Loan");
            if (LoanServices.Get(AccountNumber) == null) {
                 ClientUtils.AddLoan(AccountNumber); 
            }
            else {
                Loan loan= LoanServices.Get(AccountNumber);
                Console.WriteLine("Loan Status: " + loan.ToString());
                if (loan.Paid < loan.Amount) {
                    Console.Write("Do you want to make a payment: (Y/N) ");
                    char c = char.Parse(Console.ReadLine());
                    if (c == 'Y' || c == 'y') {
                        LoanServices.MonthlyFee(loan.AccountNumber);
                        AccountServices.Get(loan.AccountNumber).WithDraw(loan.MonthlyFee(), 0);
                        Console.WriteLine("Succesfully");
                    }
                }
                else {
                    ClientUtils.AddLoan(AccountNumber);
                }
            }

        }
        
        

        public void RemoveAccount() {

            Common.Title("Removing account");

            if (AccountServices.Remove(AccountNumber))
               Console.WriteLine("Account removed succesfully");
            else
                Console.WriteLine("Account dose not exists");

        }
    }
}
