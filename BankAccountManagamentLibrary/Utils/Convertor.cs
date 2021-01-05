using System;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankaccountManagamentLibrary.Services;

namespace BankAccountManagamentLibrary.Utils {
    public class Convertor {
        
     

       

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
       
       
            
          
             
      
        
         public static decimal ProvisionPercentage(decimal provision) {
             return provision / 100 * 100;
         }
         
    }
}