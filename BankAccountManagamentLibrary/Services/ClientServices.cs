using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;

namespace BankAccountManagamentLibrary.Services {
    public static class ClientServices {

        private static int count;
        public static bool Add(long personalNumber, string name, string lastName, string password, string address, long phoneNumber, string email) {
            if (FindIndex(personalNumber) == -1 ) {
                Client client = new Client(){
                    PersonalNumber = personalNumber,
                    Name = name,
                    LastName = lastName,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Password = password,
                    ClientId = count++.ToString(),
                    DateBecameClient = new DateTime()
                };
                Database.Clients.Add(client);
                return true;
            }
            return false;
        }


     

        public static bool Remove(string clientId) {
            int index = FindIndex(clientId);
            if (index != -1) {
                Database.Clients.Remove(Database.Clients[index]);
                return true;
            }
            return false;
        }

        public static int FindIndex(string clientId) {
            return Database.Clients.FindIndex(client => client.ClientId.Equals(clientId));
        }

        private static int FindIndex(long personalNumber) {
            return Database.Clients.FindIndex(client => client.PersonalNumber == personalNumber);
        }

       

        public static Client Get(string clientId) {
            int index = FindIndex(clientId);
            return (index != -1) ? Database.Clients[index] : null;
        }
       
    }
}
