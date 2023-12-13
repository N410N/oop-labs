using Lab2.AccountTypes;
using System.Text.Unicode;

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Program program = new Program();
            program.Run();
        }
        public void Run()
        {
            Console.WriteLine("Введіть ім'я першого гравця: ");
            string firstPlayer = Console.ReadLine();
            GameAccount player1 = AccountChose(firstPlayer);
            Console.WriteLine("Введіть ім'я другого гравця: ");
            string secondPlayer = Console.ReadLine();
            GameAccount player2 = AccountChose(secondPlayer);

            player1.OutPlayers();
            player2.OutPlayers();
            string answer;
            do
            {
                Game game = GameType(player1, player2);
                game.PlayGame(player1, player2);
                player1.OutPlayers();
                player2.OutPlayers();
                Console.WriteLine("Введіть Y/y , якщо хочете продовжити гру");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");
            player1.OutPlayers();
            player2.OutPlayers();
            player1.GetStats();
        }

        private static GameAccount AccountChose(string userName)
        {
            Console.WriteLine("Виберіть тип акаунту: \n1.Стандартна гра \n2.Гра без рейтингу \n3.Безпечна гра");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    return new StandartAccount(userName);
                case 2:
                    return new HalfAccount(userName);
                case 3:
                    return new DoubleAccount(userName);
                default:
                    Console.WriteLine("Невірно. Напишіть число від 1 до 3");
                    return AccountChose(userName);
            }
        }

        private static Game GameType(GameAccount player1, GameAccount player2)
        {
            Console.WriteLine("Виберіть тип гри: \n1.Стандартна гра \n2.Гра без рейтингу \n3.Безпечна гра");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.CreateStandartGame(player1, player2);
                case 2:
                    return factory.CreateUnrankedGame(player1, player2);
                case 3:
                    return factory.CreateSafeGame(player1, player2);
                default:
                    Console.WriteLine("Невірно. Напишіть число від 1 до 3");
                    return GameType(player1, player2);
            }
        }
    }
}
