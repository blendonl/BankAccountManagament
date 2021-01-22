using System;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using Controller;
using Controller.Models;
using Controller.Utils;

namespace BankAccountManagament {
    public class MainView : Menu {

        public void Login() {
            if (Bank.BankBalance == 0) {
                CommonViews.Title("Initialise Bank");
                
                Bank.BankTitle = CommonViews.Input("Bank's name: ", 3); 
                Bank.BankBalance = CommonViews.LoopInput<decimal>("InitialBalance", 2);
                Bank.IntresRate = CommonViews.LoopInput<decimal>("Intres Rate", 1);
                Bank.Provision = CommonViews.LoopInput<decimal>("Provision", 1);
                
                Container.GetDependency("CrudOperations").InvokeMethod("Create", typeof(Administrator), null); 
              
                Console.WriteLine("\nAll setup");
                Console.ReadLine();

            }

            ClientUtils.Login();

        }

    }
}