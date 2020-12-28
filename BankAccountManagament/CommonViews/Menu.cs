using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using BankAccountManagament.Controller;
using BankAccountManagament.Utils;

namespace BankAccountManagament.CommonViews{
    public abstract class Menu {

        public void Show(params object[] parms) {

            Console.Clear();
            Dependency dependency; 
            
            if (parms != null) {
                dependency = Container.GetDependency(GetType().Name, parms);
            }
            else {
               dependency = Container.GetDependency(GetType().Name);
            }

            int choice = Common.Menu(GetType().Name, dependency.GetMethodsName());
            string methodName = dependency.GetMethodName(choice);

            if (methodName.StartsWith("GoTo")) {
                try {
                    object parm = null;

                    if (!dependency.GetMethod(methodName).ReturnType.Name.Equals("Void")) {
                        parm = (object) dependency.InvokeMethod(methodName, null);
                    }

                    Container.GetDependency(methodName.Remove(0, 4), (parm != null) ? new[] {parm} : null)
                        .InvokeMethod("Show", new[] {parm});
                }
                catch (TargetParameterCountException) {
                    Console.WriteLine("Does not exits");
                }
            }
            else 
                dependency.InvokeMethod(methodName, null);
            
            Console.ReadLine();
            Show();
        }

        public void GoBack() {
            
        }
    }
}
