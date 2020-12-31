using Controller;

namespace BankAccountManagament.CommonViews {
    public abstract class EditClientView : Menu {
        public abstract string ClientId {
            get;
        }
        
        public string ViewAccounts() {
            return ClientId;
        }
       
    }
}