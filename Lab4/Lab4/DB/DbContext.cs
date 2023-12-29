using Lab4.DB.Entity;

namespace Lab4.DB
{
    internal class DbContext
    {
        public List<GameEntity> Games { get; set; }
        public List<GameAccountEntity> Accounts { get; set; }

        public DbContext()
        {
            Games = new List<GameEntity>();
            Accounts = new List<GameAccountEntity>();
        }
    }
}
