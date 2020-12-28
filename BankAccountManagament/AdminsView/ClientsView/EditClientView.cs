using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using BankAccountManagament.AdminsView.AccountsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.UserView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.AdminsView.ClientsView {
    class ClientAdminView: EditClientView {

        public override string ClientId {
            get;
        } 
      
        public ClientAdminView(string clientId)  {
            ClientId = clientId;
        }
         public void AddAccount() {
            Console.WriteLine(Convertor.GetAllAccountTypes());
            ClientUtils.AddAccount(ClientId);
         }
                
         public long GoToMainAccountAdminView() {
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