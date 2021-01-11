using System;
using System.Collections.Generic;

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
                if((bool)Container.GetDependency($"{(dependency.TypeOfObject.BaseType != null ? dependency.TypeOfObject.BaseType.Name : dependency.TypeOfObject.Name)}Services", typeof(T)).InvokeMethod("Add", dependency.ActualObject))
                   //if (ClientServices.Add((T)(dependency.ActualObject))) {
                    return true;

                return false;
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
                if((bool)Container.GetDependency($"{typeof(T).Name}Services", typeof(T)).InvokeMethod("Add", dependency.ActualObject))
                   //if (ClientServices.Add((T)(dependency.ActualObject))) {
                    return true;

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
                
                if(givenProperties != null)
                    properties.AddRange(givenProperties);
                
                foreach (var property in properties) {
                    dependency.InitialiseProp(property);
                }
                if((bool)Container.GetDependency($"{typeof(T).Name}Services").InvokeMethod("Add", dependency.ActualObject))
                   //if (ClientServices.Add((T)(dependency.ActualObject))) {
                    return true;

                return false;
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
        
        
        public static bool Remove<T>(object id) {
            return (bool)Container.GetDependency($"{typeof(T).Name}Services", typeof(T)).InvokeMethod("Remove", id);
            
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


        private static string BaseTypeName<T>() {
            return (typeof(T).BaseType != null) ? typeof(T).BaseType?.Name : typeof(T).Name;
        }
    }
}
