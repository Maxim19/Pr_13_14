/* 1.        Создать класс Point, разработав следующие элементы класса:
a.        Поля:
•        int x, y;
b.        Конструкторы, позволяющие создать экземпляр класса:
•        с нулевыми координатами;
•        с заданными координатами.
c.        Методы, позволяющие:
•        вывести координаты точки на экран;
•        рассчитать расстояние от начала координат до точки;
•        переместить точку на плоскости на вектор (a, b).
d.        Свойства:
•        получить-установить координаты точки (доступное для чтений и записи);
•        позволяющие умножить координаты точки на скаляр (доступное только для записи).
1.        В класс Point добавить:
a.        Индексатор, позволяющий по индексу 0 обращаться к полю x, по индексу 1 – к полю y, при других значениях индекса выдается сообщение об ошибке.
b.        Перегрузку:
•        операции ++ (--): одновременно увеличивает (уменьшает) значение полей х и у на 1;
•        констант true и false: обращение к экземпляру класса дает значение true, если значение полей x и у совпадает, иначе false;
•        операции бинарный +: одновременно добавляет к полям х и у значение скаляра;
•        преобразования типа Point в string (и наоборот).
*/
using System;

namespace Test
{
    class Point
    {
        // Поля: int x, y;
        int x, y;

        // Конструкторы, позволяющие создать экземпляр класса: с нулевыми координатами; с заданными координатами.
        public Point(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        // Методы, позволяющие:        вывести координаты точки на экран;
        public void Show() { Console.WriteLine("x = {0}, y = {1}", x, y); }

        // рассчитать расстояние от начала координат до точки;
        public double Origin() { return Math.Sqrt(x * x + y * y); }

        // переместить точку на плоскости на вектор (a, b).
        public void Displacement(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        // Свойства: получить-установить координаты точки (доступное для чтений и записи);
        public int X
        {
            set { x = value; }
            get { return x; }
        }

        public int Y
        {
            set { y = value; }
            get { return y; }
        }

        // позволяющие умножить координаты точки на скаляр (доступное только для записи).
        public int MultScalX
        {
            set { x *= value; }
        }

        public int MultScalY
        {
            set { y *= value; }
        }

        // Перегрузку: операции ++ (--): одновременно увеличивает (уменьшает) значение полей х и у на 1;
        public static Point operator --(Point obj)
        {
            obj.x -= 1;
            obj.y -= 1;
            return obj;
        }

        public static Point operator ++(Point obj)
        {
            obj.x += 1;
            obj.y += 1;
            return obj;
        }

        // констант true и false: обращение к экземпляру класса дает значение true, если значение полей x и у совпадает, иначе false;
        public static bool operator false(Point obj)
        {
            if (obj.x != obj.y)
                return false;
            return true;
        }

        public static bool operator true(Point obj)
        {
            if (obj.x == obj.y)
                return true;
            return false;
        }

        // операции бинарный +: одновременно добавляет к полям х и у значение скаляра;
        public static Point operator +(Point obj, int scal)
        {
            obj.x += scal;
            obj.y += scal;
            return obj;
        }

        public static Point operator +(int scal, Point obj)
        {
            obj.x += scal;
            obj.y += scal;
            return obj;
        }

        // Индексатор, позволяющий по индексу 0 обращаться к полю x, по индексу 1 – к полю y, при других значениях индекса выдается сообщение об ошибке.
        public int this[int i]
        {
            get
            {
                if (i == 0)
                    return x;
                if (i == 1) return y;
                throw new Exception("Error");
            }
        }

        // преобразования типа Point в string (и наоборот).
        public static explicit operator String(Point obj)
        {
            return obj.x + ", " + obj.y;
        }

        public static explicit operator Point(string str)
        {
            string[] q = str.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Point obj = new Point();
            obj.x = int.Parse(q[0]);
            obj.y = int.Parse(q[1]);
            return obj;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int x;
            int y;

            x = ReadCoord('x');
            y = ReadCoord('y');

            Point point = new Point(x, y);
            Point zeroPoint = new Point();

            Console.WriteLine("Показать координаты точки:");
            point.Show();
            zeroPoint.Show();
            Console.WriteLine();

            Console.WriteLine("Рассчитать расстояние от начала координат до точки:");
            Console.WriteLine(point.Origin());
            Console.WriteLine(zeroPoint.Origin());
            Console.WriteLine();

            Console.WriteLine("Переместить точку на плоскости на вектор (3, 3)");
            point.Displacement(3, 3);
            zeroPoint.Displacement(3, 3);
            point.Show();
            zeroPoint.Show();
            Console.WriteLine();

            Console.WriteLine("Получить-установить координаты точки (доступное для чтений и записи):");
            point.X = 7;
            point.Y = 7;
            point.Show();
            Console.WriteLine(point.X);
            Console.WriteLine(point.Y);
            Console.WriteLine();

            Console.WriteLine("Умножить координаты точки на скаляр (7) (доступное только для записи)");
            point.MultScalX = 7;
            point.MultScalY = 7;
            Console.WriteLine(point.X);
            Console.WriteLine(point.Y);
            Console.WriteLine();

            Console.WriteLine("операция ++ : одновременно увеличивает значение полей х и у на 1:");
            point++;
            point.Show();
            Console.WriteLine();

            Console.WriteLine("операции бинарный +: одновременно добавляет к полям х и у значение скаляра (point + 5):");
            point = point + 5;
            point.Show();
            Console.WriteLine();

            Console.WriteLine("операции бинарный +: одновременно добавляет к полям х и у значение скаляра (5 + point):");
            point = 5 + point;
            point.Show();
            Console.WriteLine();

            Console.WriteLine("Константа true и false: обращение к экземпляру класса дает значение true, если значение полей x и у совпадает, иначе false:");

            if (point)
                Console.WriteLine("X = Y");
            else
                Console.WriteLine("X != Y");
            Console.WriteLine();

            Console.WriteLine("Преобразования типа Point в string:");
            string str = (string)point;
            Console.WriteLine("Переменная типа string: " + str);
            Console.WriteLine();

            Console.WriteLine("Преобразования типа string в Point:");
            Point point_new = (Point)str;
            point_new.Show();
            Console.WriteLine();

            Console.ReadKey();
        }

        public static int ReadCoord(char ch)
        {
            int x = 0;

            try
            {
                Console.Write("Введите координату {0}: ", ch);
                x = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Формат введенного числа является неправильным. Введите число еще раз.");
                ReadCoord(ch);
            }
            catch (OverflowException)
            {
                Console.WriteLine(
                    "Введенное число, либо меньше значения MinValue или больше значения MaxValue. Введите число еще раз.");
                ReadCoord(ch);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Введенный параметр имеет значение null. Введите число еще раз.");
                ReadCoord(ch);
            }

            return x;
        }
    }
}