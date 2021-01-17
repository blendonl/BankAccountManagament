using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Controller { 
    public class Container {
        
        private static readonly List<Dependency> Dependencies;
        
        static Container() {
            Dependencies = new List<Dependency>();
        }

        public static Dependency AddDependency(string name, Type type) {
            var tpe = (name != type.Name) ? GetType(name, type) : type; 
            
            Dependency dep = new Dependency(tpe);
            
            if (Dependencies.FirstOrDefault(t => t.TypeOfObject != null && t.TypeOfObject.Name.Equals(tpe.Name)) == null) {
                
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
            try {
                dep.Initialise();
            }
            catch (MissingMethodException) {
                return dep;
            }

            return dep;
        }
       
        private static Dependency InitialiseDependency(Type type) { 
            Dependency dep = AddDependency(type.Name, type);
            try {
                dep.Initialise();
            }
            catch (MissingMethodException) {
                return dep;
            }

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
            try {
                dep.Initialise(type);
            }
            catch (MissingMethodException) {
                return dep;
            }

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
            Dependency dependency = FindDependency(type.Name);
           
           if (dependency != null) {
               return dependency;
           }

            return InitialiseDependency(type);
           
        }

        public static Dependency FindDependency(string name) {
             var dependency = Dependencies.FirstOrDefault(dep => dep.TypeOfObject.Name.Equals(name));
            
            if (dependency != null) {
                if (dependency.Initialised) {
                    return dependency;
                }
            }

            return null;
        }
        
        public static Dependency GetDependency(string name) {

            Dependency dependency = FindDependency(name);

            if (dependency != null) {
                return dependency;
            }
            
            return InitialiseDependency(name);
        }
        
        public static Dependency GetDependency(string name, Type type) {

            var dependency = FindDependency(name);

            if (dependency != null) {
                return dependency;
            }
             
            return InitialiseDependency(name, type);
        }

        public static Dependency GetDependency(string name, object[] paramters) {
            var dependency = FindDependency(name);

            if (dependency != null) {
                return dependency;
            }
                     
            return InitialiseDependency(name, paramters);
        }
        
        public static Dependency GetDependency(Type type, object[] paramters) {
            var dependency = FindDependency(type.Name);
           
           if (dependency != null) {
               return dependency;
           }
                             
            return InitialiseDependency(type, paramters);
        }
        public static Dependency GetDependency(string name, Type type, Type generic) {
            var dependency = FindDependency(name);
           
           if (dependency != null) {
               return dependency;
           }
            return InitialiseDependency(name, type, generic);
            
        }

        public static Dependency GetDependency(string name, Type type, object[] parameters) {

              var dependency = FindDependency(name);
                        
            if (dependency != null) {
                return dependency;
            }

            return InitialiseDependency(name, type, parameters);
        }
        
        public static Dependency GetDependency(string name, Type type, Type generic, object[] parameters) {
                            
            var dependency = FindDependency(name);
                                   
               if (dependency != null) {
                   return dependency;
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

        public static List<Type> GetAllRefrencedModels(Type type) {
            List<Type> models = new List<Type>();

            foreach (var VARIABLE in GetAllReferencedAssemblies(type))
                foreach (var tpe in VARIABLE
                     .GetTypes()
                     .Where(t => 
                         t.Namespace != null && 
                         t.Namespace.Contains("Model"))) 
                     models.Add(tpe);

            return models;
             
        }

        public static List<Type> GetAllModels(Type type) {
            List<Type> models = new List<Type>();
            models.AddRange(type.Assembly.GetTypes().Where(t => t.Namespace.Contains("Model")).ToList());
            foreach (var assembly in GetAllReferencedAssemblies(type)) {
                List<Type> temp = assembly.GetTypes().Where(t => !String.IsNullOrEmpty(t.Namespace) && t.Namespace.Contains("Model")).ToList();
                if (temp != null) {
                    models.AddRange(temp);
                }
            }

            return models;
        }


        public static List<Assembly> GetAllReferencedAssemblies(Type type) {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (var assembly in type.Assembly.GetReferencedAssemblies()) {
                if (!assembly.FullName.Equals("System.Runtime")) {
                    assemblies.Add(Assembly.Load(assembly));
                }
            }
            return assemblies;
        }

        public static List<Type> GetAllThatExtends(Type type) {
             List<Type> types = new List<Type>();

             List<Type> models = GetAllModels(type);
             models.AddRange(GetAllRefrencedModels(type));
             foreach (var tpe in models) {
                 if (tpe.BaseType != null && tpe.BaseType.Name.Equals(type.Name)) {
                     types.Add(tpe);
                 }
             }
             return types;
        }

        public static List<string> GetAllThatExtendsToString(Type type) {
            List<string> names = new List<string>();

            GetAllThatExtends(type).ForEach(t => names.Add(t.Name)); 

            return names;
        }
        
       
    }
}