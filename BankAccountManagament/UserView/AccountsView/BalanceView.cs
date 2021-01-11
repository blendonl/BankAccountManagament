using System;
using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankaccountManagamentLibrary.Services;
using Controller;

namespace BankAccountManagament {
    public class BalanceView : Menu{
        

        public virtual Account Account {
            get;
        }

      

        public void ViewBalance() {

            Console.WriteLine("Account's balance is: " + Account.Balance + "$");

        }

     
    }
}