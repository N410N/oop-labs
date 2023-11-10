

namespace lesson
{
    class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GamesResults { get; set; } = new List<GameResult>();

        public void OutPlayers()
        {
            Console.WriteLine($"\nІм'я гравця:{UserName}\nРейтинг:{CurrentRating}\nІгр зіграно:{GamesCount}");
        }

        public void WinGame(string player1, string player2, string winner, int rating, int index)
        {
            CurrentRating += rating;
            GamesCount++;
            GamesResults.Add(new GameResult(player1, player2, winner, rating, index));
        }

        public void TieGame(string player1, string player2, string winner, int rating, int index)
        {
            GamesCount++;
            GamesResults.Add(new GameResult(player1, player2, winner, rating, index));
        }

        public void LoseGame(string player1, string player2, string winner, int rating, int index)
        {
            if (CurrentRating - rating < 1)
            {
                CurrentRating = 1;
            }
            else
            {
                CurrentRating -= rating;
            }
            GamesCount++;
            GamesResults.Add(new GameResult(player1, player2, winner, rating, index));
        }

        public void GetStats()
        {
            foreach(GameResult res in GamesResults)
            {
                Console.WriteLine($"Гравець {res.Player}, його опонент {res.Opponent},переможець гри - {res.Winner}, грали на рейтинг - {res.Rating}, індекс гри - {res.Index} ");
            }
        }
    }

    class Game
    {
        public void GamePlay(GameAccount Player1, GameAccount Player2, int rating)
        {
            Random random = new Random();
            int p1number = random.Next(1, 101);
            int p2number = random.Next(1, 101);
            int index = Player1.GamesCount;

            if (p1number > p2number)
            {
                Player2.LoseGame(Player1.UserName, Player2.UserName, Player1.UserName, rating, index);
                Player1.WinGame(Player1.UserName, Player2.UserName, Player1.UserName, rating, index);
                Console.WriteLine($"Гравець {Player1.UserName} переміг, його рейтинг: {Player1.CurrentRating}");
                Console.WriteLine($"Гравець {Player2.UserName} програв, його рейтинг: {Player2.CurrentRating}");
            }
            else if (p1number < p2number)
            {
                Player1.LoseGame(Player1.UserName, Player2.UserName, Player2.UserName, rating, index);
                Player2.WinGame(Player1.UserName, Player2.UserName, Player2.UserName, rating, index);
                Console.WriteLine($"Гравець {Player2.UserName} переміг, його рейтинг: {Player2.CurrentRating}");
                Console.WriteLine($"Гравець {Player1.UserName} програв, його рейтинг: {Player1.CurrentRating}");
            }
            else
            {
                Player1.TieGame(Player1.UserName, Player2.UserName, "Нічия", rating, index);
                Player2.TieGame(Player1.UserName, Player2.UserName, "Нічия", rating, index);
                Console.WriteLine("Нічия");
            }
        }
    }

    class GameResult
    {
        public string Player { get; }
        public string Opponent { get; }
        public string Winner { get; }
        public int Rating { get; }
        public int Index { get; }

        public GameResult(string player, string opponent, string winner, int rating, int index)
        {
            Player = player;
            Opponent = opponent;
            Winner = winner;
            Rating = rating;
            Index = index;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            GameAccount Player1 = new GameAccount();
            GameAccount Player2 = new GameAccount();
            Player1.CurrentRating = 100;
            Player2.CurrentRating = 100;
            Console.WriteLine("Введіть ім'я першого гравця: ");
            Player1.UserName = Console.ReadLine();
            Console.WriteLine("Введіть ім'я другого гравця: ");
            Player2.UserName = Console.ReadLine();
            Player1.OutPlayers();
            Player2.OutPlayers();
            string answer;
            int rating;
            do
            {
                do
                {
                    Console.WriteLine("Введіть на який рейтинг ви будете грати:");
                    rating = Convert.ToInt32(Console.ReadLine());
                    if (rating <= 0)
                    {
                        Console.WriteLine("Рейтинг не може бути від'ємним");
                    }
                } while (rating <= 0);

                Game game = new Game();
                game.GamePlay(Player1, Player2, rating);
                Console.WriteLine("Введіть Y/y , якщо хочете продовжити гру ");
                answer = Console.ReadLine();
            } while (answer.ToUpper()=="Y");
            Player1.GetStats();
            Player1.OutPlayers();
            Player2.OutPlayers();
        }
    }
}
