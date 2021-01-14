using System;
using System.Collections.Generic;
using System.Transactions;

namespace Controller {
    
    public class CrudOperations {
        public static bool Create<T>() {
            var models = Container.GetAllThatExtendsToString(typeof(T)).ToArray();
            int choice = Common.Menu(models);
            Console.WriteLine();
            try {
                Dependency dependency = Container.GetDependency(models[choice], typeof(T));

                List<Property> properties = GetPropsFromInput(dependency);
                
                foreach (var property in properties) {
                    dependency.InitialiseProp(property);
                }
                if((bool)Container.GetDependency($"{BaseTypeName(typeof(T))}Services", typeof(T)).InvokeMethod("Add", dependency.ActualObject))
                {
                    Console.WriteLine($"{typeof(T).Name} removed succesfully");
                    return true;
                }
                else {
                    Console.WriteLine($"{typeof(T).Name} could not be removed");
                    return false;
                }

            }
            catch (IndexOutOfRangeException) {
                return false;
            }
        }
        public static bool Create<T>(Property givenProperties) {
            var models = Container.GetAllThatExtendsToString(typeof(T)).ToArray();
            int choice = Common.Menu(models);
            Console.WriteLine();
            try {
                Dependency dependency = Container.GetDependency(models[choice], typeof(T));

                List<Property> properties = GetPropsFromInput(dependency);
                
                if(givenProperties != null)
                    properties.Add(givenProperties);
                
                foreach (var property in properties) {
                    dependency.InitialiseProp(property);
                }

                if ((bool) Container.GetDependency($"{BaseTypeName(typeof(T))}Services", typeof(T))
                    .InvokeMethod("Add", dependency.ActualObject)) {
                    Console.WriteLine($"{typeof(T).Name} removed succesfully");
                    return true;
                }
                else {
                    Console.WriteLine($"{typeof(T).Name} could not be removed");
                    return false;
                }

                return false;
            }
            catch (IndexOutOfRangeException) {
                return false;
            }
        }
        
        
        public static bool Create<T>(Property[] givenProperties) {
            var models = Container.GetAllThatExtendsToString(typeof(T)).ToArray();
            int choice = -1;
            if (models != null) {
                choice = Common.Menu(models);
            }

            Console.WriteLine();
            try {
                Dependency dependency = Container.GetDependency((choice != -1) ? models[choice] : typeof(T).Name);

                List<Property> properties = GetPropsFromInput(dependency);

                if (givenProperties != null)
                    properties.AddRange(givenProperties);

                foreach (var property in properties) {
                    dependency.InitialiseProp(property);
                }

                if ((bool) Container.GetDependency($"{BaseTypeName(typeof(T))}Services")
                    .InvokeMethod("Add", dependency.ActualObject)) { 
                    Console.WriteLine($"{typeof(T).Name} removed succesfully");
                    return true;
                } else { 
                    Console.WriteLine($"{typeof(T).Name} could not be removed");
                    return false;
                }
                //if (ClientServices.Add((T)(dependency.ActualObject))) {

            }
            catch (IndexOutOfRangeException) {
                return false;
            }
        }
         
        public static List<Property> GetPropsFromInput(Dependency dependency) {

            List<Property> props = dependency.GetProperties(); 
           

            for (int i = 0; i < props.Count; i++) {
                if (props[i].PropertyType.Equals("String"))
                
                    props[i].PropertyValue = Common.Input(props[i].PropertyName, 1);
                
                else if (props[i].PropertyType.Equals("Decimal")) {
                    
                    props[i].PropertyValue = Common.LoopMoneyInput(props[i].PropertyName, 1);
                    
                } else if (props[i].PropertyType.Equals("DateTime")){
                    
                    props[i].PropertyValue =  Common.LoopDateInput(props[i].PropertyName, 10);
                    
                }
            }

            return props;
            
        }
        
        
        public static void Remove<T>(object id) {
            if ((bool)Container.GetDependency($"{typeof(T).Name}Services", typeof(T)).InvokeMethod("Remove", id)) {
                Console.WriteLine($"{typeof(T).Name} removed succesfully");
            }
            else {
                Console.WriteLine($"{typeof(T).Name} could not be removed");
            }
            
        }
        
         public static void View<T>() {
            // ReSharper disable once PossibleNullReferenceException
             Dependency dep = Container.GetDependency($"{typeof(T).Name}Services", typeof(T)); 
             if (dep != null) 
                 foreach (var variable in (List<T>) dep.InvokeMethod($"GetAll", null)) { 
                     Console.WriteLine(variable.ToString());
                 }
             
             Console.WriteLine(); 
         }
        
        public static void View<T>(object id) {
            // ReSharper disable once PossibleNullReferenceException
            Dependency dep = Container.GetDependency($"{typeof(T).Name}Services", typeof(T));
            if (dep != null)
                foreach (var variable in (List<T>) dep.InvokeMethod($"GetAll", (id != null) ? id : null)) { 
                    Console.WriteLine(variable.ToString());
                }

            Console.WriteLine();
        }

        public static object Select<T>(object parameter) { 
            Dependency dep = Container.GetDependency($"{typeof(T).Name}Services", typeof(T));
            if (dep != null)
                return dep.InvokeMethod("Get", (parameter));
            return null;
        }


        public static string BaseTypeName(Type type) {
            Type baseType = type.BaseType;

            while (baseType != null) {
                baseType = baseType.BaseType;
            }

            return baseType != null ? baseType.Name : type.Name;
        }
    }
}
