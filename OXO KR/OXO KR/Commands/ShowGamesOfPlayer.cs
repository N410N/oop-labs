using OXO.DB.Service;

namespace OXO.Commands
{
    internal class ShowGamesOfPlayer : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public ShowGamesOfPlayer(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            GameAccount player = Login(_gameAccountService);
            List<GameResult> games = _gameAccountService.GameResults(player);
            foreach (GameResult game in games)
            {
                Console.WriteLine($"Гравець {game.Player}, його опонент {game.Opponent},переможець гри - {game.Winner}, грали на рейтинг - {game.Rating}, індекс гри - {game.GameIndex}");
            }
        }

        private GameAccount Login(GameAccountService accountService)
        {
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
