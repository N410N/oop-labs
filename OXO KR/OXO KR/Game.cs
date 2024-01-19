using OXO.DB.Service;
using System;
using System.Numerics;

namespace OXO
{
    abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int playRating { get; set; }
        public string winner { get; set; }
        public GameService _service { get; set; }

        char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        int player = 1; // Починає перший гравець
        public Game(GameAccount player1, GameAccount player2, GameService service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }

        public void StartGame(GameAccount player1, GameAccount player2)
        {
            Console.WriteLine("Напишіть рейтинг на який граєте: ");
            playRating = int.Parse(Console.ReadLine());
            while (playRating <= 0)
            {
                Console.WriteLine("Рейтинг не може бути відє'мним");
                playRating = int.Parse(Console.ReadLine());
            }
            asd(player1, player2);
        }
        public void asd(GameAccount player1, GameAccount player2)
        {
        
            int choice;
            int flag = 0;

            do
            {
                Console.Clear(); // Очищення консолі
                Console.WriteLine("Гравець - {0} грає знаком {1}", (player % 2 == 0) ? player2.UserName : player1.UserName, (player % 2 == 0) ? "O" : "X");
                Console.WriteLine("\n");
                Board();

                // Перевірка на коректність введення
                bool validInput;
                do
                {
                    Console.WriteLine("Введіть число від 1 до 9 для вибору клітинки: ");
                    validInput = int.TryParse(Console.ReadLine(), out choice);

                    if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                    {
                        Console.WriteLine("Некоректне введення. Будь ласка, спробуйте знову.");
                        validInput = false;
                    }
                } while (!validInput);

                // Присвоєння знака гравцю
                if (player % 2 == 0)
                    board[choice - 1] = 'O';
                else
                    board[choice - 1] = 'X';

                flag = CheckWin();
                player++;

            } while (flag != 1 && flag != -1);

            Console.Clear();
            Board();

            int gameIndex = player1.GamesCount;
            if (flag == 1)
            {
                Console.WriteLine("Гравець {0} переміг!", (player % 2 == 0) ? "X" : "O");
                if (player % 2 != 0)
                {
                    winner = player2.UserName;
                    _service.Create(this);
                    player2.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                    player1.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                }
                else if (player % 2 == 0)
                {
                    winner = player1.UserName;
                    _service.Create(this);
                    player1.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                    player2.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                }
            }    
            else if (flag == -1)
            {
                Console.WriteLine("Нічия!");
                _service.Create(this);
                winner = "ДРУЖБА";
                player1.TieGame(player1.UserName, player2.UserName, winner, gameIndex);
                player2.TieGame(player1.UserName, player2.UserName, winner, gameIndex);
            }
                
            else
            {
                asd(player1, player2);
            }
        }

        private void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }

        private int CheckWin()
        {
            // Перевірка горизонталей
            for (int i = 0; i < 3; i++)
            {
                if ((board[i * 3] == board[(i * 3) + 1]) && (board[(i * 3) + 1] == board[(i * 3) + 2]))
                    return 1;
            }

            // Перевірка вертикалей
            for (int i = 0; i < 3; i++)
            {
                if ((board[i] == board[i + 3]) && (board[i + 3] == board[i + 6]))
                    return 1;
            }

            // Перевірка головної діагоналі
            if ((board[0] == board[4]) && (board[4] == board[8]))
                return 1;

            // Перевірка побічної діагоналі
            if ((board[2] == board[4]) && (board[4] == board[6]))
                return 1;

            // Перевірка на нічию
            int tmp = 0;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == 'X' || board[i] == 'O')
                {
                    tmp++;
                }
                if (tmp == 9)
                {
                    return -1;
                }
            }

            return 0;
        }
        public virtual int getPlayRating(GameAccount player) { return playRating; }
    }
}
