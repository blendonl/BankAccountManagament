using Controller;

namespace BankAccountManagament.AdminsView.ClientsView {
    class MainClientsView : Menu {

        public void CreateClient() {
        }

        public string GoToClientAdminView() {
            return Common.Input("Client Id: ", 1);
        }

        public string RemoveClient() {
            return Common.Input("Client Id: ", 1);
        }

        public void ViewClients() {
        }
    }
}
