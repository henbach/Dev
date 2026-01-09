using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiGato.Core.Interfaces
{
    public interface IGatoController
    {
        void StartGame();
        void SetGatoBoard(IGatoBoard board);
        char[,] GetCurrentBoardState();

        string WinnerCombination { get; }
        char PlayerOneMark { get; }
        char PlayerTwoMark { get; }
    }
}
