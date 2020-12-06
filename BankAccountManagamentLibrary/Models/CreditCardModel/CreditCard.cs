using System;
using BankAccountManagament.Models;

namespace BankAccountManagamentLibrary.Models.CreditCardModel {
    public class CreditCard {

        public string CreditCardHolderName { get; set; }
        public string CreditCardHolderLastName { get; set; }
        public long CreditCardNumber { get; set; }
        public int Cvv { get; set; }
        public int Pin { get; set; }
        public DateTime CreationDate { get; set; }
        public CreditCardType CreditCardType {get; set;}

        public string ExperationDate() {
            return (CreationDate.Year + 5) + "/" + CreationDate.Month;
        }

        public override string ToString() {
            return $"Card Number: {CreditCardNumber} Card Holder: {CreditCardHolderName} {CreditCardHolderLastName} Experation Date: {ExperationDate()} Pin {Pin} CVV: {Cvv} CreditCardType {CreditCardType.ToString()}";
        }
    }
}
