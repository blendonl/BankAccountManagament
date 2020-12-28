using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BankAccountManagamentLibrary.Models.ClientModel;

namespace BankAccountManagament.Controller {
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
        public object? Initialise(object[] paramters) { 
            if (GetConstructorParams().Count > 1) { }
            else { 
                Initialised = true;
                return ActualObject = TypeOfObject.GetConstructors()[0].Invoke(paramters.Length > 1 ? new[] {paramters} : paramters); 
            }
            return null;
        } 
        public object? InvokeMethod(string method, object parms) { 
            return GetMethod(method).Invoke(ActualObject, (GetMethod(method).GetParameters().Length > 0) ? (GetMethod(method).ContainsGenericParameters) ? new[] {Activator.CreateInstance(typeof(Client))} : new[] {parms} : null);
        }

         public object? InvokeMethod(string method, Type type, object parms) {
              if (GetMethod(method).ContainsGenericParameters) {
                  var genericMethod = GetMethod(method).MakeGenericMethod(new[] {type});
                  return genericMethod.Invoke(ActualObject,
                      GetMethod(method).GetParameters().Length > 0
                          ? parms == null ? new [] {parms} : new[] {parms} 
                          : null);
              }
              else {
                  return GetMethod(method).Invoke(ActualObject, 
                      GetMethod(method).GetParameters().Length > 0
                          ? new[] {parms}
                          : null);
              }
         }

         public object[] GetParameters(Type info, object parms) {
             var constructor = info.GetConstructors()[0];
             return (parms == null) ? (info.IsArray
                 ) ? new[] {new [] {constructor.GetParameters().Length > 0 }} : new[] {Activator.CreateInstance(info)} : null;
         }
         
         
        // public object? InvokeMethod(string method, object[] parms) { 
        //     return GetMethod(method).Invoke(ActualObject, parms); 
        // }

        public void InitialiseProp( string propType,string propName, object value) {
            var prop = GetProps().First(prop => prop.PropertyType.Name.Equals(propType) && prop.Name.Equals(propName));
            prop.SetValue(ActualObject, value);
        }
        
        private MethodInfo GetMethod(string method) {
            return GetMethods().First(mth => mth.Name.Equals(method));
        }

        public MethodInfo[] GetMethods() {
            return TypeOfObject.GetMethods().Where(method => method.IsPublic).ToArray();
        } 
       
        
        private MethodInfo[] GetViewMethods() {
            if (TypeOfObject != null)
               return TypeOfObject.GetMethods().Where(method => !method.IsAbstract && !method.IsSpecialName && !method.IsPrivate).ToArray();
            return null;
        }
        
       
        public string[] GetMethodsName() {
            List<string> arr = new List<string>(); 
        
            int count = 0;
            foreach (var method in GetMethods()) {
                if(
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
        
        
        
        private MethodInfo GetMethod(int method) {
            if(method > -1 && method < GetMethods().Length)
                return GetMethods()[method];
            return null;
        }
        
        public string GetMethodName( int choice) {
            return GetMethod( choice).Name;
        }
        
        public string GetMethodName( string method) {
            return GetMethod( method).Name;
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
  
        public PropertyInfo[] GetProps() {
            return TypeOfObject.GetProperties().Where(prop => 
            //    !(prop.Name.Contains("Id") || prop.Name.Contains("Date"))
                prop.CanWrite
            ).ToArray();
        }
        public string[] GetPropsName() {
            string[] rez = new string[GetProps().Length];
            int count = 0;
            foreach (var VARIABLE in GetProps()) {
                rez[count] = VARIABLE.Name;
                count++;
            }

            return rez;
        }
        
        public string[] GetPropsType() {
            string[] rez = new string[GetProps().Length];
            int count = 0;
            foreach (var VARIABLE in GetProps()) {
                rez[count] = VARIABLE.PropertyType.Name;
                count++;
            }

            return rez;
        }
                
                    
    }
}