using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Controller {
    public class Dependency {
        public Type  TypeOfObject { get; set; }
        public object? ActualObject { get; set; }
        public bool Initialised { get; set; }

        public Dependency(Type typeOfObject) {
            TypeOfObject = typeOfObject;
        }

       
        public List<ParameterInfo> GetConstructorParams() {
            return GetType().GetConstructors()[0].GetParameters().ToList();
        }

        public object? Initialise() {
            if (GetConstructorParams().Count > 1) { }
            else {
                Initialised = true;
                return ActualObject = Activator.CreateInstance(TypeOfObject);
            }

            return null;
        } 
        public object? Initialise(Type generic) {
            if (GetConstructorParams().Count > 1) { }
            else {
                Initialised = true;
                if (TypeOfObject.ContainsGenericParameters) {
                    var gener = TypeOfObject.MakeGenericType(new Type[] {generic});
                    return ActualObject = Activator.CreateInstance(gener);
                }
                else {
                    Initialised = true;
                    return ActualObject = Activator.CreateInstance(TypeOfObject);
                }
            }
         
            return null;
        } 
        public object Initialise(object[] paramters) { 
            if (GetConstructorParams().Count > 1) { }
            else { 
                Initialised = true;
                return ActualObject = TypeOfObject.GetConstructors()[0].Invoke(paramters != null ? paramters.Length > 1 ? new[] {paramters} :  paramters : null); 
            }
            return null;
        }
        
        public object Initialise(Type generic, object[] parameters) {
             if (GetConstructorParams().Count < 1) { 
                 Initialised = true;
                if (TypeOfObject.ContainsGenericParameters) {
                    var gener = TypeOfObject.MakeGenericType(new Type[] {generic});
                    return ActualObject = Activator.CreateInstance(gener);
                }
                else {
                    Initialised = true;
                    return ActualObject = Activator.CreateInstance(TypeOfObject);
                } 
             }

             return null;
        }
        public object? InvokeMethod(string method, object parameters) { 
            return GetMethod(method).Invoke(ActualObject, (GetMethod(method).GetParameters().Length > 0) ? (GetMethod(method).ContainsGenericParameters) ? new[] {parameters} : new[] {parameters} : null);
        }

         public object? InvokeMethod(string method, Type type, object parameters) {
              if (GetMethod(method).ContainsGenericParameters) {
                  var genericMethod = GetMethod(method).MakeGenericMethod(new[] {type});
                  return genericMethod.Invoke((GetMethod(method).IsStatic) ? null : ActualObject,
                      (parameters != null)
                          ? new[] {parameters}
                          : null);
              }
              else {
                  return GetMethod(method).Invoke(ActualObject, 
                      GetMethod(method).GetParameters().Length > 0
                          ? new[] {parameters}
                          : null);
              }
         }

        // public object? InvokeMethod(string method, object[] parameters) { 
        //     return GetMethod(method).Invoke(ActualObject, parameters); 
        // }

        public void InitialiseProp( string propType,string propName, object value) {
            var prop = GetProperties().First(prop => prop.PropertyType.Name.Equals(propType) && prop.Name.Equals(propName));
            prop.SetValue(ActualObject, value);
        }
         public object[] GetConstructorParameters(Type methodInfo, object parameters) {
            var constructor = methodInfo.GetConstructors()[0];
            return (parameters == null) 
                ? (methodInfo.IsArray) 
                    ? new[] {new [] {constructor.GetParameters().Length > 0 }} 
                    : new[] {Activator.CreateInstance(methodInfo)} 
                : null;
         }
        public MethodInfo GetMethod(string method) {
            return GetMethods().First(mth => mth.Name.Equals(method));
        }
        
        private MethodInfo GetMethod(int method) {
            if(method > -1 && method < GetMethods().Length)
                return GetMethods()[method];
            return null;
        }
                
        public string GetMethodName( int choice) {
            return GetMethod( choice).Name;
        }
                
        public string GetMethodName(string method) {
            return GetMethod(method).Name;
        }
        
        public MethodInfo[] GetMethods() {
            return TypeOfObject
                .GetMethods()
                .Where(method => method.IsPublic 
                                && !method.IsSpecialName 
                                )
                .ToArray();
        } 
       
        public string[] GetMethodsName() {
            List<string> arr = new List<string>(); 
        
            int count = 0;
            foreach (var method in GetMethods()) {
                if(
                    !method.IsSpecialName &&
                    !method.Name.Equals("Show") &&
                    !method.Name.Equals("Equals") &&
                    !method.Name.Equals("ToString") &&
                    !method.Name.Equals("GetType") &&
                    !method.Name.Equals("GetHashCode")
                    )
                    arr.Add(method.Name);
            }
        
            return arr.ToArray();
        }
        
        public ParameterInfo[] GetMethodParams(string method) {
            return GetMethod(method).GetParameters().ToArray();
        }

        public string[] GetMethodParamsName(string method) {
            
            var rez = new string[GetMethodParams(method).Length];
            int i = 0;
            foreach (var VARIABLE in GetMethodParams(method)) {
                rez[i] = VARIABLE.Name;
                i++;
            }

            return rez;

        }
        
        public string[] GetMethodParamsType(string method) {
            var rez = new string[GetMethodParams(method).Length];
            int i = 0;
            foreach (var VARIABLE in GetMethodParams(method)) {
                rez[i] = VARIABLE.ParameterType.Name;
                i++;
            }

            return rez;
        }
       
        public PropertyInfo[] GetProperties() {
           
             return TypeOfObject.GetProperties().Where(prop => 
                         //    !(prop.Name.Contains("Id") || prop.Name.Contains("Date"))
                             (prop.PropertyType.IsPrimitive && prop.CanRead) ||
                             (prop.PropertyType.Name.Equals("String") && prop.CanWrite)
                         ).ToArray();
        }
        public string[] GetPropertiesName() {
            string[] rez = new string[GetProperties().Length];
            int count = 0;
            foreach (var VARIABLE in GetProperties()) {
                rez[count] = VARIABLE.Name;
                count++;
            }

            return rez;
        }
        
        public string[] GetPropertiesType() {
            string[] rez = new string[GetProperties().Length];
            int count = 0;
            foreach (var VARIABLE in GetProperties()) {
                rez[count] = VARIABLE.PropertyType.Name;
                count++;
            }

            return rez;
        }

        private MethodInfo[] GetViewMethods() {
            if (TypeOfObject != null)
               return TypeOfObject.GetMethods().Where(method => !method.IsAbstract && !method.IsSpecialName && !method.IsPrivate).ToArray();
            return null;
        }
       
    }
}