using System;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankaccountManagamentLibrary.Services;

namespace BankAccountManagament {
    public abstract class BalanceView : Menu{
        
        string[] choices = {
                "view balance",
                "deposit",
                "withdraw",
                "go back"
            };

        string title = "Balance";

        public abstract Account Account {
            get;
        }

        public abstract decimal Provision {
            get;
        }

        

        public override string[] Choices { get => choices; }
        public override string Title { get => title; }

        public override void Function1() {

            // View's balance
            Common.Title("Balance");
            Console.WriteLine("Account's balance is: " + Account.Balance + "$");

        }

        public override void Function2() {


            // titel
            Common.Title("Depositing");

            // get's amouunt from input 
            decimal amount = Common.LoopInput("Amount", 1);

            // check if the depositing was succesfully
            if (TransactionServices.Add(Account.AccountNumber, amount, TransactionType.Deposit, Provision))
                Console.WriteLine("Money deposited succesfully");
            else
                Console.WriteLine("Money couldnt be deposited");
            

        }

        public override void Function3() {

            // title
            Common.Title("WithDrawing");

            // gets amount from input
            decimal amount = Common.LoopInput("Amount", 1);

            if (TransactionServices.Add(Account.AccountNumber, amount, TransactionType.Withdraw, Provision)) 
                Console.WriteLine("Money withdrawed succesfully");
            else
                Console.WriteLine("Money couldnt be withdran");
            
        }
    }
}