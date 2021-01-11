using BankAccountManagamentLibrary.Models.ClientModel;

using Controller;

namespace BankAccountManagament.AdminsView.ClientsView {
   class MainClientsView : Menu {
        
        public void ViewClients() {
        } 
        public void CreateClient() { 
           
        }

        public Client GoToEditClientAdminView() {
            Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Client), null);
            string clientId = Common.Input("Client Id: ", 1);
            return (Client)Container.GetDependency("ClientServices").InvokeMethod("Get", clientId);
            
        }

        public string RemoveClient() {
            Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Client), null);
            return Common.Input("Client Id: ", 1);
        }
    }
}
