using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.CreditCardModel;


namespace BankAccountManagamentLibrary.Services {
    public class CrediaaatCardServices {
        public bool Add(Account account, CreditCard creditCard) {
            if (account.CreditCard == null) {
                account.CreditCard = creditCard;
                return true;
            }

            return false;
        }

        public bool Remove(Account account) {
            if (account.CreditCard != null) account.CreditCard = null;
            return false;
        }

    }
}
