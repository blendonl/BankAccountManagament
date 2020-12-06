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

        public override string[] Choices => new[] {
            "go to Balance",
            "go account transactions",
            "go to account status",
            "send money",
            "go to credit card",
            "loan",
            "remove account",
            "go back"
        };

        public override void Function1() {
            new BalanceAdminView(AccountServices.Get(AccountNumber)).Show();
        }

        public MainAccountAdminView(long accountNumber) {
            this.AccountNumber = accountNumber;
        }

        public override void Function3() {

            Common.Title("Status");
            ClientUtils.ChangeAccountStatus(AccountNumber);
        }

        public override void Function5() {
            Common.Title("CreditCard");
            ClientUtils.AddCreditCard(AccountNumber);
        }

        public override void Function4() {
            Common.Title("Sending Money");
            ClientUtils.SendingMoney(AccountNumber, Bank.Provision);
        }

        public override void Function6() {
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
        
        

        public override void Function7() {

            Common.Title("Removing account");

            if (AccountServices.Remove(AccountNumber))
               Console.WriteLine("Account removed succesfully");
            else
                Console.WriteLine("Account dose not exists");

        }
    }
}
