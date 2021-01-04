using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection;

namespace Controller { 
    public class Container {
        
        private static readonly List<Dependency> Dependencies;
        
        static Container() {
            Dependencies = new List<Dependency>();
        }

        private static Dependency AddDependency(string name, Type type) {
            var tpe = (name != type.Name) ? GetType(name, type) : type; 
            
            Dependency dep = new Dependency(tpe);
            
            if (Dependencies.Find(t => t.TypeOfObject != null && t.TypeOfObject.Name.Equals(tpe.Name)) == null) {
                
                if (dep.TypeOfObject.Name.Contains("Services") || (dep.TypeOfObject.BaseType != null && dep.TypeOfObject.BaseType.Name.Equals("Menu") || dep.Needed))
                    Dependencies.Add(dep);
            }

            return dep;
        }

        public static void Add(Dependency dependency) {
            Remove(dependency);
            Dependencies.Add(dependency);
        }

        private static int Find(Dependency dependency) {
            return Dependencies.FindIndex(dep => dep.TypeOfObject.Name.Equals(dependency.TypeOfObject.Name));
        }

        private static bool Remove(Dependency dependency) {
            int index = Find(dependency);

            if (index != -1) {
                Dependencies.RemoveAt(index);
                return true;
            }

            return false;
        }

        private static Dependency InitialiseDependency(string name) {
            
            Dependency dep = AddDependency(name, typeof(Container));
            dep.Initialise();
            
            return dep;
        }
       
        private static Dependency InitialiseDependency(Type type) { 
            Dependency dep = AddDependency(type.Name, type);
            dep.Initialise(); 
                   
            return dep;
        } 
        private static Dependency InitialiseDependency(string name, object[] parameters) {
            Dependency dep = AddDependency(name, typeof(Container));
            dep.Initialise(parameters); 
            
            return dep;
        }
        private static Dependency InitialiseDependency(Type type, object[] parameters) {
            Dependency dep = AddDependency(type.Name, type);
            dep.Initialise(parameters); 
                    
            return dep;
        }

        private static Dependency InitialiseDependency(string name, Type type) {
            Dependency dep = AddDependency(name, type);
            dep.Initialise(type);

            return dep;
        }
        
        private static Dependency InitialiseDependency(string name, Type type, object[] parameters) {
            Dependency dep = AddDependency(name, type);
            dep.Initialise(parameters); 
            
            return dep;
        }

        private static Dependency InitialiseDependency(string name, Type type, Type generic) {
            Dependency dep = AddDependency(name, type);        
            dep.Initialise(generic);
            
            return dep;
        }

        private static Dependency InitialiseDependency(string name, Type type, Type generic, object[] parameters) {
            Dependency dep = AddDependency(name, type);        
            dep.Initialise(generic, parameters);
                    
            return dep;
        }
        
        public static Dependency GetDependency(Type type) { 
            var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(type.Name));
        
            if (dependency != null) {
                if (dependency.Initialised) {
                    return dependency; 
                }
                else return null; 
            }
                    
        
            return InitialiseDependency(type);
        }
        
        public static Dependency GetDependency(string name) {
            var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(name));

            if (dependency != null) {
                if (dependency.Initialised) {
                    return dependency;
                }
                else return null; 
            }
            

            return InitialiseDependency(name);
        }
        
        public static Dependency GetDependency(string name, Type type) {
             var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(name));

             if (dependency != null) {
                 if (dependency.Initialised) {
                     return dependency;
                 }
                 else return null; 
             }
             
             return InitialiseDependency(name, type);
        }

        public static Dependency GetDependency(string name, object[] paramters) {
            var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(name));
         
            if (dependency != null) {
                if (dependency.Initialised) {
                    return dependency;
                }
                else return null; 
            }
                     
            return InitialiseDependency(name, paramters);
        }
        
        public static Dependency GetDependency(Type type, object[] paramters) {
            var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(type.Name));
                 
            if (dependency != null) {
                if (dependency.Initialised) {
                    return dependency;
                }
                else return null; 
            }
                             
            return InitialiseDependency(type, paramters);
        }
        public static Dependency GetDependency(string name, Type type, Type generic) {
            var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(name));
                
            if (dependency != null) {
                if (dependency.Initialised) {
                    return dependency;
                }
                else return null; 
            }
            return InitialiseDependency(name, type, generic);
            
        }

        public static Dependency GetDependency(string name, Type type, object[] parameters) {

            var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(name));

            if (dependency != null) {
                if (dependency.Initialised) {
                    return dependency;
                }
                else return null;
            }

            return InitialiseDependency(name, type, parameters);
        }
        
        public static Dependency GetDependency(string name, Type type, Type generic, object[] parameters) {
                            
            var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(name));
                         
            if (dependency != null) {
                if (dependency.Initialised) {
                    return dependency;
                }
                else return null; 
            }
                                     
            return InitialiseDependency(name, type, generic, parameters);
         }

        public static Type GetType(string name, Type type) {
            Type t1 = type.Assembly.GetTypes().FirstOrDefault(tpe => tpe.ContainsGenericParameters && tpe.Name.Equals(name + "`1") || tpe.Name.Equals(name)); 
            if(t1 == null){
                foreach (var VARIABLE in type.Assembly.GetReferencedAssemblies()) {
                    foreach (var tpe in Assembly.Load(VARIABLE).GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains(VARIABLE.Name))) {
                        if ((tpe.ContainsGenericParameters && tpe.Name.Equals(name + "`1")) || tpe.Name.Equals(name) || (tpe.Name + "s").Equals(name))
                            
                            return tpe;
                    }
                }
            }

            return t1;
        }

        public static Type GetType(string name ) {
            return typeof(Container).Assembly.GetTypes().FirstOrDefault(service => (service.ContainsGenericParameters) ? service.Name.Equals(name+"`1") : service.Name.Equals(name));
        }

        public static List<Type> GetAllModels(Type type) {
            List<Type> types = new List<Type>();
             foreach (var VARIABLE in type.Assembly.GetReferencedAssemblies()) 
                 foreach (var tpe in Assembly.Load(VARIABLE).GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains(VARIABLE.Name) && t.Namespace.Contains("Model"))) 
                     types.Add(tpe);


             return types;
        } 
        
       
    }
}