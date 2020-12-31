using System;
using System.Reflection;
using BankAccountManagament.AdminsView;
using BankAccountManagament.UserView;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;

namespace BankAccountManagament {
    public class MainMenu : Menu {
       
        public void InitialiseBank() {
            var type = GetType().Assembly.GetReferencedAssemblies();
            //
                           // foreach (var VARIABLE in GetType().Assembly.GetTypes()) {
                           //     type = VARIABLE;
                           // } 
            if (String.IsNullOrEmpty(Bank.Admin)) {
                Common.Title("Initial");

                string bankTitle = Common.Input("Bank's name: ", 3);
                decimal initialBalance = Common.LoopMoneyInput("InitialBalance", 2);
                string admin = Common.Input("Admin's name", 3);
                string password = Common.Input("Admin's password", 3);
                decimal intresRate = Common.LoopMoneyInput("Intres Rate", 1);
                decimal provision = Common.LoopMoneyInput("Provision", 1);

                Bank.BankBalance = initialBalance;
                Bank.Admin = admin;
                Bank.AdminPassword = password;
                Bank.IntresRate = intresRate;
                Bank.Provision = provision;
                Bank.BankTitle = bankTitle;
                Console.WriteLine("All setup");
                Console.ReadLine();

         
            }

            Login();
        } 
        
         private static void Login() { 
             string clientId = Common.Input("ClientId", 1); 
                     
             if (!clientId.Equals(Bank.Admin)) {

                 Client client = null; //ClientServices.Get(clientId);
             
                if (LoopPassword(client)) 
                    new EditClientUserView(client.ClientId).Show(); 
                
                else Console.WriteLine("Client dose not exist"); 
                
             } else if(Common.Input("Password", 3).Equals(Bank.AdminPassword))
                 new MainAdminView().Show();
             else {
                 Console.WriteLine("Password was not correct");
             }
          
         }
        
        private static bool LoopPassword(Client client) {

            string password = Common.Input("Password", 3);
            try {
                
                if (client.Password.Equals(password))
                    return true;
                else {

                    Console.WriteLine("Password was not correct");

                    return LoopPassword(client);
                }
            }
            catch (NullReferenceException e) {
                Console.WriteLine("Client dose not exists");
            }

            return false;
        } 
    }
    
    
    
}