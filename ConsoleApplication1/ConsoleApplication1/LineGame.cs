using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LineGame : iLineGame
    {
        private const string EndState = "....>";
        private string _lineState;

        public LineGame(string StartingState)
        {
            if (ValidateStartingState(StartingState))
            {
                _lineState = StartingState;
            }
            else throw new ArgumentException("Invalid starting state.");
        }

        private bool ValidateStartingState(string startingState)
        {
            return startingState.Count(x => x == '.') == 4 &&
                   startingState.Count(x => x == '>') == 1 && 
                   startingState != EndState;
        }

        public void MoveRight()
        {
            // ">...."      0
            // ".>..."      1
            if (_lineState != EndState)
            {
                
                string NewString = "";
                var MarkerAt = _lineState.IndexOf(">");
                MarkerAt++;
                for (int i = 0; i < MarkerAt; i++)
                {
                    NewString += ".";
                }
                NewString += ">";
                var strNewEnding = new string('.', 4 - MarkerAt);
                NewString += strNewEnding;
            }
            else
            {
                throw new ArgumentException("Out of bounds!");
            }
        }

        public bool CheckGameOver()
        {
            return _lineState == EndState;
        }

        public string CurrentState()
        {
            return _lineState;
        }
    }
}
