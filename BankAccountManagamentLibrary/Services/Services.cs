using System.Collections.Generic;

namespace BankAccountManagamentLibrary.Services {
    public interface IService<T> {
        public List<T> Items { get; }

        bool Add (T item); 
        virtual List<T> GetAll()  { 
            List<T> items = new List<T>();
        
            foreach (var item in Items) {
                if(item.GetType().Name.Equals(typeof(T).Name))
                    items.Add(item);
            }
            return items;
        }
    }
}