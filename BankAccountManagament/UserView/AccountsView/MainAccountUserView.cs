using BankAccountManagament.CommonViews;

namespace  BankAccountManagament.UserView.AccountsView
{
    class MainAccountUserView : MainAccountView {
        public override long AccountNumber { get; }

        public MainAccountUserView(long accountNumber) {
            this.AccountNumber = accountNumber;
        }
      
    }
}
    