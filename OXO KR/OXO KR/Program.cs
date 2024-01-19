using OXO.Commands;
using OXO.DB;
using OXO.DB.Service;
using System.Windows.Input;
using ICommand = OXO.Commands.ICommand;

namespace OXO
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var context = new DbContext();
            var gameAccountService = new GameAccountService(context);
            var gameService = new GameService(context);
            Program program = new Program();
            program.Run(gameAccountService, gameService);
        }
        public void Run(GameAccountService gameAccountService, GameService gameService)
        {
            ICommand[] commands = new ICommand[6];
            commands[0] = new EndProgram();
            commands[1] = new AddPlayer(gameAccountService);
            commands[2] = new ShowAllPlayers(gameAccountService);
            commands[3] = new PlayGame(gameAccountService, gameService);
            commands[4] = new ShowAllGames(gameAccountService);
            commands[5] = new ShowGamesOfPlayer(gameAccountService);

            commands[1].Execute();
            commands[1].Execute();

            int option = 1;
            while (option != 0)
            {
                Console.WriteLine("Оберіть дію:\n 1.Додати нового гравця\n 2.Показати інформацію про всіх гравців\n 3.Почати гру\n 4.Показати інформацію про всі ігри\n 5.Показати інформацію про всі ігри гравця\n 0.Завершити програму");

                option = int.Parse(Console.ReadLine());
                while (option < 0 || option > 5)
                {
                    Console.WriteLine("Неправильниий варіант, оберіть знову");
                    option = int.Parse(Console.ReadLine());
                }

                commands[option].Execute();
            }
        }
    }
}