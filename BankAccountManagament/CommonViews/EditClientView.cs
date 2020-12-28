using System;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Utils;
using Container = BankAccountManagament.Controller.Container;

namespace BankAccountManagament.CommonViews {
    public abstract class EditClientView : Menu {
        public abstract string ClientId {
            get;
        }
        
        public void ViewAccounts() {
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
        }
       
    }
}