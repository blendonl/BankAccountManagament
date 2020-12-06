using System;
using System.Runtime.InteropServices;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.UserView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView.ClientsView {
    class EditClientAdminView: EditClientView {

        public override string ClientId {
            get;
        } 
        public override string[] Choices {
            get {
                return new[] {
                    "View All Accounts",
                    "Add Account",
                    "Edit Account",
                    "Back",
                };
            }
        }

        public EditClientAdminView(string clientId)  {
            ClientId = clientId;
        }
         public override void Function2() {
                    Common.Title("Create Account");
                    Console.WriteLine(Convertor.GetAllAccountTypes());
                    ClientUtils.AddAccount(ClientId);
         }
                
         public override void Function3() {
            Common.Title("Select Account");
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
            Console.WriteLine();
            long accountNumber = Common.LoopInput("Account number", 8);
            new MainAccountAdminView(accountNumber).Show();
         }

       
    }
}