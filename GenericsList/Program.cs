using GenericsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericStoreInArray<int> genericTestInt = new GenericStoreInArray<int>(0);
            GenericStoreInArray<int> genericTestInt2 = new GenericStoreInArray<int>(0);
            genericTestInt2.Add(0);
            genericTestInt2.Add(0);
            genericTestInt2.Add(0);
            genericTestInt2.Add(0);
            genericTestInt2.Add(0);
            genericTestInt.Add(11);
            genericTestInt.Add(10);
            genericTestInt.Add(9);
            genericTestInt.Add(8);
            genericTestInt.Print();
            Console.ReadLine();
            genericTestInt.Remove(10);
            genericTestInt.Print();
            Console.ReadLine();
            string myString = genericTestInt.ArrayToString();
            Console.WriteLine(myString);
            Console.ReadLine();
            genericTestInt.Add(22, 21);
            genericTestInt.Print();
            Console.ReadLine();
            Console.WriteLine("Print each item in list with foreach loop:");
            foreach (int number in genericTestInt)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
            Console.WriteLine("There is this many items in array: {0}", genericTestInt.Count());
            Console.ReadLine();
            genericTestInt.Zipper(genericTestInt2);
            genericTestInt.Print();
            Console.ReadLine();
            
            GenericStoreInArray<double> genericTestInt4 = new GenericStoreInArray<double>(0);
            genericTestInt4.Add(1.2);
            genericTestInt4.Add(1.3);
            genericTestInt4.Add(1.4);
            genericTestInt4.Add(1.5);
            GenericStoreInArray<string> genericTestInt3 = new GenericStoreInArray<string>(0);
            genericTestInt3.Add("Hello");
            genericTestInt3.Add("My");
            genericTestInt3.Add("name");
            genericTestInt3.Add("is");
            genericTestInt3.Add("Kris");

            GenericStoreInArray<int> result = new GenericStoreInArray<int>(0);
            result = genericTestInt + genericTestInt2;
            result.Print();
            Console.ReadLine();

            result.AddAt(100, 2);
            result.Print();
            Console.ReadLine();

            result.RemoveAt(4);
            result.Print();
            Console.ReadLine();

            result.Sort();
            result.Print();
            Console.ReadLine();

            GenericStoreInArray<string> string1 = new GenericStoreInArray<string>(0) { "Lion", "Zebra", "Dog", "Cat" };
            GenericStoreInArray<string> string2 = new GenericStoreInArray<string>(0) { "Laugh", "Scream", "Yell", "Sneeze" };
            GenericStoreInArray<string> string4 = new GenericStoreInArray<string>(0) { "Stamp", "Silly", "Suzy", "Swat" };
            GenericStoreInArray<string> string3 = new GenericStoreInArray<string>(0) { "NOSE", "XYLOPHONE", "POTATO", "YAWN", "QUIL", "RABBIT", "SNAIL",
                "TURTLE", "UMBRELLA", "VOLE", "WOLF", "ZEBRA", "ANIMAL", "BEAVER", "COW", "DOG", "ELEPHANT",
                "FARM", "GARY", "HOWARD", "ISREAL", "JIMMY", "KOHLS", "LEMON", "MANDARIN" };

            string3.Print();
            Console.ReadLine();
            string3.Sort();
            string3.Print();
            Console.ReadLine();

            result = result - genericTestInt2;
            result.Print();
            Console.ReadLine();

            result.HappyNumbers();
            Console.ReadLine();
        }
    }
}
