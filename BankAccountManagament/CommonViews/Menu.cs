using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using BankAccountManagament.Controller;
using BankAccountManagament.Utils;

namespace BankAccountManagament.CommonViews{
    public abstract class Menu {

        public void Show(params object[] parms) {
            
            Console.Clear();
            Dependency dependency = Container.GetDependency(GetType().Name, parms);

            int choice = Common.Menu(StringManipulations.AddSpacesBeetween(GetType().Name), StringManipulations.AddSpacesBeetween(dependency.GetMethodsName()));
            
            string methodName = dependency.GetMethodsName()[choice];

            if (methodName.StartsWith("GoTo")) {
                try {
                    object parm = InvokeMethod(dependency, methodName);

                    Container
                        .GetDependency(methodName.Remove(0, 4), (parm != null && !parm.ToString().Equals("-1")) ? new[] {parm} : null)
                        .InvokeMethod("Show", new[] {parm});
                    Show(parms);
                
                }
                catch (TargetParameterCountException) {
                    Console.WriteLine("Does not exits");
                }
            }
            else if (!methodName.Equals("GoBack")) {
                InvokeMethod(dependency, methodName);
                Console.ReadLine();
                Show(parms);
            }

        }

        private object InvokeMethod(Dependency dependency, string method) { 
            Common.Title(StringManipulations.AddSpacesBeetween(method));
            
            return (object) dependency.InvokeMethod(method, null); 
        }

        public void GoBack() {
            
        }
    }
}
