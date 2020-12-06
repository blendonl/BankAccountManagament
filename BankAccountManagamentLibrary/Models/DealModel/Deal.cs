using System;

namespace BankAccountManagamentLibrary.Models.DealModel {
    public class Deal {
       public decimal Interes { get; set; }
       public decimal Amount { get; set; }
       public DateTime ExperationDate { get; set; }

       public override string ToString() {
           return $"Interes {Interes} Amount {Amount} ExperationDate: {ExperationDate.Date}";
       }
    }
}