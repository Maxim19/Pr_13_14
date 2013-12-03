/*  6.	Создать класс для работы с двумерным массивом целых чисел. Разработать следующие элементы класса: 
        a.	Поля:
        •	    int [,] IntArray;
        •	    int n.
        b.	Конструктор, позволяющий создать массив размерности n×n.
        c.	    Методы, позволяющие:
        •	    ввести элементы массива с клавиатуры;
        •	    вывести элементы массива на экран;
        •	    вычислить сумму элеметов i-того столбца.
        d.	    Свойства:
        •	    позволяющее вычислить количество нулевых элементов в массиве (доступное только для чтения);
        •	    позволяющее установить значение всех элементы главной диагонали массива равное скаляру (доступное только для записи).
    6.	Добавить в класс для работы с двумерным массивом целых чисел:
        a.	    Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
        b.	    Перегрузку:
        •	    операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов массива на 1;
        •	    констант true и false: обращение к экземпляру класса дает значение true, если двумерный массив является квадратным;
        •	    операции бинарный +: позволяющей сложить два массива соответсвующих размерностей;
        •	    преобразования класса массив в двумерный массив (и наоборот).*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayDouble
{
    class ArrayDouble
    {
        // Поля: •	    int [,] IntArray; •	    int n.
        int[,] IntArray;
        int n;

        // Конструктор, позволяющий создать массив размерности n×n.
        public ArrayDouble(int n)
        {
            this.n = n;
            IntArray = new int[n, n];
        }

        //ввести элементы массива с клавиатуры;
        public void ReadArray()
        {
            Console.WriteLine("Введите элементы массива:");
            for(int i=0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("IntArray[{0},{1}] = ", i, j);
                    IntArray[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            Console.WriteLine("Длина массива: " + IntArray.Length);
        }

        //вывести элементы массива на экран;
        public void Show()
        {
            Console.WriteLine("Массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(" [{0},{1}] = {2}", i, j, IntArray[i, j]);
                Console.WriteLine();
            }
        }

        //вычислить сумму элеметов i-того столбца.
        public int Calculate_Row(int k)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += IntArray[i, k];
            return sum;
        }

        //позволяющее вычислить количество нулевых элементов в массиве (доступное только для чтения);
        public int Zero_Element
        {
            get 
            {
                int count = 0;
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (IntArray[i, j] == 0)
                            count++;
                    }
                return count;
            }
        }

        // позволяющее установить значение всех элементы главной диагонали массива равное скаляру (доступное только для записи).
        public int Scal
        {
            set
            {
                for (int i = 0; i < n; i++)
                    IntArray[i, i] = value;
            }
        }

        //Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
        public int this[int index1, int index2]
        {
            get { return IntArray[index1, index2]; }
        }

        //операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов массива на 1;
        public static ArrayDouble operator ++(ArrayDouble obj)
        {
            for (int i = 0; i < obj.n; i++)
                for (int j = 0; j < obj.n; j++)
                    obj.IntArray[i, j] = obj.IntArray[i, j] + 1;
            return obj;
        }

        public static ArrayDouble operator --(ArrayDouble obj)
        {
            for (int i = 0; i < obj.n; i++)
                for (int j = 0; j < obj.n; j++)
                    obj.IntArray[i, j] = obj.IntArray[i, j] - 1;
            return obj;
        }

        // Преобразования класса массив в двумерный массив (и наоборот).
        public static explicit operator int[,](ArrayDouble obj)
        {
            return obj.IntArray;
        }

        public static explicit operator ArrayDouble(int[,] array)
        {
            ArrayDouble obj = new ArrayDouble(array.Length);
            array.CopyTo(obj.IntArray, 0);
            return obj;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            ArrayDouble array = new ArrayDouble(n);

            Console.WriteLine("\nВведите массив: ");
            array.ReadArray();

            Console.WriteLine("\nВывести элементы массива на экран:");
            array.Show();

            Console.WriteLine("\nВведите номер столбца, сумму которого необходимо вычислить:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Summ = {0}", array.Calculate_Row(row));

            Console.WriteLine("\nКоличество нулевых элементов: {0}", array.Zero_Element);

            Console.WriteLine("\nУстановить значение всех элементы главной диагонали массива равное скаляру (5): ");
            array.Scal = 5;
            array.Show();

            Console.WriteLine("\nОперация ++: одновременно увеличивает значение всех элементов массива на 1;");
            array++;
            array.Show();

            Console.WriteLine("\nОперация --: одновременно уменьшает значение всех элементов массива на 1;");
            array--;
            array.Show();

            Console.ReadLine();

        }
    }
}
