using System;
using System.Linq;
using System.Reflection;

namespace Controller{
    public abstract class Menu {

        public void Show(params object[] parms) {
            
            Console.Clear();
            Dependency dependency = Container.GetDependency(GetType().Name, GetType(),  parms);

            int choice = Common.Menu(StringManipulations.AddSpacesBeetween(GetType().Name), StringManipulations.AddSpacesBeetween(dependency.GetMethodsName()));
            
            string methodName = dependency.GetMethodsName()[choice];

            if (methodName.StartsWith("GoTo")) {
                // try {
                    object parm = InvokeMethod(dependency, methodName);

                    Container
                        .GetDependency(methodName.Remove(0, 4), GetType(), 
                            // ReSharper disable once PossibleNullReferenceException
                            (parm != null && !parm.ToString().Equals("-1")) 
                                ? new[] {parm} 
                                : null)
                        .InvokeMethod("Show", new[] {parm});
                    Show(parms);
                
                // }
                // catch (TargetParameterCountException e) {
                //     Console.WriteLine("Does not exits: " + e.Message);
                // }
            }
            else if (!methodName.Equals("GoBack")) {
                InvokeMethod(dependency, methodName);
                Console.ReadLine();
                Show(parms);
            }

        }

        private object InvokeMethod(Dependency dependency, string method ) {
            Common.Title(StringManipulations.AddSpacesBeetween(method));
            Dependency crud = Container.GetDependency("CrudOperations");
            string methd = crud
                .GetMethodsName()
                .FirstOrDefault(meth => method.StartsWith(meth));
            
            if (!String.IsNullOrEmpty(methd)) {
                string m = method.Remove(0, methd.Length);
                try {
                    return crud
                        .InvokeMethod(methd, Container.GetType(method.Remove(0, methd.Length), GetType()), null);
                }
                catch (Exception) {
                    return crud.InvokeMethod(methd, Container.GetType(method.Remove(0, methd.Length), GetType()),
                        "");
                }
            }

            return (object) dependency.InvokeMethod(method, null); 
        }

        public void GoBack() {
            
        }
    }
}
