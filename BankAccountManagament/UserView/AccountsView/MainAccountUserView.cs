using System;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Utils;

namespace  BankAccountManagament.UserView.AccountsView
{
    class MainAccountUserView : MainAccountView {
        public override Account Account { get; }

        public MainAccountUserView(Account account) {
            this.Account = account;
        }
      
    }
}
    