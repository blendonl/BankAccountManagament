using System;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models.AccountModel;
using Controller;

namespace BankAccountManagament.UserView {
    public class MainAccountView : Menu {

        public Account Account; 

        public MainAccountView(Account account) {
            Account = account;
        }

        public void ViewBalance() {
            Console.WriteLine("Account's balance is: " + Account.Balance + "$");
        }

        public void RequestCreditCard() { 
            ClientUtils.RequestCreditCard(Account); 
        }

        public void RequestLoan() {
            ClientUtils.RequestLoan(Account);
        }
        
        public Account ViewTransactions() {
            return Account;
        }

        public void SendMoney() { 
            if(ClientUtils.SendMoney(Account, 0))
                Console.WriteLine("Money send succesfully");
            else {
                Console.WriteLine("Money could not be sended");
            }
        } 
    }
}