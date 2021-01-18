using System;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.TransactionModel;
using Controller;

namespace BankAccountManagament.UserView.AccountsView {
    public class MainAccountView : Menu {


        public virtual Account Account {
            get;
        }

        public Account ViewTransactions() {
            //TODO Fix viewing Transactions
            //Console.WriteLine(Container.GetDependency(typeof(TransactionServices)).InvokeMethod("GetAll", Account));
            return Account;
        }

        public void SendMoney() {
            CrudOperations.View<Account>();
            Console.WriteLine();
            Account account1 = (Account)CrudOperations.Select<Account>(Common.LoopInput("Account's number", 0));
            decimal amount = Common.LoopMoneyInput("Amount", 1);

            if (account1 != null) {

                Transaction transaction = new Transaction() {
                    Account = Account,
                    Account1 = account1,
                    Amount = amount,
                    Client = Account.Client,
                    Client1 = Account.Client,
                    TransactionType = TransactionType.Send,
                    Provision = 0
                };

                if ((bool) Container.GetDependency(typeof(Transaction)).InvokeMethod("Add", transaction)) {
                    Console.WriteLine("Money sended succesfully");
                }
                else {
                    Console.WriteLine("Money couldnt be sended");
                }
            }
            else {
                Console.WriteLine("Account does not exists");
            }
        }
    }
}