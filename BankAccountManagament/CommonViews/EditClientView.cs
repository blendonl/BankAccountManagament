using System;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Utils;
using Container = BankAccountManagament.Controller.Container;

namespace BankAccountManagament.CommonViews {
    public abstract class EditClientView : Menu {
        public abstract string ClientId {
            get;
        }
        
       
        public void ViewAccounts() {
            Common.Title("All Accounts");
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
        }
        public void SelectAccount() {
            Common.Title("Select Account");
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
            Console.WriteLine();
            long accountNumber = Common.LoopInput("Account number", 8);
            Container.GetDependency("MainAccuntAdminView", new[] {accountNumber.ToString()}).InvokeMethod("Show", null);
        }
    }
}