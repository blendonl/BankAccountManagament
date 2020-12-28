using System;
using BankAccountManagament.UserView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.CommonViews {
    public abstract class MainAccountView : Menu {


        public abstract long AccountNumber {
            get;
        }

        public void GoToBalance() {

        }

        public void ViewTransactions() {
            Common.Title("Transaction View");
            Console.WriteLine(Convertor.GetAllTransactions(AccountNumber));
        }

        public void SendMoney() {
            
            ClientUtils.SendingMoney(AccountNumber, 0);            
        }
    }
}