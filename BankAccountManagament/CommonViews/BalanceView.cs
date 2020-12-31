using System;
using BankAccountManagamentLibrary.Models.AccountModel;
using Controller;

namespace BankAccountManagament.CommonViews {
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