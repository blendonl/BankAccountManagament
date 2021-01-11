using System;
using BankAccountManagament.Models;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagamentLibrary.Models.CreditCardModel {
    public class CreditCard {

        public Client Client { get; set; } 
        public long CreditCardNumber { get;  }
        public int Cvv { get; }
        public int Pin { get; }
        public DateTime CreationDate { get; }
        public CreditCardType CreditCardType {get; set;}


        public CreditCard() {
            CreditCardNumber = NumberGenerator.GenerateCreditCardNumber(16, 4);
            Cvv = NumberGenerator.GenerateCvv();
            Pin = NumberGenerator.GeneratePin();
            CreationDate = DateTime.Now;
        }
        
        
        public string ExperationDate() {
            return (CreationDate.Year + 5) + "/" + CreationDate.Month;
        }

        public override string ToString() {
            return $"Card Number: {CreditCardNumber} Card Holder: {Client.Emri} {Client.Mbiemri} Experation Date: {ExperationDate()} Pin {Pin} CVV: {Cvv} CreditCardType {CreditCardType.ToString()}";
        }
    }
}
