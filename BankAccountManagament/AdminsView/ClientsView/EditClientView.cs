using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.UserView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;
using Container = BankAccountManagament.Controller.Container;

namespace BankAccountManagament.AdminsView.ClientsView {
    class ClientAdminView: EditClientView {

        public override string ClientId {
            get;
        } 
      
        public ClientAdminView(string clientId)  {
            ClientId = clientId;
        }
         public void AddAccount() {
            Common.Title("Create Account");
            Console.WriteLine(Convertor.GetAllAccountTypes());
            ClientUtils.AddAccount(ClientId);
         }
                
         public long GoToMainAccountAdminView() {
            Common.Title("Select Account");
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
            Console.WriteLine();
            long accountNumber = Common.LoopInput("Account number", 8);
            if (AccountServices.Get(accountNumber) != null) {
                return accountNumber;
            }

            return -1;
         }

       
    }
}