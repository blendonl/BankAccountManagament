using System;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.CommonViews {
    public abstract class EditClientView : Menu {
        public abstract string ClientId {
            get;
        }
       
        public void ViewAccounts() {
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
        }
        public void SelectAccount() {
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
            Console.WriteLine();
            long accountNumber = Common.LoopInput("Account number", 8);
            new MainAccountAdminView(accountNumber).Show();
        }
    }
}