/*  1.	Создать класс Rectangle, разработав следующие элементы класса:
        a.	Поля:
            •	int a, b;
        b.  Конструктор, позволяющий создать экземпляр класса  с заданными длинами сторон.
        c.	Методы, позволяющие:
            •	вывести длины сторон прямоугольника на экран;
            •	расчитать периметр прямоугольника;
            •	расчитать площадь прямоугольника.
        d.	Свойства:
            •	получить-установить длины сторон прямоугольника (доступное для чтения и записи);
            •	позволяющее установить, является ли данный прямоугольник квадратом (доступное только для чтения).
    2.	В класс Rectangle добавить:
        a.	Индексатор, позволяющий по индексу 0 обращаться к полю a, по индексу 1 – к полю b, при других значениях индекса выдается сообщение об ошибке.
        b.	Перегрузку:
            •	операции ++ (--): одновременно увеличивает (уменьшает) значение полей a и b;
            •	констант true и false: обращение к экземпляру класса дает значение true, если прямоугольник с заданными длинами сторон является квадратом, иначе false;
            •	операции *:  одновременно домножает поля a и b  на скаляр;
            •	преобразования типа Rectangle в string (и наоборот).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class Rectangle
    {
        // Поля: int a, b;
        int a, b;

        // Конструктор, позволяющий создать экземпляр класса  с заданными длинами сторон.
        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        // вывести длины сторон прямоугольника на экран;
        public void Show()
        {
            Console.WriteLine("Стороны прямоугольника: a = {0}, b = {1}", a, b);
        }

        // расчитать периметр прямоугольника;
        public int Perimeter()
        {
            return (a + b) * 2;
        }

        // расчитать площадь прямоугольника.
        public int Area()
        {
            return a * b;
        }

        //Свойства: получить-установить длины сторон прямоугольника (доступное для чтения и записи);
        public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        //Свойства: позволяющее установить, является ли данный прямоугольник квадратом (доступное только для чтения).
        public bool isSquare
        {
            get
            {
                if (a == b)
                    return true;
                return false;
            }
        }

        //Индексатор, позволяющий по индексу 0 обращаться к полю a, по индексу 1 – к полю b, при других значениях индекса выдается сообщение об ошибке.
        public int this[int index]
        {
            get 
            {
                switch (index)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    default:
                        throw new Exception("Error");
                }
            }
        }

        //операции ++ (--): одновременно увеличивает (уменьшает) значение полей a и b;
        public static Rectangle operator ++(Rectangle obj)
        {
            obj.a++;
            obj.b++;
            return obj;
        }

        public static Rectangle operator --(Rectangle obj)
        {
            obj.a--;
            obj.b--;
            return obj;
        }

        //констант true и false: обращение к экземпляру класса дает значение true, если прямоугольник с заданными длинами сторон является квадратом, иначе false;
        public static bool operator false(Rectangle obj)
        {
            if (obj.a == obj.b)
                return true;
            return false;
        }

        public static bool operator true(Rectangle obj)
        {
            if (obj.a == obj.b)
                return true;
            return false;
        }

        //операции *:  одновременно домножает поля a и b  на скаляр;
        public static Rectangle operator *(Rectangle obj, int scal)
        {
            obj.a *= scal;
            obj.b *= scal;
            return obj;
        }

        public static Rectangle operator *(int scal, Rectangle obj)
        {
            obj.a *= scal;
            obj.b *= scal;
            return obj;
        }

        //преобразования типа Rectangle в string
        public static explicit operator String(Rectangle obj)
        {
            return obj.a + ", " + obj.b;
        }

        public static explicit operator Rectangle(string str)
        {
            string[] q = str.Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            Rectangle obj = new Rectangle(0, 0);
            obj.a = int.Parse(q[0]);
            obj.b = int.Parse(q[1]);
            return obj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сторону a прямоугольника: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите сторону b прямоугольника: ");
            int b = int.Parse(Console.ReadLine());

            Rectangle obj = new Rectangle(a, b);
            obj.Show();

            Console.WriteLine("\nПериметр прямоугольника: {0}", obj.Perimeter());

            Console.WriteLine("\nПлощадь прямоугольника: {0}", obj.Area());

            Console.WriteLine("\nЯвляется ли этот прямоугольник квадаратом? {0}", obj.isSquare);

            Console.WriteLine("\nОперация ++: одновременно увеличивает значение полей a и b:");
            obj++;
            obj.Show();

            Console.WriteLine("\nОперация --: одновременно уменьшает значение полей a и b:");
            obj--;
            obj.Show();

            Console.WriteLine("\nКонстант true и false: обращение к экземпляру класса дает значение true, если прямоугольник с заданными длинами сторон является квадратом, иначе false:");
            if (obj)
                Console.WriteLine("Квадрат\n");
            else
                Console.WriteLine("Не квадрат\n");

                Console.WriteLine("\nОперация *:  одновременно домножает поля a и b  на скаляр (Rectangle * 5):");
            obj = obj * 5;
            obj.Show();

            Console.WriteLine("\nОперация *:  одновременно домножает поля a и b  на скаляр (5 * Rectangle):");
            obj = 5 * obj;
            obj.Show();

            Console.WriteLine("\nПреобразования типа Rectangle в string: ");
            string str = (string)obj;
            Console.WriteLine(str + "\n");

            Console.WriteLine("\nПреобразования типа string в Rectangle: ");
            Rectangle new_obj = (Rectangle)str;
            new_obj.Show();

            Console.ReadLine();
        }
    }
}
