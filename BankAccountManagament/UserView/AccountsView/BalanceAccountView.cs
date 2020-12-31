using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagament.UserView.AccountsView {

    public class BalanceUserView : BalanceView {
        
        
        public override Account Account { get; }

        public BalanceUserView(Account account) {
            this.Account = account;
        }

        public override decimal Provision => 0;
    }
}
