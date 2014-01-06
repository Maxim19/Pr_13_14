/*10.	Создать класс для работы с датой. Разработать следующие элементы класса:
    a.	Поле DataTime data.
    b.	Конструкторы, позволяющие установить:
    •	заданную дату
    •	дату 1.01.2009
    c.	Методы, позволяющие:
    •	вычислить дату предыдущего дня;
    •	вычислить дату следующего дня;
    •	определить сколько дней осталось до конца месяца.
    d.	Свойства:
    •	позволяющее установить или получить значение поле класса (доступно для чтения и записи)
    •	позволяющее определить год высокосным (доступно только для чтения)
    10.	Добавить в класс для работы с датой: 
    a.	Индексатор, позволяющий определить дату i-того по счету дня относительно установленной даты (при отрицательных значениях индекса отсчет ведется в обратном порядке). 
    b.	Перегрузку:
    •	операции !: возвращает значение true, если установленная дата не является последним днем месяца, иначе false;
    •	констант true и false: обращение к экземпляру класса дает значение true, если установленная дата является началом года, иначе false;
    •	операции &: возвращает значение true, если поля двух объектов равны, иначе false;
    •	преобразования класса DataTime в тип string (и наоборот). */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTime
{
    class DateClass
    {
        // Поле DataTime data.
        DateTime date;

        // Конструкторы, позволяющие установить: •	заданную дату
        public DateClass(int year, int month, int day)
        {
            date = new DateTime(year, month, day);
        }

        // дату 1.01.2009
        public DateClass()
        {
            date = new DateTime(2009, 1, 1);
        }

        // Методы, позволяющие: •	вычислить дату предыдущего дня;
        public DateTime PrevDay()
        {
            return date.AddDays(-1);
        }

        // •	вычислить дату следующего дня;
        public DateTime NextDay()
        {
            return date.Add(TimeSpan.FromDays(1));
        }

        // определить сколько дней осталось до конца месяца.
        public int DaysLeft()
        {
            return DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
        }

        //Свойства:•	позволяющее установить или получить значение поле класса (доступно для чтения и записи)
        public DateTime Data
        {
            set { date = value; }
            get { return date; }
        }

        //позволяющее определить год высокосным (доступно только для чтения)
        public bool IsLeap
        {
            get { return DateTime.IsLeapYear(date.Year); }
        }

        // Индексатор, позволяющий определить дату i-того по счету дня относительно установленной даты 
        // (при отрицательных значениях индекса отсчет ведется в обратном порядке). 
        public DateTime this[int index]
        {
            get 
            {
                return date.AddDays(index);
            }
        }

        //Перегрузку: •	операции !: возвращает значение true, если установленная дата не является последним днем месяца, иначе false;

        public static bool operator !(DateClass a)
        {
            return a.date.Day != DateTime.DaysInMonth(a.date.Year, a.date.Month);
        }

        // констант true и false: обращение к экземпляру класса дает значение true,
        // если установленная дата является началом года, иначе false;
        public static bool operator true(DateClass a)
        {
            return a.date.Day == 1 && a.date.Month == 1; 
        }

        public static bool operator false(DateClass a)
        {
            return a.date.Day != 1 || a.date.Month != 1;
        }

        // операции &: возвращает значение true, если поля двух объектов равны, иначе false;
        public static bool operator &(DateClass a, DateClass b)
        {
            return a.date.Equals(b.date);
        }

        public static explicit operator String(DateClass obj)
        {
            return " Год: " + obj.date.Year + " Месяц: " + obj.date.Month + " Число: " + obj.date.Day;
        }

        public static explicit operator DateClass(String str)
        {
            string[] str_arr = str.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            DateClass obj = new DateClass(Convert.ToInt32(str_arr[0]), Convert.ToInt32(str_arr[1]), Convert.ToInt32(str_arr[2]));
            return obj;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            DateClass my = new DateClass();

            Console.WriteLine("Текущая дата: {0}", (string)my);

            my = new DateClass(2013, 12, 7);

            Console.WriteLine("Изменить дату на 7.12.2013: {0}", (string)my);

            Console.WriteLine("Дата предыдущего дня: {0}", my.PrevDay());

            Console.WriteLine("Дата следующего дня: {0}", my.NextDay());

            Console.WriteLine("Количество дней до конца месяца: {0}", my.DaysLeft());

            Console.WriteLine(@"Индексатор, позволяющий определить дату i-того по счету дня относительно установленной даты. 
Добавить к дате 10 дней: {0}", my[10]);

            Console.WriteLine("Является ли год выскокосным? {0}", my.IsLeap);

            Console.WriteLine("Перегрузка операции !: true, если дата не является последним днем месяца, иначе false: {0}", !my);

            Console.WriteLine("Создается новый обьект DaateClass(2013, 12, 18)");

            DateClass my1 = new DateClass(2013, 12, 18);

            Console.WriteLine("Перегрузка операции &: true, если поля двух объектов равны, иначе false: {0}", my1 & my);

            Console.WriteLine("Преобразования класса DataTime в тип string: {0}", (string)my);

            string str = "2014, 12, 01";
            my = (DateClass)str;

            Console.WriteLine("Преобразования класса string в тип DataTime (2014, 12, 01): {0}", (string)my);

            Console.ReadKey();
        }
    }
}
