using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;

namespace Controller{
    public abstract class Menu {

        public void Show() {
            Common.Title(StringManipulations.AddSpacesBeetween(GetType().Name));
            
            Dependency dependency = Container.GetDependency(GetType());

            var methods = dependency.GetMethodsName();
            
            int choice = Common.Menu(StringManipulations.AddSpacesBeetween(methods));
            
            if (choice < methods.Length && choice >= 0) {
                string methodName = methods[choice];

                Common.Title(StringManipulations.AddSpacesBeetween(methodName));
                object parm = dependency.InvokeMethod(methodName, null);

                if (methodName.StartsWith("GoTo")) {
                    GoToMethod(dependency, methodName, parm);
                }
                else if (!methodName.Equals("GoBack")) {

                    InvokeMethod(dependency, methodName, parm);
                    Console.ReadLine();
                }
            }
            
            dependency.InvokeMethod("Show", null);
            

        }


        private void GoToMethod(Dependency dependency, string methodName, object parm) {
            if (parm != null) {
                if (parm.GetType().IsPrimitive || parm.GetType().Name.Equals("String")) {
                    string modelName = Container.GetAllModels(GetType())
                        .FirstOrDefault(t => methodName.Contains(t.Name))?.Name;
                    parm = InvokeMethod(dependency, $"Select{modelName}", parm);
                }
            }else { 
                Dependency dep = Container.GetDependency(methodName.Remove(0, 4), GetType(), (parm != null) ? new[] {parm} : null); 
                Container.Add(dep); 
                dep.InvokeMethod("Show", null); 
            } 
        }
        private object InvokeMethod(Dependency dependency, string method, object parm ) {
            Dependency crud = Container.GetDependency("CrudOperations");
            string methd = crud.GetMethodsName().FirstOrDefault(meth => method.StartsWith(meth));
            
            if (!String.IsNullOrEmpty(methd)) {
                string m = method.Remove(0, methd.Length);
                // try {
                    Type type = Container.GetType(method.Remove(0, methd.Length), GetType());
                    if(type != null)
                        return crud.InvokeMethod(methd, type, parm != null ? parm : null);
                    
                    return null;
                    
                // }
                // catch (Exception e) {
                //     return crud.InvokeMethod(methd, Container.GetType(method.Remove(0, methd.Length), GetType()),
                //         (parm != null) ? new Property[] {(Property)parm} : new Property[] { });
                // }
            }

            return (object) dependency.InvokeMethod(method, null); 
        }

        private void InvokeCrudMethod(string method, Type type) {
            
        }

        
        
        public void GoBack() {
        } 
        
    }
}
