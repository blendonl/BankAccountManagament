using System;
using System.Collections.Generic;
using BankAccountManagamentLibrary.Models.AccountModel;

namespace BankAccountManagamentLibrary.Models.ClientModel {
    public class Client {
        public string ClientId { get;  }
        
        public long PersonalNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateBecameClient { get;  }

        public string ToString() {
            return
                $"PersonalNumber: {PersonalNumber} Name: {Name} LastName {LastName} Email {Email} PhoneNumber: {PhoneNumber} DateBecameClinet: {DateBecameClient}";
        }
        

       

    }
}
