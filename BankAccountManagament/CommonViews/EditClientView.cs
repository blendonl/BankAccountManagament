using System;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.CommonViews {
    public abstract class EditClientView : Menu {
        public abstract string ClientId {
            get;
        }
        
        public override string[] Choices =>  new[] {
            "View All Accounts",
            "Edit Account",
            "Back",
        };
        public override string Title => "Edit Client"; 
        public override void Function1() {
            Common.Title("All Accounts");
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
        }
        public override void Function2() {
            Common.Title("Select Account");
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
            Console.WriteLine();
            long accountNumber = Common.LoopInput("Account number", 8);
            new MainAccountAdminView(accountNumber).Show();
        }
    }
}