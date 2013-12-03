/* 7.	Создать класс для работы с двумерным массивом вещественных чисел. Разработать следующие элементы класса:
    a.	Поля:
    •	double [][] DoubleArray;
    •	int n, m.
    b.	Конструктор, позволяющий создать массив размерности n×m.
    c.	Методы, позволяющие:
    •	ввести элементы массива с клавиатуры;
    •	вывести элементы массива на экран;
    •	отсортировать элементы каждой строки массива в порядке убывания.
    d.	Свойства:
    •	возвращающее общее количество элементов в массиве (доступное только для чтения);
    •	позволяющее увеличить значение всех элементов массива на скаляр (доступное только для записи).
   7.	Добавить в класс для работы с двумерным массивом вещественых чисел:
    a.	Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
    b.	Перегрузку:
    •	операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов массива на 1;
    •	констант true и false: обращение к экземпляру класса дает значение true, если каждая строка массива упорядоченна по возрастанию, иначе false.
    •	операции *: позволяющей умножить два массива соответствующих размерностей.
    •	преобразования класса массив в ступенчатый массив (и наоборот).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleArray
{
    class ArrayDouble
    {
        // Поля: •	double [][] DoubleArray; •	int n, m.
        int n, m;
        double[,] DoubleArray;

        // Конструктор, позволяющий создать массив размерности n×m.
        public ArrayDouble(int n, int m)
        {
            this.n = n;
            this.m = m;

            DoubleArray = new double[n,m];
        }

        public ArrayDouble() { }

        // Ввести элементы массива с клавиатуры;
        public void Enter_Array()
        {
            for(int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write("Введите элемент DoubleArray[{0},{1}] = ", i, j);
                    DoubleArray[i, j] = double.Parse(Console.ReadLine());
                }
        }

        // Вывести элементы массива на экран
        public void Display_Array()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(" " + DoubleArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Отсортировать элементы каждой строки массива в порядке убывания.
        public void Sort()
        {
            bool a;
            double temp;
            for (int i = 0; i < n; i++)
            {
                a = true;
                while (a)
                {
                    a = false;
                    for (int j = 0; j < m - 1; j++)
                    {
                        if (DoubleArray[i, j] < DoubleArray[i, j + 1])
                        {
                            temp = DoubleArray[i, j];
                            DoubleArray[i, j] = DoubleArray[i, j + 1];
                            DoubleArray[i, j + 1] = temp;
                            a = true;
                        }
                    }
                }
            }
        }

        // Возвращающее общее количество элементов в массиве (доступное только для чтения);
        public int Total_Elements
        {
            get
            {
                return n * m;
            }
        }

        // Позволяющее увеличить значение всех элементов массива на скаляр (доступное только для записи).
        public double Array_Scal
        {
            set
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        DoubleArray[i, j] *= value;
            }
        }

        //Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
        public double this[int i, int j]
        {
            get { return DoubleArray[i, j]; }
        }

        // Операция ++: одновременно увеличивает значение всех элементов массива на 1;
        public static ArrayDouble operator ++(ArrayDouble obj)
        {
            for (int i = 0; i < obj.n; i++)
                for (int j = 0; j < obj.m; j++)
                    obj.DoubleArray[i, j] = obj.DoubleArray[i, j] + 1;
            return obj;           
        }

        // Операция --: одновременно уменьшает значение всех элементов массива на 1;
        public static ArrayDouble operator --(ArrayDouble obj)
        {
            for (int i = 0; i < obj.n; i++)
                for (int j = 0; j < obj.m; j++)
                    obj.DoubleArray[i, j] = obj.DoubleArray[i, j] - 1;
            return obj;
        }

        // константа true: обращение к экземпляру класса дает значение true, если каждая строка массива упорядоченна по возрастанию, иначе false.
        public static bool operator true(ArrayDouble obj)
        {
            int count = 0;
            for(int i = 0; i < obj.n; i++)
                for(int j = 0; j < obj.m - 1; j++)
                    if(obj.DoubleArray[i,j] > obj.DoubleArray[i, j+1])
                        count++;
            if (count == 0)
                return true;
            return false;
        }

        // Константа false: обращение к экземпляру класса дает значение true, если каждая строка массива упорядоченна по возрастанию, иначе false.
        public static bool operator false(ArrayDouble obj)
        {
            int count = 0;
            for (int i = 0; i < obj.n; i++)
                for (int j = 0; j < obj.m - 1; j++)
                    if (obj.DoubleArray[i, j] > obj.DoubleArray[i, j + 1])
                        count++;
            if (count != 0)
                return false;
            return true;
        }

        // Преобразования класса массив в ступенчатый массив (и наоборот)
        public static explicit operator double[][](ArrayDouble obj)
        {
            double[][] array = new double[obj.n][];
            for (int i = 0; i < obj.n; i++)
            {
                array[i] = new double[obj.m];
                for (int j = 0; j < obj.m; j++)
                    array[i][j] = obj.DoubleArray[i, j]; 
            }
            return array;
        }

        public static explicit operator ArrayDouble(double[][] array)
        {
            int n, m;
            n = array.Length;
            m = array[0].Length;
            ArrayDouble obj = new ArrayDouble(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    obj.DoubleArray[i, j] = array[i][j];
            }
            return obj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;

            Console.WriteLine("Введите колчество столбцов: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите колчество строк: ");
            m = int.Parse(Console.ReadLine());
            ArrayDouble array = new ArrayDouble(n, m);

            Console.WriteLine("Ввод массива:");
            array.Enter_Array();

            Console.WriteLine("\nПоказать массив:");
            array.Display_Array();

            Console.WriteLine("\nОтсортировать массив в порядке убывания:");
            array.Sort();
            Console.WriteLine("Показать отсортированный массив:");
            array.Display_Array();

            Console.WriteLine("Операция ++: одновременно увеличивает значение всех элементов массива на 1:");
            array++;
            array.Display_Array();

            Console.WriteLine("Операция --: одновременно уменьшает значение всех элементов массива на 1");
            array--;
            array.Display_Array();

            Console.WriteLine("\nКонстанты true и false:" + 
                "обращение к экземпляру класса дает значение true, если каждая строка массива упорядоченна по возрастанию, иначе false.\n");
            if (array) Console.WriteLine("Строки массива упорядочены по возростаню.");
            else
                Console.WriteLine("Строки массива не упорядочены по возростанию.");

            Console.ReadLine();
        }
    }
}
