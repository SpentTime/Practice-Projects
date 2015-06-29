using System;
using System.Collections.Generic;
using System.Linq;

namespace RIW
{
    class ScreenManipulator
    {
        private List<string> _screenText;
        private int _topPosition, _leftPosition;

        public List<string> ScreenText { get { return _screenText; } }

        public int TopPosition
        {
            get { return this._topPosition; }
            private set
            {
                if (value < 0) 
                    this._topPosition = value; 
                else if (value < this._screenText.Count())
                {
                    this._topPosition = value;
                    this.LeftPosition = this._leftPosition;
                }
            }
        }
        
        public int LeftPosition
        {
            get { return this._leftPosition; }
            private set
            {
                if (value < 0) 
                    this._leftPosition = value;
                else if (value < this._screenText[TopPosition].Count())
                    this._leftPosition = value;
                else if (value >= this._screenText[TopPosition].Count())
                    this._leftPosition = this._screenText[TopPosition].Count();
            }
        }

        private void InsertChar(char c)
        {
            if (this.LeftPosition < this._screenText[this.TopPosition].Count()) // if cursor is not at end of line, insert character
                this._screenText[this.TopPosition] = this._screenText[this.TopPosition].Insert(this.LeftPosition, c.ToString());
            else
            {
                this._screenText[this.TopPosition] += c;
                LeftPosition++;
            }
            LeftPosition++;
        }

        private void InsertNewLine()
        {
            this._screenText.Insert(TopPosition + 1, this._screenText[TopPosition].Substring(LeftPosition));    
            this._screenText[TopPosition] = this._screenText[TopPosition].Substring(0, LeftPosition);
            this.TopPosition++;
            this.LeftPosition = this._screenText[TopPosition].Count();
        }

        public ScreenManipulator()
        {
            this._screenText = new List<string>() { "" };
            this._topPosition = 0;
            this._leftPosition = 0;
        }

        public void getInput(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    this.TopPosition--;
                    break;
                case ConsoleKey.DownArrow:
                    this.TopPosition++;
                    break;
                case ConsoleKey.LeftArrow:
                    this.LeftPosition--;
                    break;
                case ConsoleKey.RightArrow:
                    this.LeftPosition++;
                    break;
                case ConsoleKey.Enter:
                    this.InsertNewLine();
                    break;
                case ConsoleKey.Tab: //just adding four spaces for now.
                    for (int i = 0; i < 4; i++)
                        InsertChar(' ');
                    break;
                default:
                    if (keyInfo.KeyChar > 31 && keyInfo.KeyChar < 127)  // if c is a printable character
                        InsertChar(keyInfo.KeyChar);
                    break;
            }
        }
    }
}
