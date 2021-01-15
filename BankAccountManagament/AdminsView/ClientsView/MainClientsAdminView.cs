using BankAccountManagamentLibrary.Models.ClientModel;

using Controller;

namespace BankAccountManagament.AdminsView.ClientsView {
   class MainClientsAdminView : Menu {
        
        public void ViewClients() {
        } 
        public void CreateClient() { 
           
        }

        public int GoToEditClientAdminView() {
            Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Client), null);
            return (int)Common.LoopInput("Client Id: ", 1);
            //return (Client)Container.GetDependency("ClientServices").InvokeMethod("Get", clientId);
            
        }

        public int RemoveClient() {
            Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Client), null);
            return (int)Common.LoopInput("Client Id: ", 1);
        }
    }
}
