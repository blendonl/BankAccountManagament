
using System;
using BankAccountManagamentLibrary.Models;

namespace BankAccountManagament {
    class Program {
        static void Main(string[] args) {

            Type type = typeof(Loan).GetProperties()[0].PropertyType;
            new MainView().Show();
        }
    }
}