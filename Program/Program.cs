using System;

namespace Program
{
    enum Answers
    {
        камень = 1,
        ножницы = 2,
        бумага = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tКаменть Ножницы Бумага\t\t\t");
            Console.WriteLine("Нажмите 1, чтобы начать игру.");

            int key = 0;
            while ((ConsoleKey)key != ConsoleKey.D1)
            {
                key = Console.Read();
            }

            Game();

            Console.ReadLine();
        }

        static public void Game()
        {


            Console.Clear();

            Console.WriteLine("Напишите одно из трех слов: ");
            Console.WriteLine("камень, ножницы или бумага.");
            Console.WriteLine("Компьютер сгенирирует случайный ответ.");

            string response = PlayerResponse();
            int value = 0;
            bool coorectInput = false;
            Random rnd = new Random();
            int rndResponsePC = rnd.Next(1, 3);
            string responsePC = "";

            while (coorectInput == false)
            {
                if (ComparingUserResponse(response, out value))
                {
                    coorectInput = true;
                    break;
                }
 
                Console.WriteLine("Неверные данные. Повторите ввод.");
                response = PlayerResponse();                
            }

            if (rndResponsePC == 1)
                responsePC = "камень";
            if (rndResponsePC == 2)
                responsePC = "ножницы";
            if (rndResponsePC == 3)
                responsePC = "бумага";

            Console.Clear();

            if (value == rndResponsePC)
            {          
                Console.WriteLine("Вы: " + response.ToLowerInvariant() + "\nКомпьютер: " + responsePC);
                Console.WriteLine("Ничья!");
            }
            else if((value == 1 && rndResponsePC == 2) || (value == 2 && rndResponsePC == 3) || (value == 3 && rndResponsePC == 1))
            {
                Console.WriteLine("Вы: " + response.ToLowerInvariant() + "\nКомпьютер: " + responsePC);
                Console.WriteLine("Победа!");
            }
            else
            {
                Console.WriteLine("Вы: " + response.ToLowerInvariant() + "\nКомпьютер: " + responsePC);
                Console.WriteLine("Проигрыш!");
            }
        }

        static public string PlayerResponse()
        {
            return Console.ReadLine();
        }
        
        static public bool ComparingUserResponse(string response, out int value)
        {
            response = response.ToLowerInvariant();

            if (response == "камень")
            {
                value = 1;
                return true;
            }               
            if (response == "ножницы")
            {
                value = 2;
                return true;
            }              
            if (response == "бумага")
            {
                value = 3;
                return true;
            }

            value = 0;
            return false;
        }
    }
}