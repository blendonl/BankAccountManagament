﻿using System;
using BankAccountManagament.AdminsView;
using BankAccountManagament.AdminsView.ClientsView;
using BankAccountManagament.CommonViews;
using BankAccountManagament.Utils;
using BankAccountManagamentLibrary.Models;
using BankAccountManagamentLibrary.Models.ClientModel;
using BankAccountManagamentLibrary.Services;
using Controller;
using Container = System.ComponentModel.Container;

namespace BankAccountManagament {
    public class MainView : Menu {

        public void InitialiseBank() {
            //ToDO Fix Bank Initialisation
            if (String.IsNullOrEmpty(Bank.Admin)) {
                Common.Title("Initial");

                string bankTitle = Common.Input("Bank's name: ", 3);
                decimal initialBalance = Common.LoopMoneyInput("InitialBalance", 2);
                Controller.Container.GetDependency("CrudOperations").InvokeMethod("Create", typeof(Admin), null); 
                decimal intresRate = Common.LoopMoneyInput("Intres Rate", 1);
                decimal provision = Common.LoopMoneyInput("Provision", 1);

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