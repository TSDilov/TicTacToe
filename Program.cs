using System;
using TicTacToe.Players;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Tsvetelin TicTacToe 1.0";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== TicTacToe 1.0 ====");
                Console.WriteLine("1. Player vs. Player");
                Console.WriteLine("2. Player vs. Random");
                Console.WriteLine("3. Random vs. Player");
                Console.WriteLine("4. Player vs. Master");
                Console.WriteLine("5. Master vs. Player");
                Console.WriteLine("6. Simulate Random vs. Random");
                Console.WriteLine("7. Simulate Master vs. Random");
                Console.WriteLine("8. Simulate Random vs. Master");
                Console.WriteLine("0. Exit");

                while (true)
                {
                    Console.Write("Please enter number for option for the game [0-8]: ");
                    var choiceForGame = Console.ReadLine();

                    if (choiceForGame == "0")
                    {
                        return;
                    }
                    if (choiceForGame == "1")
                    {
                        PlayGame(new ConsolePlayer(), new ConsolePlayer());
                        break;
                    }
                    if (choiceForGame == "2")
                    {
                        PlayGame(new ConsolePlayer(), new RandomPlayer());
                        break;
                    }
                    if (choiceForGame == "3")
                    {
                        PlayGame(new RandomPlayer(), new ConsolePlayer());
                        break;
                    }
                    if (choiceForGame == "4")
                    {
                        PlayGame(new ConsolePlayer(), new MasterPlayer());
                        break;
                    }
                    if (choiceForGame == "5")
                    {
                        PlayGame(new MasterPlayer(), new ConsolePlayer());
                        break;
                    }
                    if (choiceForGame == "6")
                    {
                        Simulate(new RandomPlayer(), new RandomPlayer(), 10);
                        break;
                    }
                    if (choiceForGame == "7")
                    {
                        Simulate(new MasterPlayer(), new RandomPlayer(), 10);
                        break;
                    }
                    if (choiceForGame == "8")
                    {
                        Simulate(new RandomPlayer(), new MasterPlayer(), 10);
                        break;
                    }
                }

                Console.Write("Press [enter] to play another game....");
                Console.ReadLine();
            }
        }

        static void Simulate(IPlayer player1, IPlayer player2, int countOfGames)
        {
            int x = 0; int o = 0; int draw = 0;
            var firstWinner = 0; var secondWinner = 0;
            var first = player1;
            var second = player2;
            for (int i = 0; i < countOfGames; i++)
            {
                var game = new TicTacToeGame(first, second);
                var result = game.Play();
                if (result.Winner == SymbolOnBoard.X && first == player1) firstWinner++;
                if (result.Winner == SymbolOnBoard.O && first == player1) secondWinner++;
                if (result.Winner == SymbolOnBoard.X && first == player2) secondWinner++;
                if (result.Winner == SymbolOnBoard.O && first == player2) firstWinner++;
                if (result.Winner == SymbolOnBoard.X) x++;
                if (result.Winner == SymbolOnBoard.O) o++;
                if (result.Winner == SymbolOnBoard.Empty) draw++;
                (first, second) = (second, first);
            }

            Console.WriteLine($"Games played : {countOfGames}");
            Console.WriteLine($"Games won by X : {x}");
            Console.WriteLine($"Games won be O : {o}");
            Console.WriteLine($"Games draw : {draw}");
            Console.WriteLine($"{player1.GetType().Name} won {firstWinner} games");
            Console.WriteLine($"{player2.GetType().Name} won {secondWinner} games");
        }
        private static void PlayGame(IPlayer player1, IPlayer player2)
        {
            var game = new TicTacToeGame(player1, player2);
            var result = game.Play();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Game over!");
            if (result.Winner == SymbolOnBoard.Empty)
            {
                Console.WriteLine("The game is draw!");
            }
            else
            {
                Console.WriteLine("Winner is: " + result.Winner);
            }
            Console.WriteLine(result.Board.ToString());
            Console.ResetColor();
        }
    }
}
