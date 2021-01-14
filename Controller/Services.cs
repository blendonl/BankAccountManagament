using System.Collections.Generic;

namespace Controller {
    public abstract class Services<T> {
        public List<T> Items;
        
        public abstract bool Add(T item);

        public abstract bool Remove(int id);

        public List<T> GetAll() { 
            List<T> items = new List<T>();
        
            foreach (var item in Items) {
                items.Add(item);
            }
            return items;
        }
    }
}