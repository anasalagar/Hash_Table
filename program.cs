using System;

namespace HashTables_BST_Day15
{
    class Program
    {
        public static void CountingWordFrequency(string sentence)            //this static method counts thr frquency of the words.
        {
            MyMapNode<string, int> hashtable = new MyMapNode<string, int>(10);      //declaring the key and value data types of the Mymapnodde class.
            string[] words = sentence.Split();                //splitting the sentence otherwise it wont be possible to generate keys.
            foreach (string word in words)
            {
                if (hashtable.Exists(word))                    //word is the "key"
                {
                    hashtable.Add(word, hashtable.Get(word) + 1);           //if it exists. get the value of the linkedlist object and invrement its value.
                }
                else
                {
                    hashtable.Add(word, 1);
                }
            }
            Console.WriteLine("Displaying after add operation\n");
            hashtable.Display();
            Console.WriteLine("----------------------------------------");
        }
        static void Main(string[] args)
        {
            CountingWordFrequency("to be or not to be");
         

        }
    }
}
