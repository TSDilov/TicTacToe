using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameResult
    {
        public GameResult(SymbolOnBoard winner, Board board)
        {
            this.Winner = winner;
            this.Board = board;
        }

        public SymbolOnBoard Winner { get; }
        public Board Board { get; }
    }
}
