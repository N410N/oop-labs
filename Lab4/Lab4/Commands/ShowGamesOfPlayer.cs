using Lab4.DB.Service;

namespace Lab4.Commands
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
            Console.WriteLine("ввеедіть ID гравця, ігри якого хочете побачити:");
            int playerID = int.Parse(Console.ReadLine());
            GameAccount player = _gameAccountService.ReadById(playerID);
            Console.WriteLine($"Інформація про гравця {player.UserName}:");
            List<GameResult> games = _gameAccountService.GameResults(player);
            foreach (GameResult game in games)
            {
                Console.WriteLine($"Гравець {game.Player}, його опонент {game.Opponent},переможець гри - {game.Winner}, грали на рейтинг - {game.Rating}, індекс гри - {game.GameIndex}");
            }
        }
    }
}
