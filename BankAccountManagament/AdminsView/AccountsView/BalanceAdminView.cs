using System;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankaccountManagamentLibrary.Services;
using Controller;

namespace BankAccountManagament.AdminsView.AccountsView {
    public class BalanceAdminView: BalanceView{
        public override Account Account { get; }
        public override decimal Provision => Bank.Provision;

        public BalanceAdminView(Account account) {
            this.Account = account;
        }
            
       public void Deposit() {
    
            // get's amouunt from input
            decimal amount = Common.LoopInput("Amount", 1);
    
            Transaction transaction = new Transaction() {
                Account = Account,
                Client = Account.Client,
                Amount = amount, 
                TransactionType = TransactionType.Deposit,
                Provision = Provision
                            
            };
            
            if ((bool)Container.GetDependency(typeof(TransactionServices)).InvokeMethod("Add",transaction))
                Console.WriteLine("Money deposited succesfully");
            else
                Console.WriteLine("Money couldnt be deposited");
        }
        
        public void Withdraw() {
            // gets amount from input
            decimal amount = Common.LoopInput("Amount", 1);

            Transaction transaction = new Transaction() {
                Account = Account,
                Amount = amount,
                TransactionType = TransactionType.Withdraw,
                Provision = Provision
            };

            if ((bool)Container.GetDependency("TransactionServices").InvokeMethod("Add",transaction))
                Console.WriteLine("Money withdrawed succesfully");
            else
                Console.WriteLine("Money couldnt be withdran");
        }
    }
}