using System;
using BankAccountManagament.Utils;
using Controller;

namespace BankAccountManagament.CommonViews{
    public abstract class Menu {

        
        public void Show() {
            
            Dependency dependency = Container.GetDependency(GetType());
            
            string[] methods = dependency.GetMethodsName();
            
            int choice = Common.Menu(GetType().Name, methods);
            
            if(!methods[choice].Equals("GoBack")) {
                InvokeMethod(dependency, methods[choice]);
                Show();
            }
        }


        private void InvokeMethod(Dependency dependency, string method) {
            string[] methods = dependency.GetMethodsName();
            
            try {
                Common.Title(method); 
               if(method.StartsWith("GoTo")) {
               //     dependency = Container.GetDependency(methods[choice]);
               //     dependency.InvokeMethod("Show", null);
               }
               else {
                    dependency.InvokeMethod(method, null);
                    Console.ReadLine();
               }
            } catch(IndexOutOfRangeException) {} 
        }

        public void GoBack() {
        } 
        
    }
}
