
namespace Lab3.DB.Entity
{
    internal class GameResultEntity
    {
        public string Player { get; set; }
        public string Opponent { get; set; }
        public string Winner { get; set; }
        public int Rating { get; set; }
        public int GameIndex { get; set; }
    }
}
