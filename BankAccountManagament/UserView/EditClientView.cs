using System;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Controller;
using BankAccountManagament.UserView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.UserView {
    class EditClientUserView : EditClientView {
        public override string ClientId { get; }

        public EditClientUserView(string clientId) {
            this.ClientId = clientId;
        }
        public void SelectAccount() {
              Common.Title("Select Account");
              Console.WriteLine(Convertor.GetAllAccounts(ClientId));
              Console.WriteLine();
              long accountNumber = Common.LoopInput("Account number", 8);
              
              Container.GetDependency("MainAccountView", new[] {accountNumber.ToString()}).InvokeMethod("Show", null);
        }

    }
}
