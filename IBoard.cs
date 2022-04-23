using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IBoard
    {
        bool IsFull();

        void PlaceSymbol(IndexOnBoard index, SymbolOnBoard symbol);

        IEnumerable<IndexOnBoard> GetEmptyPositions();

        SymbolOnBoard GetRowSymbol(int row);
        SymbolOnBoard GetColumnSymbol(int column);
        SymbolOnBoard GetDiagonalFromTopLeftSymbol();
        SymbolOnBoard GetDiagonalFromBottomLeftSymbol();
    }
}
