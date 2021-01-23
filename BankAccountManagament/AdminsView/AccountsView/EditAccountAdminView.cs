using System;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using Controller;

namespace BankAccountManagament.AdminsView.AccountsView {

    class EditAccountAdminView : Menu {
        
        public Account Account; 

        public EditAccountAdminView(Account account) {
            this.Account = account;
        }
        
        public Account GoToBalanceView() {
            return Account; 
        }
     
        public Account ViewTransactions() {
             return Account;
        }
       
        public void CheckStatus() {
            string d = ""; // if is deactive it adds "de"

            if (Account.Active) { 
                Console.WriteLine(
                $"{Account.Client.Emri}'s account is active and {Account.Client.Emri}'s account balance is: {Account.Balance}");
                Console.WriteLine();
                d = "de";
            }
            else Console.WriteLine($"{Account.Active}'s account is not active");
            
            Console.Write($"Do you want to {d}activate it?(Y/N)");
            
            if(char.TryParse(Console.ReadLine(), out var choice) && (choice == 'y' || choice == 'Y')) {
                Account.ChangeStatus();
                Console.WriteLine("Status changed succesfully");
            }    
        }

        public void RequestCreditCard() {
            ClientUtils.RequestCreditCard(Account);
        }

        public void RequestLoan() {
            ClientUtils.RequestLoan(Account);
        }
      
        public void SendMoney() {
            ClientUtils.SendMoney(Account, Bank.Provision);
        }
    }
}
