using System;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Services;
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
          
        }

        public void ViewLoans() {
          
        }
    }
}