using Controller;

namespace BankAccountManagament.CommonViews {
    public abstract class MainAccountView : Menu {


        public abstract long AccountNumber {
            get;
        }


        public long ViewTransactions() {
            return AccountNumber;
        }

    }
}