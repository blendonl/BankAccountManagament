using System;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Utils;

namespace  BankAccountManagament.UserView.AccountsView
{
    class MainAccountUserView : MainAccountView {
        public override long AccountNumber { get; }

        public MainAccountUserView(long accountNumber) {
            this.AccountNumber = accountNumber;
        }
      
    }
}
    