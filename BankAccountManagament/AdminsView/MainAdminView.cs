using System;
using BankAccountManagament.AdminsView.ClientsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView {
    public class MainAdminView: Menu {

        public void ViewBalance() {
            Console.WriteLine($"Banks Balance is: {Bank.BankBalance}");
            Console.WriteLine($"All account balance is {BankServices.GetALlClientsMoney()}");
            Console.WriteLine($"All: {Bank.BankBalance + BankServices.GetALlClientsMoney()}");
        }

        public void GoToMainClientsView() {
        }

        public void ViewTransactions() {
            Console.WriteLine(Convertor.GetAllTransactions());
        }

        public void ViewLoans() {
            Console.WriteLine(Convertor.GetAllLoans());
        }
    }
}