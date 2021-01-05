using System;
using BankAccountManagamentLibrary.DataAccess;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankaccountManagamentLibrary.Services;

namespace BankAccountManagamentLibrary.Utils {
    public class Convertor {
        
     

       

     

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