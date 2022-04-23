using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Players;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public TicTacToeGame(IPlayer firtsPlayer, IPlayer secondPlayer)
        {
            this.FirtsPlayer = firtsPlayer;
            this.SecondPlayer = secondPlayer;
            this.WinnerLogic = new GameWinnerLogic();
        }

        public IPlayer FirtsPlayer { get; }
        public IPlayer SecondPlayer { get; }
        public GameWinnerLogic WinnerLogic { get; }

        public GameResult Play()
        {
            Board board = new Board();
            IPlayer currentPlayer = this.FirtsPlayer;
            SymbolOnBoard symbol = SymbolOnBoard.X;
            while (!this.WinnerLogic.GameOver(board))
            {
                var move = currentPlayer.Play(board, symbol);
                board.PlaceSymbol(move, symbol);
                if (currentPlayer == this.FirtsPlayer)
                {
                    currentPlayer = this.SecondPlayer;
                    symbol = SymbolOnBoard.O;
                }
                else
                {
                    currentPlayer = this.FirtsPlayer;
                    symbol = SymbolOnBoard.X;
                }
            }

            var winner = this.WinnerLogic.GetWinner(board);
            return new GameResult(winner, board);
        }

        
    }
}
