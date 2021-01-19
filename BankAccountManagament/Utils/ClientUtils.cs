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
             int clientId = (int)Common.LoopInput<int>("ClientId", 1);

             Dependency dependency = Controller.Container.GetDependency("CrudOperations");

             object obj = dependency.InvokeMethod("Select",typeof(Personi.Personi), new Object[] {clientId});

             if (obj != null) {

                 if (obj.GetType().Name.Equals("Administrator") ) {
                     if(Common.Input("Password", 3).Equals(((Administrator) obj).Password)) 
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
       
        
        public static void ChangeAccountStatus(Account account) { 
            
        }
      
       
    }
}