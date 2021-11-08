using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables_BST_Day15
{
    //described globally as it is used in multiple methods and classes
    public struct KeyValue<k, v>                            //describing a structure named KeyValue with generic data types to hold any kind of data types.
    {                                                       //strctures are basically like classes, but they are value type. they can't be inherited.
        public k Key { get; set; }                          //key and value are the member elements of the class{structure} KeyValue
        public v Value { get; set; }
    }

    public class MyMapNode<K, V>
    {
        private readonly int size;                          // size is the readonly local variabl declaration
        private readonly LinkedList<KeyValue<K, V>>[] items;     //items-- is an array of reference class linkedlist with data type as that of struct
                                                                 //basically the array items will have linkedlist in each of its index with data type of struct class
        public MyMapNode(int size)                          //constructor
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];        //creating items object and declaring the size

        }

        protected int GetArrayPosition(K key)                        // the get array position is the main starting point of using hashtables
        {                                                            //it uses the in-built GetHasshCode() and returns a longint which can be modified to fit the array index range
            int position = key.GetHashCode() % size;
            return Math.Abs(position);                               //using abs from math class as get array may return negative
        }

        public V Get(K key)                                         
        {
            int position = GetArrayPosition(key);                    //gives us the postion of key value using hashing function
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position); //we obtain a single linked list obj in the repsective postion and check for values        
            foreach(KeyValue<K,V> item in linkedList)                
            {
                if (item.Key.Equals(key))                     //return the value of that item if it matches with the key.
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        public void Add(K key, V value)                     //adding the key and value pairs to the linked list
        {
            int position = GetArrayPosition(key);                       // same use first getting the postion of the array using hashing and then obtaining the linked list obj.
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };    //creating an obj named item of keyvalue struct. with the input key and vlaue
            if (linkedList.Count != 0)
            {
                foreach (KeyValue<K, V> item1 in linkedList)                      //this checks whether there exist any duplicate keys. if yes, then remove one with its repective value. 
                {
                    if(item1.Key.Equals(key))
                    {
                        Remove(key);
                        break;
                    }
                }
            }
            linkedList.AddLast(item);                                            // add the new item obj to the linked list conatining the given input key and value

        }

        public void Remove(K key)                            //the remove method
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;                                          //declaring itemfound variable to be boolean false.
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)                     //checking if the input key is already present.
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;                        //if yes, change the boolean to false 
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }

        }
        
        protected LinkedList<KeyValue<K,V>> GetLinkedList(int position)           //this class takes the input as the integer position in range of array items indexes.    
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];              //checks whether there exist any value in that psoition. assigned to linkedlist obj.
            if(linkedList == null)                                               
            {
                linkedList = new LinkedList<KeyValue<K, V>>();                   // if there isn't any value, then create the linked list obj in that respective position
                items[position] = linkedList;
            }
            return linkedList;                                                  //return the linkeddlist obj.

        }

        public bool Exists(K key)                                       //check if a key exist in the array's linked list.
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K,V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public void Display()                         //simple display method that displays the linked lsit object variables inside of the item array.
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                {
                    foreach(var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
                }
            }
        }
    }

}
