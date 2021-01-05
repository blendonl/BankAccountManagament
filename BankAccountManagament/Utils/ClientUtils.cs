using System;
using System.Collections.Generic;
using BankAccountManagament.AdminsView;
using BankAccountManagament.Models;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.CreditCardModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankaccountManagamentLibrary.Services;


namespace BankAccountManagament.Utils {
    static class ClientUtils {
        
         public static void Login() { 
             Common.Title("Login"); 
             string clientId = Common.Input("ClientId", 1); 
             
             if (!clientId.Equals(Bank.Admin)) {
                
               // Client client = ClientServices.Get(clientId);
             
                // if (LoopPassword(client)) 
                //     new EditClientUserView(client).Show(); 
                //
                // else Console.WriteLine("Client dose not exist"); 
                
             } else if(Common.Input("Password", 3).Equals(Bank.AdminPassword))
                 new MainAdminView().Show();
             else {
                 Console.WriteLine("Password was not correct");
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

        public static bool Create<T>(params Property[] givenProperties) {
            var models = Container.GetAllThatExtendsToString(typeof(T)).ToArray();
            int choice = Common.Menu(models);
            Console.WriteLine();
            try {
                Dependency dependency = Container.GetDependency(models[choice]);

                List<Property> properties = GetPropsFromInput(dependency);
                
                if(givenProperties != null)
                    properties.AddRange(givenProperties);
                
                foreach (var property in properties) {
                    dependency.InitialiseProp(property);
                }
                if((bool)Container.GetDependency($"{typeof(T).Name}Services").InvokeMethod("Add", dependency.ActualObject))
                   //if (ClientServices.Add((T)(dependency.ActualObject))) {
                    return true;

                return false;
            }
            catch (IndexOutOfRangeException) {
                return false;
            }
        }
         
        public static List<Property> GetPropsFromInput(Dependency dependency) {

            List<Property> props = dependency.GetProperties(); 
           

            for (int i = 0; i < props.Count; i++) {
                if (props[i].PropertyType.Equals("String"))
                
                    props[i].PropertyValue = Common.Input(props[i].PropertyName, 1);
                
                else if (props[i].PropertyType.Equals("Decimal")) {
                    
                    props[i].PropertyValue = Common.LoopMoneyInput(props[i].PropertyName, 1);
                    
                } else {
                    props[i].PropertyValue = Common.LoopInput(props[i].PropertyName, 1);
                    
                }
            }

            return props;
            
        }
        
        
        public static bool Remove<T>(object id) {
            // ReSharper disable once PossibleNullReferenceException
            return (bool)Container.GetDependency($"{typeof(T).Name}Services", typeof(T)).InvokeMethod("Remove", id);
            //     Console.WriteLine($"{typeof(T).Name} removed successfully");
            // else {
            //     Console.WriteLine($"{typeof(T).Name} could not be removed");
            // }
        }
        // public static void AddAccount(string clientId) {
        //     
        //     AccountType accountType = (AccountType) Common.LoopInput("Account Type", 1);
        //     decimal initialDeposit = Common.LoopMoneyInput("Initial Input", 0);
        //     AccountServices.Add(ClientServices.Get(clientId), accountType, initialDeposit);
        //     Console.WriteLine("Account Added Succesfully");
        //     
        // }

        public static void AddCreditCard(Account account) { 
            if (account.CreditCard == null) {
                 Console.Write("Do you want to request a credit card (Y/N): ");
                 char c = char.Parse(Console.ReadLine());
                 if (c == 'y' || c == 'Y') {
                     Common.PrintCreditCardTypes();
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
                $"{account.Client.Name}'s account is active and {account.Client.Name}'s account balance is: {account.Balance}");
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
            Common.Title("Adding Loan");
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
