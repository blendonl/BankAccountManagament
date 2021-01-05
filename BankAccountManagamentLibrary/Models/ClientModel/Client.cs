using System;

namespace BankAccountManagamentLibrary.Models.ClientModel {
    public abstract class Client {
        public string ClientId { get; }
        public long PersonalNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateBecameClient { get; }

        private static int count;
        public Client() {
            ClientId = count++.ToString();
            DateBecameClient = DateTime.Now;
        }

        public string ToString() {
            return
                $"ClientId: {ClientId} " +
                $"ClientType: {GetType().Name} " + 
                $"PersonalNumber: {PersonalNumber} " +
                $"Name: {Name} LastName {LastName} " +
                $"Email {Email} " +
                $"PhoneNumber: {PhoneNumber} " +
                $"DateBecameClinet: {DateBecameClient}";
        }
        

       

    }
}
