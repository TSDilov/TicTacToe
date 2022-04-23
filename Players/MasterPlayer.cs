using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Players
{
    public class MasterPlayer : IPlayer
    {
        public MasterPlayer()
        {
            this.WinnerLogic = new GameWinnerLogic();
        }

        public GameWinnerLogic WinnerLogic { get; }

        public IndexOnBoard Play(Board board, SymbolOnBoard symbol)
        {           
            IndexOnBoard bestMove = null;
            int bestMoveValue = -1000;
            var moves = board.GetEmptyPositions();
            foreach (var move in moves)
            {
                board.PlaceSymbol(move, symbol);
                var value = MinMax(board, symbol, symbol == SymbolOnBoard.X ? SymbolOnBoard.O : SymbolOnBoard.X);
                board.PlaceSymbol(move, SymbolOnBoard.Empty);
                if (value > bestMoveValue)
                {
                    bestMove = move;
                    bestMoveValue = value;
                }
            }

            return bestMove;
        }

        private int MinMax(Board board, SymbolOnBoard player, SymbolOnBoard currentPlayer)
        {
            if (this.WinnerLogic.GameOver(board))
            {
                var winner = this.WinnerLogic.GetWinner(board);
                if (winner == player) return 1;
                else if (winner == SymbolOnBoard.Empty) return 0;
                else return -1;
            }

            var bestValue = player == currentPlayer ? -100 : 100;
            var options = board.GetEmptyPositions();
            foreach (var option in options)
            {
                board.PlaceSymbol(option, currentPlayer);
                var value = MinMax(board, player, currentPlayer == SymbolOnBoard.O ? SymbolOnBoard.X : SymbolOnBoard.O  );
                board.PlaceSymbol(option, SymbolOnBoard.Empty);

                bestValue = currentPlayer == player ? Math.Max(bestValue, value) : Math.Min(bestValue, value);
            }

            return bestValue;
        }
    }
}
