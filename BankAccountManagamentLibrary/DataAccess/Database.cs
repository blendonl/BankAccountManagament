using System.Collections.Generic;
using BankAccountManagament.Models;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.AccountModel;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Models.TransactionModel;

namespace BankAccountManagamentLibrary.DataAccess
{

    public static class Database {
       
        public static List<Client> Clients = new List<Client>();
        public static List<Account> Accounts = new List<Account>();
        public static List<Transaction> Transactions = new List<Transaction>();
        public static List<Loan> Loans = new List<Loan>();
    }
    
}