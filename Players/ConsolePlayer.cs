using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Players
{
    public class ConsolePlayer : IPlayer
    {
        public IndexOnBoard Play(Board board, SymbolOnBoard symbol)
        {
            Console.WriteLine(board.ToString());
            IndexOnBoard position;
            while (true)
            {
                Console.Write($"{symbol} Please enter position:");
                var line = Console.ReadLine();
                try
                {
                    position = new IndexOnBoard(line);
                }                
                catch (Exception)
                {
                    Console.WriteLine("Invalid position format!");
                    continue;
                }

                if (!board.GetEmptyPositions().Any(p => p.Equals(position)))
                {
                    Console.WriteLine("This position is not available!");
                    continue;
                }

                break;
            }

            return position;
        }
    }
}
