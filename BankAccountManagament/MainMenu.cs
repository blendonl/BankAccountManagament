using System;
using BankAccountManagament.AdminsView;
using BankAccountManagament.AdminsView.ClientsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Services;

namespace BankAccountManagament {
    public class MainMenu : Menu {
       
        public void InitialiseBank() {
            if (String.IsNullOrEmpty(Bank.Admin)) {
                Common.Title("Initial");

                string bankTitle = Common.Input("Bank's name: ", 3);
                decimal initialBalance = Common.LoopMoneyInput("InitialBalance", 2);
                string admin = Common.Input("Admin's name", 3);
                string password = Common.Input("Admin's password", 3);
                decimal intresRate = Common.LoopMoneyInput("Intres Rate", 1);
                decimal provision = Common.LoopMoneyInput("Provision", 1);

                Bank.BankBalance = initialBalance;
                Bank.Admin = admin;
                Bank.AdminPassword = password;
                Bank.IntresRate = intresRate;
                Bank.Provision = provision;
                Bank.BankTitle = bankTitle;
                Console.WriteLine("All setup");
                Console.ReadLine();

            }
            
            ClientUtils.Login();

        } 
        
      
    }
    
    
    
}