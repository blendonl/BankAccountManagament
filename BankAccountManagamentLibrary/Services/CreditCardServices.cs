using System;
using BankAccountManagament.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.CreditCardModel;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagamentLibrary.Services {
    public static class CreditCardServices {

        public static bool Add(Account account, CreditCardType creditCardType ) {
            if(account.CreditCard == null) {
                account.CreditCard = new CreditCard() {
                    CreditCardHolderName = account.Client.Name,
                    CreditCardHolderLastName = account.Client.LastName,
                    CreditCardType = creditCardType,
                    CreditCardNumber = NumberGenerator.GenerateCreditCardNumber(16, (int)creditCardType),
                    CreationDate = new DateTime(),
                    Cvv = NumberGenerator.GenerateCvv(),
                    Pin = NumberGenerator.GeneratePin(),
                };
                return true;
            }
            return false;
        }

        public static bool Remove(Account account) {
            if (account.CreditCard != null) account.CreditCard = null;
            return false;
        }


    }
}
