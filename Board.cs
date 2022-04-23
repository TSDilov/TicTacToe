using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private SymbolOnBoard[,] board;

        public Board()
            : this(3, 3)
        {            
        }

        public Board(int rows, int columns)
        {
            if (rows != columns)
            {
                throw new ArgumentException("Rows should be equal to columns!");
            }
            this.Rows = rows;
            this.Columns = columns;
            this.board = new SymbolOnBoard[rows, columns];
        }

        public int Rows { get; }

        public int Columns { get; }

        public SymbolOnBoard[,] BoardField => this.board;

        public SymbolOnBoard GetRowSymbol(int row)
        {
            var symbol = this.board[row, 0];
            if (symbol == SymbolOnBoard.Empty)
            {
                return SymbolOnBoard.Empty;
            }

            for (int column = 1; column < this.Columns; column++)
            {
                if (this.board[row, column] != symbol)
                {
                    return SymbolOnBoard.Empty;
                }
            }

            return symbol;
        }

        public SymbolOnBoard GetColumnSymbol(int column)
        {
            var symbol = this.board[0, column];
            if (symbol == SymbolOnBoard.Empty)
            {
                return SymbolOnBoard.Empty;
            }

            for (int row = 0; row < this.Rows; row++)
            {
                if (this.board[row, column] != symbol)
                {
                    return SymbolOnBoard.Empty;
                }
            }

            return symbol;
        }

        public SymbolOnBoard GetDiagonalFromTopLeftSymbol()
        {
            var symbol = this.board[0, 0];
            if (symbol == SymbolOnBoard.Empty)
            {
                return SymbolOnBoard.Empty;
            }

            for (int indexSide = 1; indexSide < this.Rows; indexSide++)
            {
                if (this.board[indexSide, indexSide] != symbol)
                {
                    return SymbolOnBoard.Empty;
                }
            }

            return symbol;
        }

        public SymbolOnBoard GetDiagonalFromBottomLeftSymbol()
        {
            var symbol = this.board[this.Rows - 1, 0];
            if (symbol == SymbolOnBoard.Empty)
            {
                return SymbolOnBoard.Empty;
            }

            for (int indexSide = this.Rows - 2; indexSide >= 0; indexSide--)
            {
                if (this.board[indexSide, this.Rows - indexSide - 1] != symbol)
                {
                    return SymbolOnBoard.Empty;
                }
            }

            return symbol;
        }

        
        public IEnumerable<IndexOnBoard> GetEmptyPositions()
        {
            var positions = new List<IndexOnBoard>();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    if (this.board[i, j] == SymbolOnBoard.Empty)
                    {
                        positions.Add(new IndexOnBoard(i, j));
                    }
                }
            }

            return positions;   
        }

        public bool IsFull()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    if (this.board[i, j] == SymbolOnBoard.Empty)
                    {
                        return false;
                    }
                }
            }
                
            return true;
        }

        public void PlaceSymbol(IndexOnBoard index, SymbolOnBoard symbol)
        {
            if (index.Row < 0 || index.Column < 0
                || index.Row >= this.Rows || index.Column >= this.Columns)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            this.board[index.Row, index.Column] = symbol;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    if (this.board[i, j] == SymbolOnBoard.Empty)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(this.board[i, j]);
                    }

                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
