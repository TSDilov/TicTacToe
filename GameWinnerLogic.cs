using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameWinnerLogic
    {
        public bool GameOver(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                if (board.GetRowSymbol(row) != SymbolOnBoard.Empty)
                {
                    return true;
                }
            }

            for (int column = 0; column < board.Columns; column++)
            {
                if (board.GetColumnSymbol(column) != SymbolOnBoard.Empty)
                {
                    return true;
                }
            }

            if (board.GetDiagonalFromTopLeftSymbol() != SymbolOnBoard.Empty)
            {
                return true;
            }

            if (board.GetDiagonalFromBottomLeftSymbol() != SymbolOnBoard.Empty)
            {
                return true;
            }

            return board.IsFull();
        }

        public SymbolOnBoard GetWinner(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                var winner = board.GetRowSymbol(row);
                if (winner != SymbolOnBoard.Empty)
                {
                    return winner;
                }
            }

            for (int column = 0; column < board.Columns; column++)
            {
                var winner = board.GetColumnSymbol(column);
                if (winner != SymbolOnBoard.Empty)
                {
                    return winner;
                }
            }

            var diagonalFromTopWinner = board.GetDiagonalFromTopLeftSymbol();
            if (diagonalFromTopWinner != SymbolOnBoard.Empty)
            {
                return diagonalFromTopWinner;
            }

            var diagonalFromBottomWinner = board.GetDiagonalFromBottomLeftSymbol();
            if (diagonalFromBottomWinner != SymbolOnBoard.Empty)
            {
                return diagonalFromBottomWinner;
            }

            return SymbolOnBoard.Empty;
        }
    }
}
