using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;

namespace BankAccountManagamentLibrary.Services {
    public class ClientServices {
        private List<Client> Clients;

        public ClientServices() {
            Clients = new List<Client>();
        }

        public bool Add(Client client) {
            if (FindIndex(client.PersonalNumber) == -1 ) {
                Clients.Add(client);
                return true;
            }
            return false;
        }


     

        public bool Remove(string clientId) {
            int index = FindIndex(clientId);
            if (index != -1) {
                Clients.Remove(Clients[index]);
                return true;
            }
            return false;
        }

        public int FindIndex(string clientId) {
            return Clients.FindIndex(client => client.ClientId.Equals(clientId));
        }

        private int FindIndex(long personalNumber) {
            return Clients.FindIndex(client => client.PersonalNumber == personalNumber);
        }

       

        public Client Get(string clientId) {
            int index = FindIndex(clientId);
            return (index != -1) ? Clients[index] : null;
        }
        
        
        public string GetAll() { 
            string rez = "";
        
            foreach (var clinet in Clients) {
                rez += clinet.ToString() + "\n";
            }
            return rez;
        }
    }
}
