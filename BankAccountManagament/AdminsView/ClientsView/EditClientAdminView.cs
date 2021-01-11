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
        public Property CreateAccount() {
            return new Property("Client", "Client",Client);
        } 
        
        public Account GoToEditAccountAdminView() { 
              Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Account),  Client.ClientId);
              Console.WriteLine();

              Account account = (Account)Container.GetDependency("AccountServices")
                  .InvokeMethod("Get", Common.LoopInput("Account Number", 8));

              if (account != null) 
                  return account;
              else 
                  return null;
        }

         public long RemoveAccount() {
              Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Account),  Client.ClientId);
              return Common.LoopInput("Account Number", 8);
         }
          
    }
}