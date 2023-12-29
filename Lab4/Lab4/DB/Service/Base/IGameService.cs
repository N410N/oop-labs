
namespace Lab4.DB.Service.Base
{
    internal interface IGameService
    {
        public void Create(Game gameEntity);
        public void Update(Game gameEntity);
        public void Delete(Game gameEntity);
    }
}
