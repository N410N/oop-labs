using Lab3.DB.Service;

namespace Lab3
{
    internal class GameAccount
    {
        public int Id {  get; set; }
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();
        public GameAccountService Service { get; set; }

        public GameAccount(GameAccountService service, int ID, string userName, int gamesCount = 0)
        {
            Service = service;
            UserName = userName;
            CurrentRating = 100;
            GamesCount = gamesCount;
            Id = ID;
        }
        public void OutPlayers()
        {
            Console.WriteLine($"\nІм'я гравця:{UserName}\nРейтинг:{CurrentRating}\nІгр зіграно:{GamesCount}\n");
        }
        public void WinGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            CurrentRating += rating;
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
            Service.Update(this);
        }
        public void LoseGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            CurrentRating -= rating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
            Service.Update(this);
        }
        public void TieGame(string player1, string player2, string winner, int gameIndex)
        {
            int rating = 0;
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
            Service.Update(this);
        }

        public void GetStats()
        {
            if (GameResults == null)
            {
                Console.WriteLine($"Ім'я:{UserName}, Id: {Id}");
                return;
            }

            Console.WriteLine($"Ім'я:{UserName}, Id: {Id}");
            for (int id = 0; id < GameResults.Count; id++)
            {
                var result = Service.GameResults(this)[id];
                Console.WriteLine($"Гравець {result.Player}, його опонент {result.Opponent},переможець гри - {result.Winner}, грали на рейтинг - {result.Rating}, індекс гри - {result.GameIndex}");
            }
            Console.WriteLine($"Поточний рейтинг для гравця {UserName}: {CurrentRating}\n" + $"Ігор зіграно: {GamesCount}\n");
        }
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
}
