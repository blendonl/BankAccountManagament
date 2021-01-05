using System;

namespace Controller{
    public abstract class Menu {

        public void Show() {
            Common.Title(StringManipulations.AddSpacesBeetween(GetType().Name)); 
            Dependency dependency = Container.GetDependency(GetType());
            
            string[] methods = dependency.GetMethodsName();
            
            int choice = Common.Menu(StringManipulations.AddSpacesBeetween((methods)));
            
            if(!methods[choice].Equals("GoBack")) {
                InvokeMethod(dependency, methods[choice]);
                Show();
            }
        }


        private void InvokeMethod(Dependency dependency, string method) {
            string[] methods = dependency.GetMethodsName();
            
            try {
                Common.Title(StringManipulations.AddSpacesBeetween(method)); 
               if(method.StartsWith("GoTo")) {
                    //   dependency = Container.GetDependency(methods[choice]);
                    //   dependency.InvokeMethod("Show", null);
                    object obj = dependency.InvokeMethod(method, null);

                    if (obj != null) {
                        dependency = Container.GetDependency(method.Remove(0, 4), new[] {obj});
                        Container.Add(dependency);
                        dependency.InvokeMethod("Show", null);
                    }
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
