using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.CreditCardModel;
using BankAccountManagamentLibrary.Utils;

namespace BankAccountManagamentLibrary.Models.AccountModel {
    public abstract class Account {

        public long AccountNumber { get; }
        public Client Client { get; set; }
        public CreditCard CreditCard { get; set; }
        public decimal Balance { get; set; }
        public bool Active {get; set;}


        public Account() {
            AccountNumber = NumberGenerator.GenerateAccountNumber();
            Active = true;
        }
        



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
            return $"AccountNumber: {AccountNumber} AccountType: {GetType().Name} Balance: {Balance} Active: {Active} ";
        }

    }
}