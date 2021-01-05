using System;
using BankAccountManagament.UserView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.CommonViews {
    public abstract class MainAccountView : Menu {


        public abstract Account Account {
            get;
        }


        public void ViewTransactions() {
            Console.WriteLine(Convertor.GetAllTransactions(Account.AccountNumber));
        }

        public void SendMoney() {
            ClientUtils.SendingMoney(Account, 0);            
        }
    }
}