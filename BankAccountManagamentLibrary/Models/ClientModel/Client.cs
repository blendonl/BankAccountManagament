using System;

namespace BankAccountManagamentLibrary.Models.ClientModel {
    public abstract class Client : Personi.Personi {
        public string ClientId { get; }
        public string Password { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateBecameClient { get; }

        private static int count;
        public Client() {
            ClientId = count++.ToString();
            PersoniId = count;
            DateBecameClient = DateTime.Now;
        }

        public override string ToString() {
            return
                $"ClientId: {ClientId} " +
                $"ClientType: {GetType().Name} " + 
                $"PersonalNumber: {NrPersonal} " +
                $"Name: {Emri} {Mbiemri} " +
                $"Email {Email} " +
                $"Address: {Address}" +
                $"PhoneNumber: {PhoneNumber} " +
                $"DateBecameClinet: {DateBecameClient}";
        }
        

       

    }
}
