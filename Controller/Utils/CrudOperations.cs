﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Controller.Utils {
    
    public class CrudOperations {

        private static Dependency GetModelDependency<T>() {
            var models = Container.GetAllThatExtendsToString(typeof(T)).ToArray();
            int choice = -1;
            if (models.Length > 0) {
                choice = Common.Menu(models);
            }

            return Container.GetDependency((choice != -1) ? models[choice] : typeof(T).Name, typeof(T));
            
        }

        public static bool InitialiseProperties<T>(Dependency dependency, List<Property> properties) {
            try {

                foreach (var property in properties) {
                    dependency.InitialiseProp(property);
                }

                return ((bool) Container.GetDependency($"{BaseTypeName(typeof(T))}Services", typeof(T))
                    .InvokeMethod("Add", dependency.ActualObject));
            }
            catch (IndexOutOfRangeException) {
                return false;

            }
            catch (NullReferenceException) {
                return true;
            }
        }

        

        public static bool CreateObject<T>(Dependency dependency, List<Property> properties) {
             if (InitialiseProperties<T>(dependency, properties)) { 
                Console.WriteLine($"{typeof(T).Name} created succesfully"); 
                return true;
             }
             else { 
                Console.WriteLine($"{typeof(T).Name} could not be created"); 
                return false; 
             }
        }
       

        public static object Create<T>() {
            Dependency dependency = GetModelDependency<T>(); 
            List<Property> properties =  GetPropsFromInput(dependency);
            CreateObject<T>(dependency, properties);
            return dependency.ActualObject;
        }
        public static object Create<T>(Property givenProperties) {
            Dependency dependency = GetModelDependency<T>(); 
            List<Property> properties =  GetPropsFromInput(dependency);
            
            if(givenProperties != null)
                properties.Add(givenProperties);
            
            CreateObject<T>(dependency, properties);
            return dependency.ActualObject;

        }
        
        
        public static object Create<T>(Property[] givenProperties) {
            Dependency dependency = GetModelDependency<T>(); 
            List<Property> properties =  GetPropsFromInput(dependency);
                
            if(givenProperties != null)
                properties.AddRange(givenProperties);
            CreateObject<T>(dependency, properties);
            return dependency.ActualObject;
        }
         
        public static List<Property> GetPropsFromInput(Dependency dependency) {
            List<Property> properties = dependency.GetProperties();
            properties.ForEach(prop => 
                prop.PropertyValue = Container.
                    GetDependency("Common").InvokeMethod("LoopInputi", prop.PropertyType, new Object[] {prop.PropertyName, 1}));
            
            return properties;
            
        }
        
        
        public static void Remove<T>(object id) {
            if ((bool)GetDependency<T>().InvokeMethod("Remove", id)) {
                Console.WriteLine($"{typeof(T).Name} removed succesfully");
            }
            else {
                Console.WriteLine($"{typeof(T).Name} could not be removed");
            }
            
        }
        
         public static void View<T>() {
            // ReSharper disable once PossibleNullReferenceException
            Dependency dep = GetDependency<T>();
             if (dep != null) 
                 foreach (var variable in (List<T>) dep.InvokeMethod($"GetAll", typeof(T), null)) { 
                     Console.WriteLine(variable.ToString());
                 }
             
             Console.WriteLine(); 
         }
        
        public static void View<T>(object id) {
            // ReSharper disable once PossibleNullReferenceException
            Dependency dep = GetDependency<T>(); 
            if (dep != null)
                foreach (var variable in (List<T>) dep.InvokeMethod($"GetAll", (id != null) ? id : null)) { 
                    Console.WriteLine(variable.ToString());
                }

            Console.WriteLine();
        }

        public static object Select<T>(object parameter) {
            Dependency dep = GetDependency<T>();
            
            if (dep != null)
                return dep.InvokeMethod("Get", (parameter));
            return null;
        }


        public static string BaseTypeName(Type type) {
            Type baseType = type.BaseType;

            while (baseType.BaseType != null && !baseType.BaseType.Name.Equals("Object")) {
                baseType = baseType.BaseType;
            }

            return baseType != null && !baseType.Name.Equals("Object") ? baseType.Name : type.Name;
        }

        private static Dependency GetDependency<T>() {
           return Container.GetDependency($"{BaseTypeName(typeof(T))}Services", typeof(T)); 
        }
    }
}
