using System;
using BankAccountManagament.AdminsView;
using BankAccountManagament.Models;
using BankAccountManagament.UserView;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.CreditCardModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using Controller;

namespace BankAccountManagament.Utils {
    public class ClientUtils {
        public static void Login() { 
             Common.Title("Login"); 
             int clientId = (int)Common.LoopInput("ClientId", 1);

             Dependency dependency = Controller.Container.GetDependency("CrudOperations");

             object obj = dependency.InvokeMethod("Select",typeof(Personi.Personi), clientId);

             if (obj != null) {

                 if (obj.GetType().Name.Equals("Admin") ) {
                     if(Common.Input("Password", 3).Equals(((Admin) obj).Password)) 
                        new MainAdminView().Show();
                 }
                 else if (Common.Input("Password", 3).Equals(((Client) obj).Password)) {
                     new EditClientUserView((Client)obj).Show(); 
                 } else {
                     Console.WriteLine("Password was not correct");
                 }
             }
             else {
                 Console.WriteLine("Client does not exists");
             }
        }
        public static bool LoopPassword(Client client) {
            
            // geting password from input
            string password = Common.Input("Password", 3);
            try {
                //checking if the password matches
                if (client.Password.Equals(password))
                    return true;
                else {

                    // shows message
                    Console.WriteLine("Password was not correct");

                    // repeats the above steps
                    return LoopPassword(client);
                }
            }
            catch (NullReferenceException e) {
                Console.WriteLine("Client dose not exists");
            }

            return false;
        }
        public static void AddCreditCard(Account account) { 
            if (account.CreditCard == null) {
                 Console.Write("Do you want to request a credit card (Y/N): ");
                 char c = char.Parse(Console.ReadLine());
                 if (c == 'y' || c == 'Y') {
                     CreditCardType creditCardType = (CreditCardType) Common.LoopInput("Choose: ", 0);
                     CreditCard creditCard = new CreditCard() {
                            CreditCardType = creditCardType
                     };
                     Container.GetDependency("CreditCardServices").InvokeMethod("Add", new Object[] {account, creditCard});
                     //CreditCardServices.Add(account, creditCardType);
                     Console.WriteLine("Credit card added succesfully");
                 }
            }
            else Console.WriteLine(account.CreditCard.ToString());
        }
        
        public static void ChangeAccountStatus(Account account) { 
            string d = ""; // if is deactive it adds "de"

            if (account.Active) { 
                Console.WriteLine(
                $"{account.Client.Emri}'s account is active and {account.Client.Emri}'s account balance is: {account.Balance}");
                Console.WriteLine();
                d = "de";
            }
            else Console.WriteLine($"{account.Active}'s account is not active");
            
            Console.Write($"Do you want to {d}activated it?(Y/N)");
        
            char choice; 
            if(char.TryParse(Console.ReadLine(), out choice) && (choice == 'y' || choice == 'Y')) {
                account.ChangeStatus();
                Console.WriteLine("Status changed succesfully");
            }    
        }
        public static void SendingMoney(Account account, decimal intresRate) {
            Console.WriteLine(Container.GetDependency("AccountServices").InvokeMethod("GetAll", null));
            Console.WriteLine();
            Account account1 = (Account)Container.GetDependency("AccountServices").InvokeMethod("Get", Common.LoopInput("Account's number", 0));
            decimal amount = Common.LoopMoneyInput("Amount", 1);

            Transaction transaction = new Transaction() {
                Account = account,
                Account1 = account1,
                Amount = amount,
                Client = account.Client,
                Client1 = account.Client,
                TransactionType = TransactionType.Send,
                Provision = Bank.Provision
            };
         
            if ((bool)Container.GetDependency("TransactionServices").InvokeMethod("Add", transaction)) {
                Console.WriteLine("Money sended succesfully");
            }
            else {
                Console.WriteLine("Money couldnt be sended");
            }
        }

        public static void AddLoan(Account account) {
            decimal amount = Common.LoopInput("Amount you want to loan", 1);
            long months = Common.LoopInput("Months you want to pay", 1);

            Loan loan = new Loan() {
                Account = account,
                Amount = amount,
                ExperationDateInMonths = (int) months,
                InteresRate = Bank.IntresRate
            };

            if ((bool)Container.GetDependency("LoanServices").InvokeMethod("Add",loan)) {
                Console.WriteLine("Loan added succesfully");
                Console.WriteLine($"You will have to pay {((Loan)Container.GetDependency("LoanServices").InvokeMethod("GetFromAccount",account.AccountNumber)).MonthlyFee()} each month");
            }
            else Console.WriteLine("You cannot loan this amount");
        }
    }
}