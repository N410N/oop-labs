using OXO.DB.Service;

namespace OXO
{
    internal class GameAccount
    {
        public int Id {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();
        public GameAccountService _service { get; set; }

        public GameAccount(GameAccountService service, int ID, string userName, string password, int gamesCount = 0)
        {
            _service = service;
            UserName = userName;
            Password = password;
            CurrentRating = 100;
            GamesCount = gamesCount;
            Id = ID;
        }

        public void WinGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            CurrentRating += rating;
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
            _service.Update(this);
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
            _service.Update(this);
        }
        public void TieGame(string player1, string player2, string winner, int gameIndex)
        {
            int rating = 0;
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
            _service.Update(this);
        }
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
}
