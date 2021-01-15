
namespace BankAccountManagamentLibrary.Models {
    public class Administrator : Personi.Personi {
        public string Password { get; set; }

        public Administrator() {
            PersoniId = 0;
        }
    }
}