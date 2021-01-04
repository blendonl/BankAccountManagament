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

        public void Deposit() {

            // get's amouunt from input 
            decimal amount = Common.LoopInput("Amount", 1);

            // check if the depositing was succesfully
            if (TransactionServices.Add(Account.AccountNumber, amount, TransactionType.Deposit, Provision))
                Console.WriteLine("Money deposited succesfully");
            else
                Console.WriteLine("Money couldnt be deposited");
            

        }

        public void Withdraw() {

            // gets amount from input
            decimal amount = Common.LoopInput("Amount", 1);

            if (TransactionServices.Add(Account.AccountNumber, amount, TransactionType.Withdraw, Provision)) 
                Console.WriteLine("Money withdrawed succesfully");
            else
                Console.WriteLine("Money couldnt be withdran");
            
        }
    }
}