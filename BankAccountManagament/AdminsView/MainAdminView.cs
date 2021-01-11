using System;
using BankAccountManagament.AdminsView.ClientsView;
using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;
using Controller;

namespace BankAccountManagament.AdminsView {
    public class MainAdminView: Menu {
      

        public void ViewBalance() {
            Console.WriteLine($"Banks Balance is: {Bank.BankBalance}");
            Console.WriteLine($"All account balance is {BankServices.GetALlClientsMoney()}");
            Console.WriteLine($"All: {Bank.BankBalance + BankServices.GetALlClientsMoney()}");
        }

        public void GoToMainClientsAdminView() {
        }

        public void ViewTransactions() {
            //TODO Fixing getting all transactions
           // Console.WriteLine(Container.GetDependency("TransactionServices").InvokeMethod("GetAll", null));
        }

        public void ViewLoans() {
            //TODO Fix getting all lo
           // Console.WriteLine(Convertor.GetAllLoans());
        }
    }
}