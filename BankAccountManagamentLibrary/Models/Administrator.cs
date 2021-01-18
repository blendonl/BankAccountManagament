
namespace BankAccountManagamentLibrary.Models {
    public class Administrator : Personi.Personi {
        public string Password { get; set; }
        public int A { get; set; }
        public decimal B { get; set; }

        public Administrator() {
            PersoniId = 0;
        }
    }
}