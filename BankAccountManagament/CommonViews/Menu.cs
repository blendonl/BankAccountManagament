using System;
using BankAccountManagament.Utils;
using Controller;

namespace BankAccountManagament.CommonViews{
    public abstract class Menu {

        public abstract string[] Choices {
            get;
        }
        public abstract string Title { get; }

        private string a;

        
        public void Show() {
            Dependency dependency = Container.GetDependency(GetType());
            string[] methods = dependency.GetMethodsName();
            int choice = Common.Menu(GetType().Name, methods);
            
            // if(methods[choice].StartsWith("GoTo")) {
            //     dependency = Container.GetDependency(methods[choice]);
            //     dependency.InvokeMethod("Show", null);
            // }
            // else {
                dependency.InvokeMethod(methods[choice], null);
                
            // }

            Console.ReadLine();
            Show();

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
