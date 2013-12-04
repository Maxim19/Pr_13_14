/*  8.	Создать класс для работы сo строками. Разработать следующие элементы класса:
        a.	Поля:
          •	StringBuilder Line;
          •	int n.
        b.	Конструктор, позволяющий создать строку из n символов.
        c.	Методы, позволяющие:
          •	подсчитать количество пробелов в строке;
          •	заменить в строке все прописные символы на строчные;
          •	удалить из строки все знаки препинания.
        d.	Свойства:
          •	возвращающее общее количество элементов в строке (доступное только для чтения);
          •	позволяющее установить значение поля, в соответствии с введенным значением строки с клавиатуры, 
            а также получить значение данного поля (доступно для чтения и записи)
    8.	Добавить в класс для работы сo строками:
        a.	Индексатор, позволяющий по индексу обращаться к соответствующему символу строки.
        b.	Перегрузку:
        •	операции унарного + (-): преобразующей строку к строчным (прописным) символам;
        •	констант true и false: обращение к экземпляру класса дает значение true, если строка не пустая, иначе false.
        •	операции &: возвращает значение true, если строковые поля двух объектов посимвольно равны (без учета регистра), иначе false;
        •	преобразования класса-строка в тип string (и наоборот).  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyString
{
    class MyString
    {
        // Поля: •	StringBuilder Line;•	int n.
        int n;
        StringBuilder Line;

        // Конструктор, позволяющий создать строку из n символов.
        public MyString(string str)
        {
            Line = new StringBuilder(str);
            n = str.Length;
        }

        // Подсчитать количество пробелов в строке
        public int Space_Count()
        {
            int count = 0;
            for (int i = 0; i < Line.Length; i++)
                if (char.IsWhiteSpace(Line[i])) count++;
            return count;
        }

        // Заменить в строке все прописные символы на строчные;
        public string Line_ToLower()
        {
            return Line.ToString().ToLower();
        }

        // Удалить из строки все знаки препинания.
        public string Punctuation()
        {
            return Line.ToString().Replace(",", "").Replace("!", "").Replace(".", "").Replace(";", "").Replace(":", "");
        }

        //Свойства: возвращающее общее количество элементов в строке (доступное только для чтения);
        public int N
        {
            get { return Line.Length; }
        }

        //Свойства: позволяющее установить значение поля, в соответствии с введенным значением строки с клавиатуры, 
        //а также получить значение данного поля (доступно для чтения и записи)
        public int Set_N
        {
            get { return n; }
            set { n = value; }
        }

        //Индексатор, позволяющий по индексу обращаться к соответствующему символу строки.
        public char this[int index]
        {
            get { return Line[index]; }
        }

        //Преобразования класса-строка в тип string (и наоборот).
        public static explicit operator string(MyString obj)
        {
            return obj.Line.ToString();
        }

        public static explicit operator MyString(string obj)
        {
            return new MyString(obj);
        }

        //Операции унарного +: преобразующей строку к строчным символам;
        public static string operator +(MyString obj)
        {
            return obj.Line.ToString().ToLower();
        }

        //Операция унарного -: преобразующей строку к прописным символам;
        public static string operator -(MyString obj)
        {
            return obj.Line.ToString().ToUpper();
        }

        //Констант true и false: обращение к экземпляру класса дает значение true, если строка не пустая, иначе false.
        public static bool operator true(MyString obj)
        {
            if (obj.Line.Length != 0)
                return true;
            return false; 
        }
        public static bool operator false(MyString obj)
        {
            if (obj.Line.Length == 0)
                return true;
            return false;
        }

        //операции &: возвращает значение true, если строковые поля двух объектов посимвольно равны (без учета регистра), иначе false;
        public static bool operator &(MyString obj1, MyString obj2)
        {
            return obj1.Line.ToString().ToUpper().Equals(obj2.Line.ToString().ToUpper());                
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();
            MyString Line = new MyString(str);

            Console.WriteLine("Количество пробелов в строке - {0}", Line.Space_Count());

            Console.WriteLine("Заменить в строке все прописные символы на строчные: \n{0}", Line.Line_ToLower());

            Console.WriteLine("Удалить из строки все знаки препинания: \n{0}", Line.Punctuation());

            Console.WriteLine("Количество символов в строке: {0}", Line.N);

            Console.WriteLine(@"Перегрузка операции &: возвращает значение true, если строковые поля двух 
объектов посимвольно равны (без учета регистра), иначе false:");
            Console.WriteLine("Введите строку:");
            str = Console.ReadLine();
            MyString Line2 = new MyString(str);
            Console.WriteLine("Равны ли строки? {0}", Line & Line2);

            Console.WriteLine("Преобразование строки к строчным символам : \n {0}", -Line);

            Console.WriteLine("Преобразование строки к прописным символам: \n {0}", +Line);

            if (Line)
                Console.WriteLine("Строка не пустая.");
            else
                Console.WriteLine("Строка пустая.");

            Console.ReadLine();
        }
    }
}
