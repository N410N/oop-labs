using Lab3.DB;
using Lab3.DB.Service;
using Lab3.GameAccountTypes;

namespace Lab3
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var context = new DbContext();
            var accountService = new GameAccountService(context);
            var gameService = new GameService(context);
            Program program = new Program();
            program.Run(accountService, gameService);
        }
        public void Run(GameAccountService accountService, GameService gameService)
        {
            Console.WriteLine("Введіть ім'я першого гравця: ");
            string firstPlayer = Console.ReadLine();
            GameAccount player1 = AccountChose(accountService, firstPlayer);
            Console.WriteLine("Введіть ім'я другого гравця: ");
            string secondPlayer = Console.ReadLine();
            GameAccount player2 = AccountChose(accountService, secondPlayer);
            string answer;
            do
            {
              
                Game game = GameType(player1, player2, gameService);
                game.PlayGame(player1, player2);
                Console.WriteLine("Введіть Y/y , якщо хочете продовжити гру");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");
            GetStats(accountService);
        }

        public void GetStats(GameAccountService accountService)
        {
            var listAccounts = accountService.ReadAll();
            foreach (var account in listAccounts)
            {
                account.GetStats();
            }
        }

        private GameAccount AccountChose(GameAccountService service, string userName)
        {
            Console.WriteLine("Виберіть акаунт: \n1.Стандартний \n2.Половина \n3.Подвоєнний");
            int choose = int.Parse(Console.ReadLine());
            var Id = service.ReadAll().Count();
            switch (choose)
            {
                case 1:
                    var standartGameAccount = new StandartAccount(service, Id, userName);
                    service.Create(standartGameAccount);
                    return standartGameAccount;
                case 2:
                    var halfGameAccount = new HalfAccount(service, Id, userName);
                    service.Create(halfGameAccount);
                    return halfGameAccount;
                case 3:
                    var doubleGameAccount = new DoubleAccount(service, Id, userName);
                    service.Create(doubleGameAccount);
                    return doubleGameAccount;
                default:
                    Console.WriteLine("Не правильно. Введіть цифру в діапазоні 1-3");
                    return AccountChose(service, userName);
            }
        }

        private Game GameType(GameAccount player1, GameAccount player2, GameService service)
        {
            Console.WriteLine("Оберіть тип гри: \n1.Стандартна гра \n2.Безрангова гра \n3.Безпечна гра");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.CreateStandartGame(player1, player2, service);
                case 2:
                    return factory.CreateUnrankedGame(player1, player2, service);
                case 3:
                    return factory.CreateSafeGame(player1, player2, service);
                default:
                    Console.WriteLine("Не правильно. Введіть цифру в діапазоні 1-3");
                    return GameType(player1, player2, service);
            }
        }
    }
}