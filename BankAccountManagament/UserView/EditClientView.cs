using System;
using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Utils;
using Controller;

namespace BankAccountManagament.UserView {
    class EditClientUserView : EditClientView {
        public override string ClientId { get; }

        public EditClientUserView(string clientId) {
            this.ClientId = clientId;
        }
        public long GoToMainAccountView() {
              Console.WriteLine(Convertor.GetAllAccounts(ClientId));
              Console.WriteLine();
              return Common.LoopInput("Account number", 8);
        }

    }
}
