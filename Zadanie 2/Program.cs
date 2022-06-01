using System;

namespace Zadanie_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listOfNames = new string[5]; //= { "Полянская", "Белякова", "Савенко", "Барашкова", "Рогожин" };

            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += ShowNumber; //Определение события и присвоение ему метода

            try
            {
                int num = numberReader.Read();
                if (num == 1)
                {
                    listOfNames = SortA_Z();
                    foreach (string s in listOfNames)
                        Console.WriteLine(s);
                }

                if (num == 2)
                {
                    listOfNames = SortZ_A();
                    foreach (string s in listOfNames)
                        Console.WriteLine(s);
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение");
            }

        }
        public static string[] SortA_Z()
        {
            string[] list = new string[] { "Барашкова", "Белякова", "Рогожин", "Полянская", "Савенко" };
            return list;
        }
        public static string[] SortZ_A()
        {
            string[] list = new string[] { "Савенко", "Полянская", "Рогожин", "Белякова", "Барашкова" };
            return list;
        }

        static void ShowNumber(int number) // Метод отображения введенного числа
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введено значение: 1");

                    break;

                case 2:
                    Console.WriteLine("Введено значение: 2");

                    break;

            }
        }
    }

    class NumberReader  // Класс, в котором объявляем событие
    {
        public delegate void NumberEnteredDelegate(int number); // описание делегата
        public event NumberEnteredDelegate NumberEnteredEvent;  // и события к делегату

        public int Read()                        //Метод считываения и проверки введеного числа
        {
            Console.WriteLine();
            Console.WriteLine("необходимо ввести значение: либо 1, либо 2");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2) throw new FormatException();

            NumberEntered(number);
            return number;

        }
        protected virtual void NumberEntered(int number) // Метод вызова события
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
}
