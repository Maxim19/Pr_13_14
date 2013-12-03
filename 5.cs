/*  5.	Создать класс для работы с одномерным массивом целых чисел. Разработать следующие элементы класса:
        a.  Поля:
        •	int [] IntArray;
        •	int n.
        b. Конструктор, позволяющий создать массив размерности n.
        c. Методы, позволяющие:
        •	ввести элементы массива с клавиатуры;
        •	вывести элементы массива на экран;
        •	отсортировать элементы массива в порядке возрастания.
        d. Свойства:
        •	возвращающее размерность массива (доступное только для чтения);
        •	позволяющее домножить все элементы массива на скаляр (доступное только для записи).
    5.	Добавить в класс для работы с одномерным массивом целых чисел: 
        a.	Индексатор, позволяющий по индексу обращаться к соответствующему элементу массива.
        b.	Перегрузку:
        •	операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов массива на 1;
        •	операции !: возвращает значение true, если элементы массива не упорядочены по возрастанию, иначе false;
        •	операции бинарный *:  домножить все элементы массива на скаляр;
        •	преобразования класса массив в одномерный массив (и наоборот).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Array
{
    class ArrayInt
    {
        //Поля: •	int [] IntArray; •	int n.
        int[] IntArray;
        int n;

        //Конструктор, позволяющий создать массив размерности n.
        public ArrayInt(int n)
        {
            this.n = n;
            IntArray = new int[n];
        }

        // Ввести элементы массива с клавиатуры;
        public void ReadArray()
        {
            Console.WriteLine("Введите элементы массива");

            for (int i = 0; i < IntArray.Length; i++)
            {
                Console.Write("IntArray[{0}] = ", i);
                IntArray[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        //вывести элементы массива на экран;
        public void Show()
        {
            Console.WriteLine("\nМассив:");

            foreach (int i in IntArray)
                Console.Write(" {0} ", i);
            Console.WriteLine();
        }

        //отсортировать элементы массива в порядке возрастания.
        public void Sort()
        {
            int temp;
            bool a = true;
            while (a)
            {
                a = false;
                for (int j = 0; j < IntArray.Length - 1; j++)
                {
                    if (IntArray[j] > IntArray[j + 1])
                    {
                        temp = IntArray[j + 1];
                        IntArray[j + 1] = IntArray[j];
                        IntArray[j] = temp;
                        a = true;
                    }
                }
            }
        }

        //возвращающее размерность массива (доступное только для чтения);
        public int N
        {
            get
            {
                return n;
            }
        }

        //позволяющее домножить все элементы массива на скаляр (доступное только для записи).
        public int ScalArray
        {
            set
            {
                for (int i = 0; i < IntArray.Length; i++)
                    IntArray[i] = IntArray[i] * value;
            }
        }

        //Индексатор, позволяющий по индексу обращаться к соответствующему элементу массива.
        public int this[int index]
        {
            get { return IntArray[index]; }
        }

        //операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов массива на 1;
        public static ArrayInt operator ++(ArrayInt array)
        {
            ArrayInt obj = new ArrayInt(array.IntArray.Length);
            for (int i = 0; i < array.IntArray.Length; i++)
            {
                obj.IntArray[i] = array.IntArray[i] + 1;
            }
            return obj;
        }

        public static ArrayInt operator --(ArrayInt array)
        {
            ArrayInt obj = new ArrayInt(array.IntArray.Length);
            for (int i = 0; i < array.IntArray.Length; i++)
            {
                obj.IntArray[i] = array.IntArray[i] - 1;
            }
            return obj;
        }

        //операции !: возвращает значение true, если элементы массива не упорядочены по возрастанию, иначе false;
        public static bool operator !(ArrayInt array)
        {
            bool a = false;
            for (int i = 0; i < array.IntArray.Length - 1; i++)
                if (array.IntArray[i] > array.IntArray[i + 1])
                    a = true;
            return a;
        }

        // операции бинарный *:  домножить все элементы массива на скаляр;
        public static ArrayInt operator *(ArrayInt array, int scal)
        {
            for (int i = 0; i < array.IntArray.Length; i++)
            {
                array.IntArray[i] *= scal;
            }
            return array;
        }

        public static ArrayInt operator *(int scal, ArrayInt array)
        {
            for (int i = 0; i < array.IntArray.Length; i++)
            {
                array.IntArray[i] *= scal;
            }
            return array;
        }

        //преобразования класса массив в одномерный массив (и наоборот)
        public static explicit operator ArrayInt(int[] array)
        {
            ArrayInt obj = new ArrayInt(array.Length);
            array.CopyTo(obj.IntArray, 0);
            return obj;
        }

        public static explicit operator int[](ArrayInt obj)
        {
            return obj.IntArray;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());

            ArrayInt obj = new ArrayInt(n);
            Console.WriteLine("\nВведите элементы массива с клавиатуры:\n");
            obj.ReadArray();
            obj.Show();

            Console.WriteLine("\nОтсортировать элементы массива в порядке возрастания:");
            obj.Sort();
            obj.Show();

            Console.WriteLine("\nРазмерность массива: " + obj.N);

            Console.WriteLine("\nДомножить все элементы массива на скаляр (5)");
            obj.ScalArray = 5;
            obj.Show();

            Console.WriteLine("\nОперации ++: одновременно увеличивает значение всех элементов массива на 1:");
            obj++;
            obj.Show();

            Console.WriteLine("\nОперации --: одновременно уменьшает значение всех элементов массива на 1:");
            obj--;
            obj.Show();

            if (!obj) Console.WriteLine("\nМассив не упорядочен по возростанию.");
            else
                Console.WriteLine("\nМассив упорядочен по возростанию.");

            Console.WriteLine("\nОперации бинарный *:  домножить все элементы массива на скаляр (obj * 5):");
            obj = obj * 5;
            obj.Show();

            Console.WriteLine("\nОперации бинарный *:  домножить все элементы массива на скаляр (5 * obj):");
            obj = 5 * obj;
            obj.Show();

            Console.ReadLine();
        }
    }
}
