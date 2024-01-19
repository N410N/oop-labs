using OXO.DB.Service;
using System.Security.Principal;

namespace OXO.Commands
{
    internal class PlayGame : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        private readonly GameService _gameService;

        public PlayGame(GameAccountService gameAccountService, GameService gameService)
        {
            _gameAccountService = gameAccountService;
            _gameService = gameService;
        }
        public void Execute()
        {
            GameAccount player1;
            GameAccount player2;

            Console.WriteLine("Оберіть гравців які будуть грати:");
            Console.WriteLine("Перший гравець");
            player1 = Login(_gameAccountService);
            Console.WriteLine("Другий гравець");
            player2 = Login(_gameAccountService);

            string answer;
            do
            {
                Game game = GameType(player1, player2, _gameService);
                game.StartGame(player1, player2);
                Console.WriteLine("Введіть Y/y , якщо хочете продовжити гру");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");
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

        private GameAccount Login(GameAccountService accountService)
        {
            Console.WriteLine("Вхід до акаунта: ");
            Console.WriteLine("Введіть ім'я гравця: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введіть пароль гравця: ");
            string password = Console.ReadLine();
            List<GameAccount> players = accountService.ReadAll();
            foreach (GameAccount player in players)
            {
                if (player.UserName == name && player.Password == password)
                {
                    return player;
                }
            }
            return Login(accountService);
        }
    }
}
