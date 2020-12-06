using System;
using BankAccountManagament.Utils;

namespace BankAccountManagament.CommonViews{
    public abstract class Menu {

        public abstract string[] Choices {
            get;
        }
        public abstract string Title { get; }

        private string a;

        
        public void Show() {
            Console.ReadLine();
            int choice = Common.Menu(Title, Choices);

            try {
                switch (choice) {
                    case 0:
                        Function1();
                        Show();
                        break;
                    case 1:
                        Function2();
                        Show();
                        break;
                    case 2:
                        Function3();
                        Show();
                        break;
                    case 3:
                        Function4();
                        Show();
                        break;
                    case 4:
                        Function5();
                        Show();
                        break;
                    case 5:
                        Function6();
                        Show();
                        break;
                    case 6:
                        Function7();
                        Show();
                        break;
                    case 7:
                        break;
                    default:
                        Show();
                        break;
                }
            }
            catch (NotImplementedException e) {
                Show();
            }

        }

        public virtual void Function1() {
            throw new NotImplementedException();
        }

        public virtual void Function2() {

            throw new NotImplementedException();

        }

        public virtual void Function3() {
            throw new NotImplementedException();
        }

        public virtual void Function4() {
            throw new NotImplementedException();
        }

        public virtual void Function5() {
            throw new NotImplementedException();
        }

        public virtual void Function6() {
            throw new NotImplementedException();

        } 
        public virtual void Function7() {
            throw new NotImplementedException();
         
        }
    }
}
