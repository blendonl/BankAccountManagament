using System;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using BankaccountManagamentLibrary.Services;

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
    
            // check if the depositing was succesfully
            if (TransactionServices.Add(Account, amount, TransactionType.Deposit, Provision))
                Console.WriteLine("Money deposited succesfully");
            else
                Console.WriteLine("Money couldnt be deposited");
        }
        
        public void Withdraw() {
            // gets amount from input
            decimal amount = Common.LoopInput("Amount", 1);

            if (TransactionServices.Add(Account, amount, TransactionType.Withdraw, Provision)) 
                Console.WriteLine("Money withdrawed succesfully");
            else
                Console.WriteLine("Money couldnt be withdran");
        }
    }
}