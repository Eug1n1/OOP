using System;

namespace ProgressBar
{
    public class ProgressBar
    {
        public string Text => _text;

        public int Percentage
        {
            get => _percantage;
            set
            {
                if (value >= 0 && value <= 100)
                    ResetParogress(value);
            }
        }

        private int startIndex;
        private int _percantage = 0;
        private string _text;
        private int top;
        

        public void Start(string text)
        {
            _text = text;
            _percantage = 0;
            
            Console.Write($"{Text}: ");
            startIndex = Console.CursorLeft;
            top = Console.CursorTop;
            Console.Write($"{_percantage}%");
        }
        
        private void ResetParogress(int newPercentage)
        {
            Console.SetCursorPosition(startIndex, top);
            for (int i = 0; i < newPercentage.ToString().Length + 1; i++)
            {
                Console.Write(" ");
            }
            
            Console.SetCursorPosition(startIndex, top);
            _percantage = newPercentage;
            Console.Write($"{_percantage}%");
        }
    }
}