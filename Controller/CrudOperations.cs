using System;
using System.Collections.Generic;

namespace Controller {
    
    public class CrudOperations {

        public static bool Create<T>(params Property[] givenProperties) {
            var models = Container.GetAllThatExtendsToString(typeof(T)).ToArray();
            int choice = Common.Menu(models);
            Console.WriteLine();
            try {
                Dependency dependency = Container.GetDependency(models[choice]);

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
                    
                } else {
                    props[i].PropertyValue = Common.LoopInput(props[i].PropertyName, 1);
                    
                }
            }

            return props;
            
        }
        
        
        public static bool Remove<T>(object id) {
            // ReSharper disable once PossibleNullReferenceException
            return (bool)Container.GetDependency($"{typeof(T).Name}Services", typeof(T)).InvokeMethod("Remove", id);
            //     Console.WriteLine($"{typeof(T).Name} removed successfully");
            // else {
            //     Console.WriteLine($"{typeof(T).Name} could not be removed");
            // }
        }
        // public static void AddAccount(string clientId) {
        //     
        //     AccountType accountType = (AccountType) Common.LoopInput("Account Type", 1);
        //     decimal initialDeposit = Common.LoopMoneyInput("Initial Input", 0);
        //     AccountServices.Add(ClientServices.Get(clientId), accountType, initialDeposit);
        //     Console.WriteLine("Account Added Succesfully");
        //     
        // }

       
    }
}
