using System;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView.ClientsView {
    class MainClientsView : Menu {

        public override string[] Choices => new[] {
            "View All Clients",
            "Add Client",
            "Edit Client",
            "Remove Client",
            "Go Back"
        };

        public override string Title => "Clients View"; 

        public override void Function2() {
            Common.Title("Adding Client");
            ClientUtils.CreateClient();
        }

        public override void Function3() {
            Common.Title("Selecting Client");
            string clientId = Common.Input("Client Id: ", 1);
            new EditClientAdminView(clientId).Show();
        }

        public override void Function4() {
            Common.Title("Removing Client");
            string clientId = Common.Input("Client Id: ", 1);
            if(ClientServices.Remove(clientId)) 
                Console.WriteLine("Client Removed Succesfully");
            else {
                Console.WriteLine("Client dose not exists");
            }
        }

        public override void Function1() {
            Common.Title("All Clients");
            Console.WriteLine(Convertor.GetAllClients());
        }
    }
}
