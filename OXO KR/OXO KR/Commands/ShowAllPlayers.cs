using OXO.DB.Service;

namespace OXO.Commands
{
    internal class ShowAllPlayers : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public ShowAllPlayers(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            List<GameAccount> playersList = _gameAccountService.ReadAll();
            foreach (GameAccount player in playersList)
            {
                ShowPlayer(player);
            }
        }

        private void ShowPlayer(GameAccount player)
        {
            Console.WriteLine($"ID гравця: {player.Id}, Ім'я: {player.UserName}, Поточний рейтинг: {player.CurrentRating}");
        }
    }
}
