using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagament.AdminsView.AccountsView {
    public class BalanceAdminView: BalanceView{
        public override Account Account { get; }
        public override decimal Provision => Bank.Provision;

        public BalanceAdminView(Account account) {
            this.Account = account;
        }

    }
}