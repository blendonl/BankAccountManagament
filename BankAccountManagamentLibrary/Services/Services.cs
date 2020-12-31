using System;
using System.Collections.Generic;

namespace BankAccountManagamentLibrary.Services {
    public class Services <T> {
        List<T> items = new List<T>();

        public bool Add(T item) {
            if (Contains(item))
                return false;
            items.Add(item);
            return true;
        }

        public bool Contains(T item) {
            foreach (var it in items) {
                if (it.Equals(item))
                    return true;
            }
            return false;
        }
        
        public bool Remove(string item) {
            int index = Find(item); 
            if (index != -1) {
                items.RemoveAt(index);
                return true;
            }
            else {
                return false;
            }
        }
       
        private int Find(string item) {
           return items.FindIndex(itm => itm.Equals(item));
        }
       

       public object Get(string item) {
           try {
               return (T)items[Find(item)];
           }
           catch (Exception) {
               return null;
           }
           
       }

       public List<string> GetAllItemsToString(string? id) {
           List<string> temp = new List<string>();
           foreach (var item in items) {
               if(!String.IsNullOrEmpty(id) && item.ToString().Contains(id))
                   temp.Add(item.ToString());
               else if (String.IsNullOrEmpty(id)) {
                   temp.Add(item.ToString());
               }
           }
           return temp;
       }
    }
}