using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountManagament.Controller { 
    public class Container {
        
        private static List<Dependency> dependencies;
        
        static Container() {
            dependencies = new List<Dependency>();
        }

        public static Dependency AddDependency(string type) {
            var tpe = GetType(type, typeof(Container));
            
            Dependency dep = new Dependency(tpe);
            
            if (dependencies.Find(t => t.TypeOfObject != null && t.TypeOfObject.Name.Equals(tpe.Name)) == null) {
                if(dep.TypeOfObject.Name.Contains("Service"))
                    dependencies.Add(dep);
                dep.Initialise();
            }

            return dep;
        }
        public static Dependency AddDependency(string type, Type generyc) {
            var tpe = GetType(type, generyc);
        
            Dependency dep = new Dependency(tpe);
            if (dependencies.Find(t => t.TypeOfObject != null && t.TypeOfObject.Name.Equals(tpe.Name)) == null) {
                if(dep.TypeOfObject.Name.Contains("Service"))
                    dependencies.Add(dep);
                dep.Initialise(generyc);
            }

            return dep;
        }

        public static Dependency AddDependency(string name, Type type, Type generic) {
            var tpe = GetType(name, type);
                        
            Dependency dep = new Dependency(tpe);
            if (dependencies.Find(t => t.TypeOfObject != null && t.TypeOfObject.Name.Equals(tpe.Name)) == null) {
                    if(dep.TypeOfObject.Name.Contains("Service"))
                        dependencies.Add(dep);
                    dep.Initialise(generic);
            }
            
            return dep;
        }

        public static Dependency GetDependency(string name, Type type, Type generic) {
            var tpe = GetType(name, type);

            var dep = dependencies.FirstOrDefault(d => d.TypeOfObject.Name.Equals(type));

            if (dep != null && dep.Initialised)
                return dep;
            return AddDependency(name, type, generic);
            
        }
        private static Dependency AddDependency(string type, object[] paramters) {
            var tpe = GetType(type, typeof(Container)); 
            Dependency dep = new Dependency(tpe);
            if (dependencies.Find(t => t.TypeOfObject != null && t.TypeOfObject.Name.Equals(tpe.Name)) == null) { 
                if(dep.TypeOfObject.Name.Contains("Service") || dep.TypeOfObject.BaseType.Name.Equals("Menu")) 
                    dependencies.Add(dep); 
                dep.Initialise(paramters); 
            }
            return dep;
        }

        public static Dependency GetDependency(string type) {
            var dep = dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(type));

            if (dep != null) {
                if (dep.Initialised) {
                    return dep;
                }
                else return null; 
            }
            

            return AddDependency(type);
        } 
        public static Dependency GetDependency(string type, Type generic) {
             var dep = dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(type));

             if (dep != null) {
                 if (dep.Initialised) {
                     return dep;
                 }
                 else return null; 
             }
             
             return AddDependency(type, generic);
        }


        public static Dependency GetDependency(string type, object[] paramters) {
            var dep = dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(type));
         
            if (dep != null) {
                if (dep.Initialised) {
                    return dep;
                }
                else return null; 
            }
                     
            return AddDependency(type, paramters);
        }


        public static Type GetType(string name, Type type) {
            return type.Assembly.GetTypes().FirstOrDefault(service => (service.ContainsGenericParameters) ? service.Name.Equals(name+"`1") : service.Name.Equals(name));
        }

        public static Dependency  GetDependency(string type, Type generic, object[] parameters) {
            
            var dep = dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(type));
         
            if (dep != null) {
                if (dep.Initialised) {
                    return dep;
                }
                else return null; 
            }
                     
            return AddDependency(type, generic, parameters);
        }

        private static Dependency? AddDependency(string type, Type generic, object[] parameters) {
              var tpe = GetType(type, generic); 
            Dependency dep = new Dependency(tpe);
            if (dependencies.Find(t => t.TypeOfObject != null && t.TypeOfObject.Name.Equals(tpe.Name)) == null) { 
                if(dep.TypeOfObject.Name.Contains("Service")) 
                    dependencies.Add(dep); 
                dep.Initialise(parameters); 
            }
            return dep;
        }    
    }
}