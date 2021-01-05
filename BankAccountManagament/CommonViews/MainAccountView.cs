using System;
using System.Transactions;
using BankAccountManagament.UserView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankaccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.CommonViews {
    public abstract class MainAccountView : Menu {


        public abstract Account Account {
            get;
        }


        public void ViewTransactions() {
            Console.WriteLine(Container.GetDependency(typeof(TransactionServices)).InvokeMethod("GetAll", Account));
        }

        public void SendMoney() {
            ClientUtils.SendingMoney(Account, 0);            
        }
    }
}