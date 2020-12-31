
using System;
using BankAccountManagament.Models;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.CreditCardModel;

namespace BankAccountManagamentLibrary.Models.AccountModel {
    public class Account {

        public long AccountNumber { get; set; }
        public Client Client { get; set; }
        public AccountType AccountType { get; set; }
        public CreditCard CreditCard { get; set; }
        public decimal Balance { get; set; }
        public bool Active {get; set;}
     
        public bool Deposit(decimal amount, decimal provision) {
            if(Active) {
                Balance += (amount - provision);
                return true;
            }   
            return false;
        }

        public bool WithDraw(decimal amount, decimal provision) {
            if (!Active) return false;
            if ((amount + provision) > Balance) return false;
            Balance -= (amount + provision);
            return true;
        }

        public void ChangeStatus() {
            this.Active = !this.Active;
        }


        public override string ToString()
        {
            return $"AccountNumber: {AccountNumber} AccountType: {AccountType} Balance: {Balance} Active: {Active} ";
        }

    }
}