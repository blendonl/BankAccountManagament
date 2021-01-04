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
     
        public EditClientAdminView(string clientId)  {
            ClientId = clientId;
        }
         public void CreateAccount() { 
             Console.WriteLine(Convertor.GetAllAccountTypes()); 
             ClientUtils.AddAccount(ClientId);
         }
                
         public void SelectAccount() {
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
            Console.WriteLine();
            long accountNumber = Common.LoopInput("Account number", 8);
            new MainAccountAdminView(accountNumber).Show();
         }

       
    }
}