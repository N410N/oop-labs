using Lab4.DB.Service;
using Lab4.GameAccountTypes;

namespace Lab4.Commands
{
    internal class AddPlayer : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public AddPlayer(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }
        public void Execute()
        {
            Console.WriteLine("Введіть ім'я нового гравця: ");
            string name = Console.ReadLine();
            GameAccount player = AccountChose(_gameAccountService, name);
            _gameAccountService.Create(player);
        }

        private GameAccount AccountChose(GameAccountService service, string userName)
        {
            Console.WriteLine("Виберіть акаунт: \n1.Стандартний \n2.Половина \n3.Подвоєнний");
            int choose = int.Parse(Console.ReadLine());
            var Id = service.ReadAll().Count();
            switch (choose)
            {
                case 1:
                    var standartGameAccount = new StandartAccount(service, Id, userName);
                    return standartGameAccount;
                case 2:
                    var halfGameAccount = new HalfAccount(service, Id, userName);
                    return halfGameAccount;
                case 3:
                    var doubleGameAccount = new DoubleAccount(service, Id, userName);
                    return doubleGameAccount;
                default:
                    Console.WriteLine("Не правильно. Введіть цифру в діапазоні 1-3");
                    return AccountChose(service, userName);
            }
        }
    }
}
