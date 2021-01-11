using System;
using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Models.ClientModel;
using Controller;

namespace BankAccountManagament.UserView {
    class EditClientUserView : EditClientView {
        public override Client Client { get; }

        public EditClientUserView(Client client) {
            this.Client = client;
        }
        public long GoToMainAccountUserView() {
            Console.WriteLine(Container.GetDependency("AccountServices").InvokeMethod("GetAll", Client.ClientId));
            Console.WriteLine();
              long accountNumber = Common.LoopInput("Account number", 8);
              return accountNumber; 
        }

    }
}
