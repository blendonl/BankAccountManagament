using System;
using BankAccountManagament.UserView.AccountsView;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Services;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagament.CommonViews {
    public abstract class MainAccountView : Menu {


        public abstract long AccountNumber {
            get;
        }

        public override string[] Choices => new string[] {
            "go to balance",
            "go to transactions",
            "send money",
            "go back"
        }; 
        public override string Title => "Account";

        public override void Function1() {
                new BalanceUserView(AccountServices.Get(AccountNumber)).Show();

        }

        public override void Function2() {
            Common.Title("Transaction View");
            Console.WriteLine(Convertor.GetAllTransactions(AccountNumber));
        }

        public override void Function3() {
            ClientUtils.SendingMoney(AccountNumber, 0);            
        }
    }
}