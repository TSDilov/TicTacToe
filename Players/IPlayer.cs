using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Players
{
    public interface IPlayer
    {
        IndexOnBoard Play(Board board, SymbolOnBoard symbol);
    }
}
