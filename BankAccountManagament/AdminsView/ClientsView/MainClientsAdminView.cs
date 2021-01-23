using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;
using Controller.Models;
using Controller.Utils;

namespace BankAccountManagament.AdminsView.ClientsView {
   class MainClientsAdminView : Menu {
        
        public void ViewClients() {
        } 
        public void CreateClient() { 
           
        }

        public int GoToEditClientAdminView() {
            Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Client), null);
            return CommonViews.LoopInput<int>("Client Id: ", 1);
            
        }

        public int RemoveClient() {
            Container.GetDependency("CrudOperations").InvokeMethod("View", typeof(Client), null);
            
            return CommonViews.LoopInput<int>("Client Id: ", 1);
        }
    }
}
