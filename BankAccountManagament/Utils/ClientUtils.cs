using System;
using BankAccountManagament.AdminsView;
using BankAccountManagament.UserView;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.CreditCardModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankaccountManagamentLibrary.Services;
using Controller;
using Controller.Models;
using Controller.Utils;

namespace BankAccountManagament.Utils {
    public class ClientUtils {
        public static void Login() {
            CommonViews.Title("Login");
            
            int clientId = CommonViews.LoopInput<int>("ClientId", 1);

            Dependency dependency = Container.GetDependency("CrudOperations");

            object client = dependency.InvokeMethod("Select", typeof(Personi.Personi), clientId);

             if (client != null) {
                 if (client.GetType().Name.Equals("Administrator") ) {
                     
                     if(CommonViews.Input("Password", 3).Equals(((Administrator) client).Password)) 
                        new MainAdminView().Show();
                     else {
                         Console.WriteLine("Password was not correct");
                     }
                 }
                 else if (CommonViews.Input("Password", 3).Equals(((Client) client).Password)) {
                     
                     Container.GetDependency(typeof(EditClientUserView), (Client) client).InvokeMethod("Show");
                 } else {
                     Console.WriteLine("Password was not correct");
                 }
             }
             else {
                 Console.WriteLine("Client does not exists");
             }
        } 
        
        public static bool SendMoney(Account account, decimal provision) {
            CrudOperations.View<Account>();
            Console.WriteLine();
            Account account1 = (Account)CrudOperations.Select<Account>(CommonViews.LoopInput<long>("Account's number", 0));
            decimal amount = CommonViews.LoopInput<decimal>("Amount", 1);

            if (account1 != null) {

                ITransaction transaction = new SendMoney() {
                    Account = account,
                    Account1 = account1,
                    Amount = amount,
                    Provision = provision
                };

                return (bool) (Container.GetDependency(typeof(TransactionServices))?.InvokeMethod("Add", transaction) ?? false);
            }

            return false;
       }
        public static  void RequestCreditCard(Account account) {
            if (account.CreditCard == null) { 
                Console.Write("Do you want to request a credit card (Y/N): "); 
                char.TryParse(Console.ReadLine() ?? null, out var choice); 
                if (choice == 'y' || choice == 'Y') {
                    account.CreditCard = (CreditCard) CrudOperations.Create<CreditCard>(new Property() {
                        PropertyName = "Client", 
                        PropertyType = typeof(Client), 
                        PropertyValue = account.Client
                    }); 
                } 
            } else { 
                Console.WriteLine(account.CreditCard);
            }
        }
        public static  void RequestLoan(Account account) {
            Loan loan = (Loan)Container.GetDependency(typeof(TransactionServices)).InvokeMethod("GetAll", account.AccountNumber);
            
            if (loan == null) 
                loan = AddLoan(account);
            else { 
                Console.WriteLine("Loan Status: " + loan);
                
                if (loan._Paid < loan.Amount) { 
                    Console.Write("Do you want to make a payment: (Y/N) ");
                    
                    char.TryParse(Console.ReadLine(), out var choice);
                    
                    if (choice == 'Y' || choice == 'y') { 
                        loan.MonthlyFee();
                        
                        Console.WriteLine("Succesfully");
                    } 
                }
                else 
                   loan = AddLoan(account);
            } 
        }
        private static Loan AddLoan(Account account) {
           Loan loan = (Loan)CrudOperations.Create<Loan>(new Property() {
               PropertyName = "Account",
               PropertyType = typeof(Account),
               PropertyValue = account
           });

           if (loan != null) {
               Console.WriteLine($"You will have to pay {loan.MonthlyFee()} each month");
           }

           return loan;
        }
    }
}