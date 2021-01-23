using System;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankaccountManagamentLibrary.Services;
using Controller;
using Controller.Models;
using Controller.Utils;

namespace BankAccountManagament.AdminsView.AccountsView {
    public class BalanceView: Menu {
        
        public Account Account; 

        public BalanceView(Account account) {
            Account = account;
        }

        public void ViewBalance() {
            Console.WriteLine($"Account's balance is {Account.Balance}$");
        }
        
        public void Deposit() {
            
            decimal amount = CommonViews.LoopInput<decimal>("Amount", 1);
    
            ITransaction transaction = new Deposit() {
                Account = Account,
                Amount = amount, 
                Provision = Bank.Provision
            };

           transaction.MakeTransaction();
            
            if ((bool)(Container.GetDependency(typeof(TransactionServices)).InvokeMethod("Add", transaction) ?? false))
                Console.WriteLine("Money deposited succesfully");
            else
                Console.WriteLine("Money couldnt be deposited");
        }
        
        public void Withdraw() {
            
            decimal amount = CommonViews.LoopInput<decimal>("Amount", 1);

            ITransaction transaction = new WithDraw() {
                Account = Account,
                Amount = amount,
                Provision = Bank.Provision
            };

            transaction.MakeTransaction();

            if ((bool)(Container.GetDependency(typeof(TransactionServices)).InvokeMethod("Add", transaction) ?? false))
                Console.WriteLine("Money withdrawed succesfully");
            else
                Console.WriteLine("Money couldnt be withdran");
        }
    }
}