using System;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Controller;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView.ClientsView {
    class MainClientsView : Menu {

        public void AddClient() {
            Common.Title("Adding Client");
            ClientUtils.CreateClient();
        }

        public string GoToClientAdminView() {
            Common.Title("Selecting Client");
            string clientId = Common.Input("Client Id: ", 1);
            if (ClientServices.Get(clientId) != null) {
                return clientId;
            }
            else {
                return null;
            }
        }

        public void RemoveClient() {
            Common.Title("Removing Client");
            string clientId = Common.Input("Client Id: ", 1);
            if(ClientServices.Remove(clientId)) 
                Console.WriteLine("Client Removed Succesfully");
            else {
                Console.WriteLine("Client dose not exists");
            }
        }

        public void ViewClients() {
            Common.Title("All Clients");
            Console.WriteLine(Convertor.GetAllClients());
        }
    }
}
