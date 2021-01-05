using System;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.UserView.AccountsView;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;
using Controller;

namespace BankAccountManagament.UserView {
    class EditClientUserView : EditClientView {
        public override Client Client { get; }

        public EditClientUserView(Client client) {
            this.Client = client;
        }
        public long GoToMainAccountUserView() {
            Console.WriteLine(Container.GetDependency("AccountServices").InvokeMethod("GetAll", Client.ClientId));
            Console.WriteLine();
              long accountNumber = Common.LoopInput("Account number", 8);
              return accountNumber; 
        }

    }
}
