using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Players
{
    public class RandomPlayer : IPlayer
    {
        private Random random;
        public RandomPlayer()
        {
            this.random = new Random();
        }
        public IndexOnBoard Play(Board board, SymbolOnBoard symbol)
        {
            var availablePositions = board.GetEmptyPositions().ToList();
            return availablePositions[random.Next(0, availablePositions.Count)];
        }
    }
}
