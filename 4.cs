/*4.	Создать класс Money, разработав следующие элементы класса:
   a.	Поля:
   •	int first;//номинал купюры
   •	int second; //количество купюр
   b.	Конструктор, позволяющий создать экземпляр класса  с заданными значениям полей.
   c.	Методы, позволяющие:
   •	вывести номинал и количество купюр;
   •	определить, хватит ли денежных средств на покупку товара на сумму N рублей.
   •	определить, сколько шт товара стоимости n рублей можно купить на имеющиеся денежные средства.
   d.	Свойства:
   •	позволяющее получить-установить значение полей (доступное для чтения и записи);
   •	позволяющее расчитатать сумму денег (доступное только для чтения).
   4.	В класс Money добавить:
   a.	Индексатор, позволяющий по индексу 0 обращаться к полю first, 
   •    по индексу 1 – к полю second, при других значениях индекса выдается сообщение об ошибке. 
   b.	Перегрузку:
   •	операции ++ (--): одновременно увеличивает (уменьшает) значение полей first и second;
   •	операции !: возвращает значение true, если поле second не нулевое, иначе false;
   •	операции бинарный +:  добавляет к значению поля second значение скаляра;
   •	преобразования типа Money в string (и наоборот).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Money
{
    class Money
    {
        // Поля:  •	int first;//номинал купюры • int second; //количество купюр
        int first;
        int second;

        // Конструктор, позволяющий создать экземпляр класса  с заданными значениям полей.
        public Money(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        //Методы, позволяющие:•	вывести номинал и количество купюр;
        public void Show()
        {
            Console.WriteLine("Номинал купюры = {0}, количество купюр = {1}", first, second);
        }

        // определить, хватит ли денежных средств на покупку товара на сумму N рублей.
        public string IsEnough(int sum)
        {
            if (first * second > sum)
                return "Хватит";
            return "Не хватит";
        }

        // определить, сколько шт товара стоимости n рублей можно купить на имеющиеся денежные средства.
        public int Product_Amount(int product_price)
        {
            return (int)((first * second) / product_price);
        }

        // Свойства: позволяющее получить-установить значение полей (доступное для чтения и записи);
        public int First
        {
            set { first = value; }
            get { return first; }
        }

        public int Second
        {
            set { second = value; }
            get { return second; }
        }

        //позволяющее расчитатать сумму денег (доступное только для чтения).
        public int Total { get { return first * second; } }

        // Индексатор, позволяющий по индексу 0 обращаться к полю first, 
        // по индексу 1 – к полю second, при других значениях индекса выдается сообщение об ошибке. 
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return first;
                    case 1:
                        return second;
                    default:
                        throw new Exception("error");
                }
            }
        }

        //операции ++ (--): одновременно увеличивает (уменьшает) значение полей first и second;
        public static Money operator ++(Money obj)
        {
            obj.second++;
            obj.first++;
            return obj;
        }

        public static Money operator --(Money obj)
        {
            obj.second--;
            obj.first--;
            return obj;
        }

        //операции бинарный +:  добавляет к значению поля second значение скаляра;
        public static int operator +(Money obj, int scal)
        {
            return obj.second + scal;
        }

        public static int operator +(int scal, Money obj)
        {
            return obj.second + scal;
        }

        //операции !: возвращает значение true, если поле second не нулевое, иначе false;
        public static bool operator !(Money obj)
        {
            if (obj.second != 0)
                return true;
            return false;
        }

        //преобразования типа Money в string (и наоборот)
        public static explicit operator String(Money obj)
        {
            return obj.first + ", " + obj.second;
        }

        public static explicit operator Money(string str)
        {
            Money obj = new Money(0, 0);
            string[] q = str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            obj.first = int.Parse(q[0]);
            obj.second = int.Parse(q[1]);
            return obj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int first, second;

            Console.Write("Введите номинал купюры: ");
            first = int.Parse(Console.ReadLine());
            Console.Write("Введите количество купюр: ");
            second = int.Parse(Console.ReadLine());
            Money obj = new Money(first, second);

            Console.WriteLine("\nВывести номинал и количество купюр: ");
            obj.Show();

            Console.WriteLine("\nВведите сумму на которую небоходимо купить товара: ");
            int sum = int.Parse(Console.ReadLine());
            Console.WriteLine(obj.IsEnough(sum));

            Console.WriteLine("\nВведите цену товара, который необходимо купить:");
            int product_price = int.Parse(Console.ReadLine());
            Console.WriteLine("Вы можете купить {0} шт.\n", obj.Product_Amount(product_price));

            Console.WriteLine("Операция ++: одновременно увеличивает значение полей first и second:");
            obj++;
            obj.Show();
            Console.WriteLine();

            Console.WriteLine("Операция --: одновременно уменьшает значение полей first и second:");
            obj--;
            obj.Show();
            Console.WriteLine();

            Console.WriteLine("Операции бинарный +:  добавляет к значению поля second значение скаляра(5 + Money obj):");
            obj.Second = 5 + obj.Second;
            obj.Show();
            Console.WriteLine();

            Console.WriteLine("Операции бинарный +:  добавляет к значению поля second значение скаляра(Money obj + 7):");
            obj.Second = obj.Second + 7;
            obj.Show();
            Console.WriteLine();

            Console.WriteLine("Операция !: возвращает значение true, если поле second не нулевое, иначе false:S");
            if (!obj)
                Console.WriteLine("second != 0\n");
            else
                Console.WriteLine("second == 0");

            Console.WriteLine("Преобразования типа Money в string:");
            string str = (string)obj;
            Console.WriteLine(str + "\n");

            Console.WriteLine("Преобразования типа string в Money:");
            Money obj_new = (Money)str;
            obj.Show();

            Console.ReadLine();
        }
    }
}
