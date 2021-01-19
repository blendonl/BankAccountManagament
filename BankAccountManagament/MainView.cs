using System;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using Controller;


namespace BankAccountManagament {
    public class MainView : Menu {

        public void Login() {
            //ToDO Fix Bank Initialisation
            Common.Title("Initialise Bank");
            if (Bank.BankBalance == 0) {
                
                string bankTitle = Common.Input("Bank's name: ", 3);
                decimal initialBalance = Common.LoopInput<decimal>("InitialBalance", 2);
                decimal intresRate = Common.LoopInput<decimal>("Intres Rate", 1);
                decimal provision = Common.LoopInput<decimal>("Provision", 1);
                Container.GetDependency("CrudOperations").InvokeMethod("Create", typeof(Administrator), null); 

                Bank.BankBalance = initialBalance;
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