using System;
using BankAccountManagament.AdminsView;
using BankAccountManagament.AdminsView.ClientsView;
using BankAccountManagament.Models;
using BankAccountManagament.UserView;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankaccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.Utils {
    static class ClientUtils {
        
         public static void Login() { 
             Common.Title("Login"); 
             string clientId = Common.Input("ClientId", 1); 
             
             if (!clientId.Equals(Bank.Admin)) {
                
                Client client = ClientServices.Get(clientId);
             
                if (LoopPassword(client)) 
                    new EditClientUserView(client.ClientId).Show(); 
                
                else Console.WriteLine("Client dose not exist"); 
                
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

        public static bool CreateClient() {
            
            long personalNumber = Common.LoopInput("Personal Number", 8);
            string name = Common.Input("Name", 3);
            string lastName = Common.Input("Last Name", 3);
            string Address = Common.Input("Adress", 3);
            string email = Common.Input("Email", 3);
            long phoneNumber = Common.LoopInput("Phone Number", 9);
            string password = Common.Input("Password", 3);
            if(ClientServices.Add(personalNumber, name, lastName, password, Address, phoneNumber, email))
                return false;
            return true;

        }


        public static void AddAccount(string clientId) {
            AccountType accountType = (AccountType) Common.LoopInput("Account Type", 1);
            decimal initialDeposit = Common.LoopMoneyInput("Initial Input", 0);
            AccountServices.Add(ClientServices.Get(clientId), accountType, initialDeposit);
            Console.WriteLine("Account Added Succesfully");
            
        }

        public static void AddCreditCard(long accountNumber) { 
            if (AccountServices.Get(accountNumber).CreditCard == null) {
                 Console.Write("Do you want to request a credit card (Y/N): ");
                 char c = char.Parse(Console.ReadLine());
                 if (c == 'y' || c == 'Y') {
                     Common.PrintCreditCardTypes();
                     CreditCardType creditCardType = (CreditCardType) Common.LoopInput("Choose: ", 0);
                     CreditCardServices.Add(accountNumber, creditCardType);
                     Console.WriteLine("Credit card added succesfully");
                 }
            }
            else Console.WriteLine(AccountServices.Get(accountNumber).CreditCard.ToString());
        }

        public static void ChangeAccountStatus(long accountNumber) { 
            string d = ""; // if is deactive it adds "de"

            Account account = AccountServices.Get(accountNumber);
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
        public static void SendingMoney(long accountNumber, decimal intresRate) {
            Console.WriteLine(Convertor.GetAllAccounts());
            Console.WriteLine();
            long accountNumber1 = Common.LoopInput("Account's number", 0);
            decimal amount = Common.LoopMoneyInput("Amount", 1);
         
            if (TransactionServices.Add(accountNumber, accountNumber1, amount, intresRate)) {
                Console.WriteLine("Money sended succesfully");
            }
            else {
                Console.WriteLine("Money couldnt be sended");
            }
                     
        }

        public static void AddLoan(long accountNumber) {
            Common.Title("Adding Loan");
            decimal amount = Common.LoopInput("Amount you want to loan", 1);
            long months = Common.LoopInput("Months you want to pay", 1);

            if (LoanServices.Add(accountNumber, amount, (int) months, Bank.IntresRate)) {
                Console.WriteLine("Loan added succesfully");
                Console.WriteLine($"You will have to pay {LoanServices.Get(accountNumber).MonthlyFee()} each month");
            }
            else Console.WriteLine("You cannot loan this amount");
        }
    }
}
