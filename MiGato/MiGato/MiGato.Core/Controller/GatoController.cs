using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiGato.Core.Common;
using MiGato.Core.Interfaces;

namespace MiGato.Core.Controller
{
    public class GatoController : IGatoController
    {
        private enum GameState
        {
            Player1,
            Player2,
            Player1Won,
            Player2Won,
            NoWinner
        }

        private GameState _gameState;
        private char[,] _boardState = new char[3,3];
        private const char Player1Mark = 'X';
        private const char Player2Mark = 'O';
        private const char EmptyMark = ' ';
        private string _winnerCombination = string.Empty;

        private IGatoBoard _board;
        private GameBoardHelper _gameBoardHelper = new GameBoardHelper();

        public char PlayerOneMark => Player1Mark;

        public char PlayerTwoMark => Player2Mark;

        public string WinnerCombination 
        {
            get
            {
                if (_gameState != GameState.Player1Won && _gameState != GameState.Player2Won)
                    return string.Empty;
                return _winnerCombination;
            }
        }

        public GatoController() 
        {
            _gameBoardHelper.SetEmptyMark(EmptyMark);
            _gameBoardHelper.SetBoard(ref _boardState);
        }

        public char[,] GetCurrentBoardState()
        {
            return _boardState;
        }

        public void SetGatoBoard(IGatoBoard board)
        {
            _board = board;
            _board.UserMarkPlaced += OnUserMarkPlaced;
            _board.GameRestarted += OnGameRestarted;
            _gameBoardHelper.ResetBoardState();
        }

        private void OnGameRestarted(object? sender, EventArgs e)
        {
            StartGame();
            _board.ShowResult("New game");
        }

        private void OnUserMarkPlaced(object? sender, UserMarkEventArgs e)
        {
            if(_gameState != GameState.Player1 && _gameState != GameState.Player2)
            {
                return;
            }

            char currentMark = _gameState == GameState.Player1 ? Player1Mark : Player2Mark;
            if (e.Mark != null)
            {
                //currentMark = (char)e.Mark;
            }

            char value = _boardState[e.Row, e.Column];
            if (value != ' ')
            {
                // Cell already occupied
                return;
            }

            _boardState[e.Row, e.Column] = currentMark;
            _board.PlaceMark(e.Row, e.Column, currentMark);

            if(_gameBoardHelper.CheckIfPlayerWon(currentMark, 3))
            {
                _gameState = _gameState == GameState.Player1 ? GameState.Player1Won : GameState.Player2Won;
                _board.ShowResult(_gameState == GameState.Player1Won ? "Player 1 Wins!" : "Player 2 Wins!");
                return;
            }
            else if (_gameBoardHelper.CheckIfBoardIsFull() )
            {
                _gameState = GameState.NoWinner;
                _board.ShowResult("It's a Draw!");
                return;
            }
            else
            {
                if (_gameState == GameState.Player1)
                    _gameState = GameState.Player2;
                else
                    _gameState = GameState.Player1;
            }
        }
              
        public void StartGame()
        {
           _gameBoardHelper.ResetBoardState();
            _board.ResetBoard();
            _gameState = GameState.Player1;
        }        
    }
}
