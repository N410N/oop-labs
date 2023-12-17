using Lab3.DB.Service;

namespace Lab3
{
    abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int playRating { get; set; }
        public string winner { get; set; }
        public GameService _service { get; set; }
        public Game(GameAccount player1, GameAccount player2, GameService service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }
        public void PlayGame(GameAccount player1, GameAccount player2)
        {
            Console.WriteLine("Напишіть рейтинг на який граєте: ");
            playRating = int.Parse(Console.ReadLine());
            while (playRating <= 0)
            {
                Console.WriteLine("Рейтинг не може бути відє'мним");
                playRating = int.Parse(Console.ReadLine());
            }
            Random random = new Random();
            int p1number = random.Next(1, 101);
            int p2number = random.Next(1, 101);
            int index = player1.GamesCount;

            if (p1number > p2number)
            {
                winner = player1.UserName;
                _service.Create(this);
                Console.WriteLine($"Гравець {player1.UserName} переміг");
                player1.WinGame(this, player1.UserName, player2.UserName, winner, index);
                Console.WriteLine($"Гравець {player2.UserName} програв");
                player2.LoseGame(this, player1.UserName, player2.UserName, winner, index);
            }
            else if (p1number < p2number)
            {
                winner = player2.UserName;
                _service.Create(this);
                Console.WriteLine($"Гравець {player2.UserName} переміг");
                player2.WinGame(this, player1.UserName, player2.UserName, winner, index);
                Console.WriteLine($"Гравець {player1.UserName} програв");
                player1.LoseGame(this, player1.UserName, player2.UserName, winner, index);
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
}
