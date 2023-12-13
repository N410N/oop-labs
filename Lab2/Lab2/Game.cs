using Lab2.GameTypes;

namespace Lab2
{
    abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int playRating { get; set; }
        public string winner { get; set; }
        public Game(GameAccount player1, GameAccount player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void PlayGame(GameAccount player1, GameAccount player2)
        {
            Console.WriteLine("Напишіть рейтинг:");
            playRating = int.Parse(Console.ReadLine());
            while (playRating <= 0)
            {
                Console.WriteLine("Рейтинг не може бути нижче 0");
                playRating = int.Parse(Console.ReadLine());
            }

            Random random = new Random();
            int p1number = random.Next(1, 101);
            int p2number = random.Next(1, 101);
            int index = player1.GamesCount;

            if (p1number > p2number)
            {
                winner = player1.UserName;
                player1.WinGame(this, player1.UserName, player2.UserName, winner, index);
                player2.LoseGame(this, player1.UserName, player2.UserName, winner, index);
                Console.WriteLine($"Гравець {player1.UserName} переміг, його рейтинг: {player1.CurrentRating}");
                Console.WriteLine($"Гравець {player2.UserName} програв, його рейтинг: {player2.CurrentRating}");
            }
            else if (p1number < p2number)
            {
                winner = player2.UserName;
                player1.LoseGame(this, player1.UserName, player2.UserName, winner, index);
                player2.WinGame(this, player1.UserName, player2.UserName, winner, index);
                Console.WriteLine($"Гравець {player2.UserName} переміг, його рейтинг: {player2.CurrentRating}");
                Console.WriteLine($"Гравець {player1.UserName} програв, його рейтинг: {player1.CurrentRating}");
            }
            else
            {
                player1.TieGame(player1.UserName, player2.UserName, winner, index);
                player2.TieGame(player1.UserName, player2.UserName, winner, index);
                Console.WriteLine("Нічия");
            }
        }
        public virtual int getPlayRating(GameAccount player) { return playRating; }
    }
    class GameFactory
    {
        public Game CreateStandartGame(GameAccount player1, GameAccount player2)
        {
            return new StandartGame(player1, player2);
        }
        public Game CreateUnrankedGame(GameAccount player1, GameAccount player2)
        {
            return new UnrankedGame(player1, player2);
        }
        public Game CreateSafeGame(GameAccount player1, GameAccount player2)
        {
            return new SafeGame(player1, player2);
        }
    }
}
