using System;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankaccountManagamentLibrary.Services;

namespace BankAccountManagament {
    public abstract class BalanceView : Menu{
        

        public abstract Account Account {
            get;
        }

        public abstract decimal Provision {
            get;
        }
        

        public void ViewBalance() {

            Console.WriteLine("Account's balance is: " + Account.Balance + "$");

        }

     
    }
}