using System;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.CommonViews {
    public abstract class EditClientView : Menu {
        public abstract Client Client {
            get;
        }
       
        public void ViewAccounts() {
            Console.WriteLine(Container.GetDependency("AccountServices").InvokeMethod("GetAll", Client.ClientId));
        }
       
    }
}