using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsList
{
    class GenericStoreInArray<T> : IEnumerable<T>, IComparable
    {
        T[] genericArray;

        public GenericStoreInArray(int size)
        {
            genericArray = new T[size];
        }
        public GenericStoreInArray(T[] copy)
        {
            genericArray = copy;
        }

        public T[] GetArray()
        {
            return genericArray;
        }
        public void Add(T itemToAdd)
        {
            T[] genericArrayTemporary = new T[genericArray.Length + 1];
            for (int i = 0; i < genericArray.Length; i++)
            {
                genericArrayTemporary[i] = genericArray[i];
            }
            genericArrayTemporary[genericArray.Length] = itemToAdd;
            genericArray = genericArrayTemporary;
        }
        public void AddAtBeginning(T itemToAdd)
        {
            T[] genericArrayTemporary = new T[genericArray.Length + 1];
            for (int i = 0; i < genericArray.Length; i++)
            {
                genericArrayTemporary[i + 1] = genericArray[i];
            }
            genericArrayTemporary[0] = itemToAdd;
            genericArray = genericArrayTemporary;
        }
        public void AddAt(T itemToAdd, int position)
        {
            T[] genericArrayTemporary = new T[genericArray.Length + 1];
            for (int i = 0; i < genericArray.Length; i++)
            {
                if(i != position)
                {
                    genericArrayTemporary[i] = genericArray[i];
                }
                else
                {
                    genericArrayTemporary[i] = itemToAdd;
                    i++;
                }
            }
            genericArray = genericArrayTemporary;
        }
        public void Add(T itemToAdd, T itemToAdd2)
        {
            Add(itemToAdd);
            Add(itemToAdd2);
        }
        public void Remove(T itemToRemove)
        {
            bool notFound = true;
            T[] genericArrayTemporary = new T[genericArray.Length - 1];
            for (int i = 0; i < genericArray.Length; i++)
            {
                if (notFound)
                {
                    if (genericArray[i].Equals(itemToRemove))
                    {
                        notFound = false;
                    }
                    else
                    {
                        genericArrayTemporary[i] = genericArray[i];
                    }
                }
                else
                {
                    genericArrayTemporary[i - 1] = genericArray[i];
                }
            }
            genericArray = genericArrayTemporary;
        }
        public void Remove(T itemToRemove, T itemToRemove2)
        {
            Remove(itemToRemove);
            Remove(itemToRemove2);
        }
        public void RemoveAt(int position)
        {
            T[] temporary = new T[genericArray.Length - 1];
            for (int i = 0; i < genericArray.Length - 1; i++)
            {
                if(i != position)
                {
                    temporary[i] = genericArray[i];
                }
                else
                {
                    temporary[i - 1] = genericArray[i];
                }

            }
            genericArray = temporary;
        }
        public string ArrayToString()
        {
            string temporaryString = "";
            for (int i = 0; i < genericArray.Length; i++)
            {
                temporaryString = temporaryString + " " + genericArray[i];
            }
            return temporaryString;
        }
        public int Count()
        {
            int index = 0;
            for (int i = 0; i < genericArray.Length; i++)
            {
                index++;
            }
            return index;
        }
        public T GetValue(int position)
        {
            return genericArray[position];
        }
        public void Zipper(GenericStoreInArray<T> listToZipper)
        {
            T[] genericArrayTemporary2 = new T[genericArray.Length];
            T[] genericArrayTemporary3 = new T[0];
            genericArrayTemporary2 = genericArray;
            genericArray = genericArrayTemporary3;
            for (int i = 0; i < genericArrayTemporary2.Length || i < listToZipper.Count(); i++)
            {
                if (i < genericArrayTemporary2.Length)
                {
                    Add(genericArrayTemporary2[i]);
                }
                if (i < listToZipper.Count())
                {
                    Add(GetValue(i));
                }
            }
        }
        public static GenericStoreInArray<T> operator +(GenericStoreInArray<T> itemOne, GenericStoreInArray<T> itemTwo)
        {
            GenericStoreInArray<T> temporary = new GenericStoreInArray<T>(0);

            for (int i = 0; i < itemOne.Count(); i++)
            {
                temporary.Add(itemOne.genericArray[i]);
            }
            for (int i = 0; i < itemTwo.Count(); i++)
            {
                temporary.Add(itemTwo.genericArray[i]);
            }
            return temporary;
        }
        public static GenericStoreInArray<T> operator -(GenericStoreInArray<T> itemOne, GenericStoreInArray<T> itemTwo)
        {
            for (int i = 0; i < itemOne.Count(); i++)
            {
                for (int p = 0; p < itemTwo.Count(); p++)
                {
                    if (itemOne.genericArray[i].Equals(itemTwo.genericArray[p]))
                    {
                        itemOne.Remove(itemTwo.genericArray[p]);
                    }
                }
            }
            return itemOne;
        }
        public void Sort()
        {
            T temp;
                for (int i = 0; i < genericArray.Length; i++)
                {
                    for (int p = 0; p < genericArray.Length; p++)
                    {
                        if (Comparer.Default.Compare(genericArray[i], genericArray[p]) < 0)
                        {
                            temp = genericArray[i];
                            genericArray[i] = genericArray[p];
                            genericArray[p] = temp;
                        }
                    }
                }
        }
        public void HappyNumbers()
        {
            for (int i = 0; i <= 1000; i++)
            {
               if(ishappy(i) == true)
                {
                    Console.WriteLine("{0} is a Happy Number!", i);
                }
            }
        }
        public static bool ishappy(int n)
        {
            List<int> numbers = new List<int>();
            int sum = 0;
            while (n != 1)
            {
                if (numbers.Contains(n))
                {
                    return false;
                }
                numbers.Add(n);
                while (n != 0)
                {
                    int digit = n % 10;
                    sum += digit * digit;
                    n /= 10;
                }
                n = sum;
                sum = 0;
            }
            return true;
        }
        public int Compare(T one, T two)
        {
            return 0;
        }
        public void Print(GenericStoreInArray<T> printThis)
        {
            foreach (T item in printThis)
            {
                Console.WriteLine(item);
            }
        }
        public void Print()
        {
            foreach(T item in genericArray)
            {
                Console.WriteLine(item);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < genericArray.Length; i++)
            {
                yield return genericArray[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool CompareTo(T item1, T item2)
        {
            int thing1;
            int.TryParse(item1.ToString(), out thing1);
            int thing2;
            int.TryParse(item2.ToString(), out thing2);
            if  (thing1 < thing2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
