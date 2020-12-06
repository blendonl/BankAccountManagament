using System;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankaccountManagamentLibrary.Services;

namespace BankAccountManagamentLibrary.Utils {
    public class Convertor {
        
        public static string GetAllClients() {
            string rez = "";

            foreach (var clinet in Database.Clients) {
                rez += clinet.ToString() + "\n";
            }
            return rez;
        }

        public static string GetAllAccounts() {
            string rez = "";

            foreach (var account in Database.Accounts) {
                rez += account.ToString() + "\n";
            }

            return rez;
        } 
        public static string GetAllAccounts(string clinetId) {
             string rez = "";
     
             foreach (var account in Database.Accounts) {
                 if(account.Client.ClientId.Equals(clinetId))
                    rez += account.ToString() + "\n";
             }
 
             return rez;
             }

        public static string GetAllTransactions() {
            string rez = "";

            foreach (var transaction in Database.Transactions) {
                rez += transaction.ToString() + "\n";
            }

            return rez;
        }
        
         public static string GetAllTransactions(long accountNumber) {
                string rez = "";
        
                foreach (var transaction in Database.Transactions) {
                    if(accountNumber == transaction.AccountNumber)
                        rez += transaction.ToString() + "\n";
                }
        
                return rez;
         } 
         public static string GetAllTransactions(string clientId) {
             string rez = "";
        
             foreach (var transaction in Database.Transactions) { 
                 if(clientId.Equals(transaction.ClientId)) 
                     rez += transaction.ToString() + "\n";
             }
             return rez;
         }

        public static string GetAllLoans() {
            string rez = "";

            foreach (var loan in Database.Loans) {
                rez += loan.ToString() + "\n";
            }

            return rez;
            
        }
        public static string GetAllLoans(string clientId) {
             string rez = "";
         
             foreach (var loan in Database.Loans) {
                 if(clientId.Equals(loan.ClientId))
                    rez += loan.ToString() + "\n";
             }
         
             return rez;
                     
         }
         public static string GetAllLoans(long accountNumber) {
             string rez = "";
         
             foreach (var loan in Database.Loans) {
                 if(accountNumber == loan.AccountNumber)
                    rez += loan.ToString() + "\n";
             }
         
             return rez;
                         
         }
         public static string GetAllAccountTypes() {
            string rez = "";
            var accountTypes =  Enum.GetValues(typeof(AccountType));
            for (int i = 0; i < accountTypes.Length; i++) {
                rez +=($"Press {i} to select {accountTypes.GetValue(i)} \n");
            }

            return rez;
         }
         
         public static decimal ProvisionPercentage(decimal provision) {
             return provision / 100 * 100;
         }
         
    }
}