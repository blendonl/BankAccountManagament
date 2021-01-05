using System;
using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;

namespace BankAccountManagament.AdminsView.ClientsView {
    class EditClientAdminView: EditClientView {

        public override Client Client{
            get;
        } 
     
        public EditClientAdminView(Client client)  {
            Client= client;
        }
         public void CreateAccount() { 
             if(CrudOperations.Create<Account>(new Property("Client", "Client", Client) ))
                 Console.WriteLine("Account added succesfully");
             else {
                 Console.WriteLine("Account could not be added");
             }
             
         }
         public Account GoToMainAccountAdminView() { 
              Console.WriteLine(Container.GetDependency("AccountServices").InvokeMethod("GetAll", Client.ClientId));
              Console.WriteLine();

              Account account = (Account)Container.GetDependency("AccountServices")
                  .InvokeMethod("Get", Common.LoopInput("Account Number", 8));

              if (account != null)
                  return account;
              else {
                  return null;
              }

         }

         public void RemoveAccount() {
             long accountNumber = Common.LoopInput("Account Number", 8);
             if(CrudOperations.Remove<Account>(accountNumber))
                 Console.WriteLine("Account removed succesfully");
             else
                 Console.WriteLine("Account could not be removed");
         }
          
    }
}