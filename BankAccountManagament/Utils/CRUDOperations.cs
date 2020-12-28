using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using BankAccountManagament.Controller;
using Parameter = BankAccountManagament.Controller.Parameter;

namespace BankAccountManagament.Utils {
    public class CRUDOperations {
        
         public T Create<T>(string id) {
             
            string typeName = typeof(T).Name; 
            
            var props = GetPropsFromInput(Container.GetDependency(typeName));
          
            return (T)Container.GetDependency($"{typeName}Services").InvokeMethod("Add", props.ToArray());        
        }

        public T Create<T>(object[] givenProps) {
            
            string typeName = typeof(T).Name;
            
            Dependency item = Container.GetDependency(typeName); 
            
            var props = GetPropsFromInput(item);
            
            if(givenProps.Length > 0 && ((Parameter)givenProps[0]).ParameterType != null)
                props.AddRange((Parameter[])givenProps);
          
            return (T)Container.GetDependency($"{typeName}Services").InvokeMethod("Add", typeof(T), props.ToArray());        
        }

        public List<Parameter> GetPropsFromInput(Dependency dependency) {
                        
            List<Parameter> props = new List<Parameter>();
            string[] paramNames = dependency.GetPropsName();
            string[] paramTypes = dependency.GetPropsType();

            for (int i = 0; i < paramNames.Length; i++) {
                if (paramTypes[i].Equals("String"))
                    props.Add(
                        new Parameter() {
                        ParameterName = paramNames[i],
                        ParameterType = paramTypes[i],
                        Value = Common.Input(paramNames[i], 3)
                    });

                else {
                    if (paramTypes[i].Equals("Decimal")) {
                        props.Add(new Parameter() {
                            ParameterName = paramNames[i],
                            ParameterType = paramTypes[i],
                            Value = Common.LoopMoneyInput(paramNames[i], 1)
                        });
                    }
                    else {
                        props.Add(new Parameter() {
                            ParameterName = paramNames[i],
                            ParameterType = paramTypes[i],
                            Value = Common.LoopInput(paramNames[i], 1)
                        });
                    }

                }
            }

            return props;
            
        }

        public void ViewAll<T>(string id) {
            Common.Title(typeof(T).Name);
            // ReSharper disable once PossibleNullReferenceException
            foreach (var VARIABLE in (List<string>) Container.GetDependency($"{typeof(T).Name}Services")
                 .InvokeMethod($"GetAllItemsToString", id)) { 
                 Console.WriteLine(VARIABLE.ToString());
             }
        }

        public T Select<T>(Parameter parameters) {
            Common.Title(typeof(T).Name);
            return (T) Container.GetDependency($"{typeof(T).Name}Services").InvokeMethod("Get", parameters.Value);
        }
        

        public bool Remove<T>() {
            Common.Title(typeof(T).Name);
            string clientId = Common.Input("ClientId", 1);

            // ReSharper disable once PossibleNullReferenceException
            return ((bool) Container.GetDependency($"{typeof(T).Name}Services").InvokeMethod("Remove", clientId)) ;
        }
    }
}