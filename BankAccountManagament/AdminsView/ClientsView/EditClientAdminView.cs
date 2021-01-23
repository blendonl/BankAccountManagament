using System;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;
using Controller.Models;
using Controller.Utils;

namespace BankAccountManagament.AdminsView.ClientsView {
    class EditClientAdminView: Menu {

        public Client Client;
        public EditClientAdminView(Client client)  {
            Client= client;
        } 
        public void ViewAccounts() {
                    
        }
        
        public Client CreateAccount() {
            return Client;
        }
        
        public long GoToEditAccountAdminView() { 
              Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Account),  Client.PersoniId);

              return CommonViews.LoopInput<long>("Account Number", 8);
        }

        public long RemoveAccount() {
              Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Account), Client.PersoniId);
              return CommonViews.LoopInput<long>("Account Number", 8);
         }
          
    }
}