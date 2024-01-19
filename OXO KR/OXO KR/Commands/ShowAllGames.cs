using OXO.DB.Service;

namespace OXO.Commands
{
    internal class ShowAllGames : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public ShowAllGames(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }
        public void Execute()
        {
            Console.WriteLine("Інформація про всі ігри:");
            foreach (GameAccount thisPlayer in _gameAccountService.ReadAll())
            {
                List<GameResult> games = _gameAccountService.GameResults(thisPlayer);
                
                foreach (GameResult game in games)
                {
                    if (thisPlayer.UserName != game.Player)
                    {
                        Console.WriteLine($"Гравець {game.Player}, його опонент {game.Opponent},переможець гри - {game.Winner}, грали на рейтинг - {game.Rating}, індекс гри - {game.GameIndex}");
                    }
                }
            }
        }
    }
}
