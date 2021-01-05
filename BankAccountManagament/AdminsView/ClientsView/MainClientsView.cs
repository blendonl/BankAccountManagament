using System;
using System.Runtime.InteropServices;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView.ClientsView {
   class MainClientsView : Menu {


        public void CreateClient() { 
            if(ClientUtils.Create<Client>())
                Console.WriteLine("Client added succesfully");
            else {
                Console.WriteLine("Client could not be added");
            }
        }

        public Client GoToEditClientAdminView() {
            string clientId = Common.Input("Client Id: ", 1);
            return (Client)Container.GetDependency("ClientServices").InvokeMethod("Get", clientId);
            
        }

        public void RemoveClient() {
            string clientId = Common.Input("Client Id: ", 1);
            if((bool)Container.GetDependency("ClientServices").InvokeMethod("Remove", clientId))
                Console.WriteLine("Client Removed Succesfully");
            else {
                Console.WriteLine("Client dose not exists");
            }
        }

        public void ViewClients() {
            Console.WriteLine(Container.GetDependency("ClientServices").InvokeMethod("GetAll", null));
        }
        
         
    }
}
