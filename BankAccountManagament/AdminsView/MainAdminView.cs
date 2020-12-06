using System;
using BankAccountManagament.AdminsView.ClientsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView {
    public class MainAdminView: Menu {
        public override string[] Choices => new[] {
                "to check Balance",
                "to go to clients",
                "to view all Transactions",
                "to view all Loans",
                "to go back"
        };

        public override string Title => "Main";

        public override void Function1() {
            Console.WriteLine($"Banks Balance is: {Bank.BankBalance}");
            Console.WriteLine($"All account balance is {BankServices.GetALlClientsMoney()}");
            Console.WriteLine($"All: {Bank.BankBalance + BankServices.GetALlClientsMoney()}");
        }

        public override void Function2() {
            new MainClientsView().Show();
        }

        public override void Function3() {
            Common.Title("Transactions");
            Console.WriteLine(Convertor.GetAllTransactions());
        }

        public override void Function4() {
            Common.Title("Loans");
            Console.WriteLine(Convertor.GetAllLoans());
        }
    }
}