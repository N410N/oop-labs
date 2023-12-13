namespace Lab2
{
    internal class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();

        public GameAccount(string userName)
        {
            UserName = userName;
            CurrentRating = 100;
            GamesCount = 0;
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
        }
        public void TieGame(string player1, string player2, string winner, int gameIndex)
        {
            int rating = 0;
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
        }

        public void GetStats()
        {
            foreach (GameResult res in GameResults)
            {
                Console.WriteLine($"Гравець {res.Player}, його опонент {res.Opponent},переможець гри - {res.Winner}, грали на рейтинг - {res.Rating}, індекс гри - {res.Index} ");
            }
        }
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
    
    
    
}
