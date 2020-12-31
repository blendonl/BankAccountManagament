using System;
using BankAccountManagament.CommonViews;
using BankAccountManagamentLibrary.Models.AccountModel;


namespace BankAccountManagament.AdminsView.AccountsView {

    class MainAccountAdminView: MainAccountView {
        public override long AccountNumber { get; }

        public MainAccountAdminView(long accountNumber) {
            this.AccountNumber = accountNumber;
        }
       
        public void GoToBalanceAdminView() {
        }

        public void CheckStatus() { 
            string d = ""; // if is deactive it adds "de"

            Account account = null; //AccountServices.Get(AccountNumber);
            if (account.Active) { 
                Console.WriteLine(
                $"{account.Client.Name}'s account is active and {account.Client.Name}'s account balance is: {account.Balance}");
                Console.WriteLine();
                d = "de";
            }
            else Console.WriteLine($"{account.Active}'s account is not active");
            
            Console.Write($"Do you want to {d}activated it?(Y/N)");
        
            char choice; 
            if(char.TryParse(Console.ReadLine(), out choice) && (choice == 'y' || choice == 'Y')) {
                account.ChangeStatus();
                Console.WriteLine("Status changed succesfully");
            } 
        }
        //
        // public void AddCreditCard() {
        //     if (AccountServices.Get(AccountNumber).CreditCard == null) { 
        //          Console.Write("Do you want to request a credit card (Y/N): ");
        //          char c = char.Parse(Console.ReadLine());
        //          if (c == 'y' || c == 'Y') {
        //             // Common.PrintCreditCardTypes();
        //              CreditCardType creditCardType = (CreditCardType) Common.LoopInput("Choose: ", 0);
        //              CreditCardServices.Add(AccountNumber, creditCardType);
        //              Console.WriteLine("Credit card added succesfully");
        //          }
        //     }
        //     else Console.WriteLine(AccountServices.Get(AccountNumber).CreditCard.ToString());
        // }
        //
        // public void SendMoney() {
        //     Console.WriteLine(Convertor.GetAllAccounts());
        //     Console.WriteLine();
        //     
        //     long accountNumber1 = Common.LoopInput("Account's number", 0);
        //     decimal amount = Common.LoopMoneyInput("Amount", 1);
        //  
        //     if (TransactionServices.Add(AccountNumber, accountNumber1, amount, Bank.Provision)) {
        //         Console.WriteLine("Money sended succesfully");
        //     }
        //     else {
        //         Console.WriteLine("Money couldnt be sended");
        //     }
        // }
        //
        // public void Loan() {
        //     if (LoanServices.Get(AccountNumber) == null) {
        //          AddLoan(AccountNumber); 
        //     }
        //     else {
        //         Loan loan= LoanServices.Get(AccountNumber);
        //         Console.WriteLine("Loan Status: " + loan.ToString());
        //         if (loan.Paid < loan.Amount) {
        //             Console.Write("Do you want to make a payment: (Y/N) ");
        //             char c = char.Parse(Console.ReadLine());
        //             if (c == 'Y' || c == 'y') {
        //                 LoanServices.MonthlyFee(loan.AccountNumber);
        //                 AccountServices.Get(loan.AccountNumber).WithDraw(loan.MonthlyFee(), 0);
        //                 Console.WriteLine("Succesfully");
        //             }
        //         }
        //         else {
        //             AddLoan(AccountNumber);
        //         }
        //     }
        //
        // }
        //     
        // private static void AddLoan(long accountNumber) { 
        //     decimal amount = Common.LoopInput("Amount you want to loan", 1);
        //     long months = Common.LoopInput("Months you want to pay", 1);
        //
        //     if (LoanServices.Add(accountNumber, amount, (int) months, Bank.IntresRate)) {
        //         Console.WriteLine("Loan added succesfully");
        //         Console.WriteLine($"You will have to pay {LoanServices.Get(accountNumber).MonthlyFee()} each month");
        //     }
        //     else Console.WriteLine("You cannot loan this amount");
        // }
        //
        // public void RemoveAccount() {
        //
        //     if (AccountServices.Remove(AccountNumber))
        //        Console.WriteLine("Account removed succesfully");
        //     else
        //         Console.WriteLine("Account dose not exists");
        //
        // }
    }
}
