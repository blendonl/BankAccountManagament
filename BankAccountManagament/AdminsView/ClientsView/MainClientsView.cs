using System;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView.ClientsView {
    class MainClientsView : Menu {

        
        public void CreateClient() { 
            ClientUtils.CreateClient();
        }

        public void SelectClient() {
            string clientId = Common.Input("Client Id: ", 1);
            new EditClientAdminView(clientId).Show();
        }

        public void RemoveClient() {
            string clientId = Common.Input("Client Id: ", 1);
            if(ClientServices.Remove(clientId)) 
                Console.WriteLine("Client Removed Succesfully");
            else {
                Console.WriteLine("Client dose not exists");
            }
        }

        public void ViewClients() {
            Console.WriteLine(Convertor.GetAllClients());
        }
    }
}
