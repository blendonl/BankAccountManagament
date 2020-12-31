using System;
using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Utils;
using Controller;

namespace BankAccountManagament.AdminsView.ClientsView {
    class ClientAdminView: EditClientView {

        public override string ClientId {
            get;
        } 
      
        public ClientAdminView(string clientId)  {
            ClientId = clientId;
        }
         public string CreateAccount() {
            Console.WriteLine(Convertor.GetAllAccountTypes());
            return ClientId;
         }
                
         public long GoToMainAccountAdminView() {
            Console.WriteLine(Convertor.GetAllAccounts(ClientId));
            Console.WriteLine();
            return Common.LoopInput("Account number", 8);
             
         }
    }
}