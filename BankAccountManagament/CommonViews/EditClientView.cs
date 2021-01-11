using System;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Utils;
using Controller;

namespace BankAccountManagament.CommonViews {
    public abstract class EditClientView : Menu {
        public abstract Client Client {
            get;
        }
       
        public Client ViewAccounts() {
            //TODO Fix viewing accounts
           // Console.WriteLine(Container.GetDependency("AccountServices").InvokeMethod("GetAll", Client.ClientId));
           return Client;
        }
       
    }
}