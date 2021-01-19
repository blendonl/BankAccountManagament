using System;
using System.Linq;


namespace Controller{
    public abstract class Menu {

        public void Show() {
            Common.Title(StringManipulations.AddSpacesBeetween(GetType().Name));
            
            Dependency dependency = Container.GetDependency(GetType());

            var methods = dependency.GetMethodsName();
            
            int choice = Common.Menu(StringManipulations.AddSpacesBeetween(methods));
            
            if (choice < methods.Length && choice >= 0) {
                string methodName = methods[choice];
                if (!methodName.Equals("GoBack")) {
                    Common.Title(StringManipulations.AddSpacesBeetween(methodName));
                    object parm = dependency.InvokeMethod(methodName, null);

                    if (methodName.StartsWith("GoTo")) {
                        GoToMethod(dependency, methodName, parm);
                    }
                    else {

                        InvokeCrudMethod( methodName, parm);
                        Console.ReadLine();
                    }
                    Show();
                }
            }
            else {
                Show();
            }

        }

        private void GoToMethod(Dependency dependency, string methodName, object parm) {
            Dependency dep = Container.GetDependency(methodName.Remove(0, 4), GetType());
            string[] modelName = null;
            try {

                if (parm != null && (parm.GetType().IsPrimitive || parm.GetType().Name.Equals("String"))) {
                    modelName = dep.GetConstructorParams().Select(item => item.Name).ToArray();

                    // Container.GetAllModels(GetType())
                    // .FirstOrDefault(t => methodName.Contains(t.Name))?.Name;
                    parm = InvokeCrudMethod($"Select{modelName[0]}", parm);
                }
                
                dep.Initialise(parm != null ? new[] {parm} : null);
                Container.Add(dep);
                dep.InvokeMethod("Show", null);
            }
            catch (Exception) {
                Console.WriteLine($"{((modelName != null) ? modelName[0] : "")} does not exists");
                Console.ReadLine();
            }


        }
        private object InvokeCrudMethod(string method, object parm ) {
            Dependency crud = Container.GetDependency("CrudOperations");
            string methd = crud.GetMethodsName().FirstOrDefault(meth => method.StartsWith(meth));
            
            if (!String.IsNullOrEmpty(methd)) {
                string m = method.Remove(0, methd.Length);
                Type type = Container.GetType(method.Remove(0, methd.Length), GetType());
                if(type != null)
                    return crud.InvokeMethod(methd, type, parm != null ? methd.Equals("Create") ? parm.GetType().Name.Equals("Property") ? new [] {parm} : new [] {ToProperty(parm)} : new [] {parm} : null);
            }

            return null;
        }

        private Property ToProperty(object parm) {
            Type type = parm.GetType();

            var typeName = type.BaseType != null ? type.BaseType : type;
            
            return new Property(typeName.Name, typeName, parm);

        }

      
        
        public void GoBack() {
        } 
        
    }
}
