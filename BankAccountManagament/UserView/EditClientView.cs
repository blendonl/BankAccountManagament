using System;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;
using Controller.Models;
using Controller.Utils;


namespace BankAccountManagament.UserView {
    class EditClientUserView : Menu {
        public Client Client { get; }

        public EditClientUserView(Client client) {
            Client = client;
        }

        public Client ViewAccounts() {
            return Client;
        }
        
        public long GoToMainAccountUserView() { 
            Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Account),  Client.PersoniId); 
            Console.WriteLine(); 
            
            return CommonViews.LoopInput<long>("Account number", 8);
        }

    }
}
