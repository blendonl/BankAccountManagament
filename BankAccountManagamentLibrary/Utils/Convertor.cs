
namespace BankAccountManagamentLibrary.Utils {
    public class Convertor {
      
        
         public static decimal ProvisionPercentage(decimal provision) {
             return provision / 100 * 100;
         }
         
    }
}