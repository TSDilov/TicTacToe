using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class IndexOnBoard
    {
        public IndexOnBoard(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        public IndexOnBoard(string str)
        {
            var parts = str.Split(',');
            this.Row = int.Parse(parts[0]);
            this.Column = int.Parse(parts[1]);
        }
        public override bool Equals(object obj)
        {
            var otherIndex = obj as IndexOnBoard;

            return this.Row == otherIndex.Row &&
                this.Column == otherIndex.Column;
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public override string ToString()
        {
            return $"{this.Row},{this.Column}";
        }
    }
}
