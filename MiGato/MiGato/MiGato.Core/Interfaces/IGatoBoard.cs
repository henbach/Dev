using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiGato.Core.Interfaces
{
    public class UserMarkEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char? Mark { get; set; } = null;
        public UserMarkEventArgs(int row, int column)
        {
            Row = row;
            Column = column;            
        }
        public UserMarkEventArgs(int row, int column, char mark)
        {
            Row = row;
            Column = column;
            Mark = mark;
        }
    }
    public interface IGatoBoard
    {
        void ResetBoard();
        bool PlaceMark(int row, int column, char mark);
        void ShowResult(string result);
        event EventHandler<UserMarkEventArgs> UserMarkPlaced;
        event EventHandler GameRestarted;
    }
}
