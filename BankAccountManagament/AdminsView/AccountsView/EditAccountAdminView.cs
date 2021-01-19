using System;
using BankAccountManagament.UserView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.CreditCardModel;
using BankAccountManagamentLibrary.Services;
using Controller;
using Controller.Utils;

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
            string d = ""; // if is deactive it adds "de"

            if (Account.Active) { 
                Console.WriteLine(
                $"{Account.Client.Emri}'s account is active and {Account.Client.Emri}'s account balance is: {Account.Balance}");
                Console.WriteLine();
                d = "de";
            }
            else Console.WriteLine($"{Account.Active}'s account is not active");
            
            Console.Write($"Do you want to {d}activated it?(Y/N)");
        
            char choice; 
            if(char.TryParse(Console.ReadLine(), out choice) && (choice == 'y' || choice == 'Y')) {
                Account.ChangeStatus();
                Console.WriteLine("Status changed succesfully");
            }    
        }

        public void RequestCreditCard() {
            
            if (Account.CreditCard == null) { 
                Console.Write("Do you want to request a credit card (Y/N): ");
                char c = char.Parse(Console.ReadLine());
                if (c == 'y' || c == 'Y') {
                     Account.CreditCard = (CreditCard) CrudOperations.Create<CreditCard>(new Property() {
                         PropertyName = "Client",
                        PropertyType = typeof(Client),
                        PropertyValue = Account.Client
                    });
                }
            }
            else {

                Console.WriteLine(Account.CreditCard);
            }
            
        }

            
        public void RequestLoan() {
            Loan loan = (Loan)Container.GetDependency(typeof(LoanServices)).InvokeMethod("GetFromAccount", Account.AccountNumber); 
            if (loan == null) { 
                loan = AddLoan(); 
            }
            else {
                Console.WriteLine("Loan Status: " + loan.ToString());
                if (loan._Paid < loan.Amount) {
                    Console.Write("Do you want to make a payment: (Y/N) ");
                    char c = char.Parse(Console.ReadLine());
                    if (c == 'Y' || c == 'y') {
                        loan.Account.WithDraw(loan.MonthlyFee(), 0);
                        Console.WriteLine("Succesfully");
                    }
                }
                else { 
                    loan = AddLoan(); 
                }
            } 
        } 
        
        private Loan AddLoan() {
          
            Loan loan = (Loan)CrudOperations.Create<Loan>(new Property() {
                PropertyName = "Account",
                PropertyType = typeof(Account),
                PropertyValue = Account
            });

            if (loan != null) {
                Console.WriteLine($"You will have to pay {loan.MonthlyFee()} each month");
            }

            return loan;


        }
      
    
    }
}
