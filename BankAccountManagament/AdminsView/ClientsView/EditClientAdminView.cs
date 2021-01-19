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
        public Client CreateAccount() {
            return Client;
        } 
        
        public long GoToEditAccountAdminView() { 
              Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Account),  new Object[] {Client.PersoniId});
              Console.WriteLine();

              return Common.LoopInput<long>("Account Number", 8);
        }

         public long RemoveAccount() {
              Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Account),  new Object[] {Client.PersoniId});
              return Common.LoopInput<long>("Account Number", 8);
         }
          
    }
}