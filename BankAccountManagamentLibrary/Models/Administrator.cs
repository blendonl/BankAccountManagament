
namespace BankAccountManagamentLibrary.Models {
    public class Administrator : Personi.Personi {
        public string Password { get; set; }

        public Administrator() {
            PersoniId = 0;
        }

        public override string ToString() {
            return base.ToString() + "\n ClientType: Administrator";
        }
    }
}