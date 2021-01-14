using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Controller {
    public class Dependency {
        public Type TypeOfObject { get; set; }
        public object? ActualObject { get; set; }
        public bool Initialised { get; set; }
        
        public bool Needed { get; set; }

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
            var methodInfo = GetMethod(method, parameters);
            return methodInfo.Invoke(ActualObject, (methodInfo.GetParameters().Length > 0) ? 
                (methodInfo.ContainsGenericParameters) ? 
                    new[] {parameters} : 
                    new[] {parameters} 
                : null);
        }

         public object? InvokeMethod(string method, Type type, object parameters) {
              if (GetMethod(method, parameters).ContainsGenericParameters) {
                  var genericMethod = GetMethod(method, parameters).MakeGenericMethod(new[] {type});
                  return genericMethod.Invoke((GetMethod(method, parameters).IsStatic) ? null : ActualObject,
                      (parameters != null)
                          ? new[] {parameters}
                          : null);
              }
              else {
                  return GetMethod(method, parameters).Invoke(ActualObject, 
                      GetMethod(method, parameters).GetParameters().Length > 0
                          ? new[] {parameters}
                          : null);
              }
         }

        // public object? InvokeMethod(string method, object[] parameters) { 
        //     return GetMethod(method).Invoke(ActualObject, parameters); 
        // }

        public void InitialiseProp(Property property) {
            var prop = TypeOfObject.GetProperties().FirstOrDefault(pro => 
                pro.PropertyType.Name.Equals(property.PropertyType) && 
                pro.Name.Equals(property.PropertyName));
            if(prop != null)
                prop.SetValue(ActualObject, property.PropertyValue);
        }
         public object[] GetConstructorParameters(Type methodInfo, object parameters) {
            var constructor = methodInfo.GetConstructors()[0];
            return (parameters == null) 
                ? (methodInfo.IsArray) 
                    ? new[] {new [] {constructor.GetParameters().Length > 0 }} 
                    : new[] {Activator.CreateInstance(methodInfo)} 
                : null;
         }
        public MethodInfo GetMethod(string method, object parms) {
            var methods =  GetMethods().Where(mth => mth.Name.Equals(method));
            List<Type> paramteres = new List<Type>();
            if(parms != null && parms.GetType().IsArray)
                foreach (var VARIABLE in (object[])parms) {
                    paramteres.Add(VARIABLE.GetType());
                }
            if(parms != null && !parms.GetType().IsArray)
                paramteres.Add(parms.GetType());

            return ActualObject.GetType().GetMethod(method, paramteres.ToArray()); 

        }
        
        private MethodInfo GetMethod(int method) {
            if(method > -1 && method < GetMethods().Length)
                return GetMethods()[method];
            return null;
        }
                
        public string GetMethodName( int choice) {
            return GetMethod( choice).Name;
        }
                
        public string GetMethodName(string method, object parameters) {
            return GetMethod(method, parameters).Name;
        }
        
        public MethodInfo[] GetMethods() {
           return TypeOfObject
                .GetMethods()
                .Where(method => method.IsPublic 
                                && !method.IsSpecialName 
                                )
                .OrderBy(meth => meth.DeclaringType.Name.Equals("Menu") && meth.DeclaringType.Name.Equals(TypeOfObject.Name)).ToArray();
           
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
        
        public ParameterInfo[] GetMethodParams(string method, object paramters) {
            return GetMethod(method, paramters).GetParameters().ToArray();
        }

        public string[] GetMethodParamsName(string method, object parameters) {
            
            var rez = new string[GetMethodParams(method, parameters).Length];
            int i = 0;
            foreach (var VARIABLE in GetMethodParams(method, parameters)) {
                rez[i] = VARIABLE.Name;
                i++;
            }

            return rez;

        }
        
        public string[] GetMethodParamsType(string method, object paramteres) {
            var rez = new string[GetMethodParams(method, paramteres).Length];
            int i = 0;
            foreach (var VARIABLE in GetMethodParams(method, paramteres)) {
                rez[i] = VARIABLE.ParameterType.Name;
                i++;
            }

            return rez;
        }
       
        public PropertyInfo[] GetPropertiesInfos() {
            
            return TypeOfObject.GetProperties().Where(prop =>
                (prop.PropertyType.BaseType.Name.Equals("ValueType")  || 
                 prop.PropertyType.Name.Equals("String")) && prop.CanWrite && !prop.PropertyType.Name.Equals("Boolean")
            ).OrderBy(pro => pro.DeclaringType.Name.Equals(TypeOfObject.BaseType.Name)).ToArray();
        }
        public string[] GetPropertiesName() {
            string[] rez = new string[GetPropertiesInfos().Length];
            int count = 0;
            foreach (var VARIABLE in GetPropertiesInfos()) {
                rez[count] = VARIABLE.Name;
                count++;
            }

            return rez;
        }

        public List<Property> GetProperties() {
            List<Property> properties = new List<Property>();

            foreach (var property in GetPropertiesInfos()) {
                properties.Add(new Property() {
                    PropertyName = property.Name,
                    PropertyType = property.PropertyType.Name,
                    PropertyValue = property.GetValue(ActualObject)
                });
            }

            return properties;
        } 
        
        public string[] GetPropertiesType() {
            string[] rez = new string[GetPropertiesInfos().Length];
            int count = 0;
            foreach (var VARIABLE in GetPropertiesInfos()) {
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