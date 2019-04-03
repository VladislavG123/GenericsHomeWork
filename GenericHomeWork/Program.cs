using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            while (true)
            {
                Console.WriteLine("1-добавть игрока(от 2 игроков до 6)");
                Console.WriteLine("2-начать игру");
                int chouse;

                if (int.TryParse(Console.ReadLine(), out chouse))
                {
                    if (chouse == 1)
                    {
                        Console.WriteLine("Введите имя");
                        players.Add(new Player { Name = Console.ReadLine() });
                        continue;
                    }
                    else if (chouse == 2)
                    {
                        try
                        {
                            Game game = new Game(players);
                            Player winner = game.Start();
                            Console.WriteLine($"{winner.Name} победил!");
                            Console.WriteLine("Нажмите на Enter");
                            Console.Read();
                            break;
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine("Ошибка:");
                            Console.WriteLine(exception.Message);
                            players = new List<Player>();
                            continue;
                        }
                    }
                }
                Console.WriteLine("Неверный ввод!");
            }
        }
    }
}
