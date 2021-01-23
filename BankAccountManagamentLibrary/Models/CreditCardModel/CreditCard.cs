using System;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagamentLibrary.Models.CreditCardModel {
    public class CreditCard {

        public Client Client { get; set; } 
        public long CreditCardNumber { get;  }
        public int _Cvv { get; set; }
        public int _Pin { get; set; }
        public DateTime CreationDate { get; }
        public CreditCardType CreditCardType {get; set;}


        public CreditCard() {
            CreditCardNumber = NumberGenerator.GenerateCreditCardNumber(16, 4);
            _Cvv = NumberGenerator.GenerateCvv();
            _Pin = NumberGenerator.GeneratePin();
            CreationDate = DateTime.Now;
        }
        
        
        public string ExperationDate() {
            return (CreationDate.Year + 5) + "/" + CreationDate.Month;
        }

        public override string ToString() {
            return $"Card Number: {CreditCardNumber} " +
                   $"Card Holder: {Client.Emri} {Client.Mbiemri} " +
                   $"Experation Date: {ExperationDate()} " +
                   $"_Pin {_Pin} " +
                   $"CVV: {_Cvv} " +
                   $"CreditCardType {CreditCardType.ToString()}";
        }
    }
}
