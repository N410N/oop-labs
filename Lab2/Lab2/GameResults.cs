namespace Lab2
{
    internal class GameResult
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
}
