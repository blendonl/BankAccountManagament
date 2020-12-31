using System;
using System.Collections.Generic;

namespace Controller {
    public class CrudOperations {
        
        public bool Create<T>() {
             
            string typeName = typeof(T).Name; 
            
            Dependency item = Container.GetDependency(typeName, typeof(T)); 
            object obj = item.Initialise(); 
            
            var props = GetPropsFromInput(item);
            
            for(int i = 0; i < props.Count; i++) 
               item.InitialiseProp(props[i].ParameterType, props[i].ParameterName, props[i].Value);
            
            // ReSharper disable once PossibleNullReferenceException
            return (bool)Container.GetDependency($"{typeName}Services", typeof(T)).InvokeMethod("Add", obj);        
        }

        public T Create<T>(object[] givenProps) {
            
            string typeName = typeof(T).Name;

            Dependency item = Container.GetDependency(typeName, typeof(T));
            object obj = item.Initialise();
            
            var props = GetPropsFromInput(item);
            
            if(givenProps.Length > 0 && ((Parameter)givenProps[0]).ParameterType != null)
                props.AddRange((Parameter[])givenProps);
            
            for(int i = 0; i < props.Count; i++) 
                item.InitialiseProp(props[i].ParameterType, props[i].ParameterName, props[i].Value);
          
            return (T)Container.GetDependency($"Services", typeof(T)).InvokeMethod("Add",  obj);        
        }

        public List<Parameter> GetPropsFromInput(Dependency dependency) {
                        
            List<Parameter> props = new List<Parameter>();
            string[] paramNames = dependency.GetPropertiesName();
            string[] paramTypes = dependency.GetPropertiesType();

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

        public void View<T>(string id) {
            // ReSharper disable once PossibleNullReferenceException
            foreach (var variable in (List<string>) Container.GetDependency($"{typeof(T).Name}Services", typeof(T))
                 .InvokeMethod($"GetAllItemsToString", id)) { 
                 Console.WriteLine(variable.ToString());
             }
        }

        public T Select<T>(Parameter parameters) {
            Common.Title(typeof(T).Name);
            return (T) Container.GetDependency($"{typeof(T).Name}Services", typeof(T)).InvokeMethod("Get", parameters.Value);
        }

        public bool Remove<T>() {
            Common.Title(typeof(T).Name);
            string clientId = Common.Input("ClientId", 1);

            // ReSharper disable once PossibleNullReferenceException
            return ((bool) Container.GetDependency($"{typeof(T).Name}Services", typeof(T)).InvokeMethod("Remove", clientId)) ;
        }
    }
}