using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiGato.Core.Common
{
    public class GameBoardHelper
    {
        private char[,] _board;
        private char EmptyMark;
        public GameBoardHelper() { }
            
        public void SetEmptyMark(char emptyMark)
        {
            EmptyMark = emptyMark;
        }
        public void SetBoard(ref char[,] boardState)
        {
            _board = boardState;
        }

        public bool CheckIfPlayerWon(char mark, int rowLength)
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (IsMarkFoundInRow(i, j, mark, rowLength))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsMarkFoundInRow(int row,
            int column,
            char mark,
            int rowLength)
        {            
            var winningCombinations = CreateWinningCombinations(row, column, rowLength);
            foreach (var combination in winningCombinations)
            {
                var positions = combination.Split(';');
                bool win = true;
                foreach (var position in positions)
                {
                    int x = int.Parse(position.Split(',')[0]);
                    int y = int.Parse(position.Split(',')[1]);
                    
                    if(x >= _board.GetLength(0) 
                        || y >= _board.GetLength(1)
                        || x < 0
                        || y < 0)
                    {
                        win = false;
                        break;
                    }

                    if (_board[x, y] != mark)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    return true;
                }
            }
            return false;
        }

        private  List<string> CreateWinningCombinations(int row, int column, int rowLength )
        {
            List<string> winningCombinations = new List<string>();

            string[] verticalCombination = new string[rowLength];
            string[] horizontalCombination = new string[rowLength];
            string[] diagonalCombination = new string[rowLength];
            string[] reverseDiagonalCombination = new string[rowLength];

            for (int i = 0; i < rowLength; i++)
            {
                verticalCombination[i] = $"{row + i},{column}";
                horizontalCombination[i] = $"{row},{column + i}";
                diagonalCombination[i] = $"{row + i},{column + i}";
                reverseDiagonalCombination[i] = $"{row + i},{column - i}";
            }
            winningCombinations.Add(string.Join(";", verticalCombination));
            winningCombinations.Add(string.Join(";", horizontalCombination));
            winningCombinations.Add(string.Join(";", diagonalCombination));
            winningCombinations.Add(string.Join(";", reverseDiagonalCombination));

            return winningCombinations;
        }

        public void ResetBoardState()
        {            
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    _board[i, j] = EmptyMark;
                }
            }            
        }
        public  bool CheckIfBoardIsFull()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(0); j++)
                {
                    if (_board[i, j] == EmptyMark)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
