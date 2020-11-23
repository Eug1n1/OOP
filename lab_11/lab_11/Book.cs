using System;

namespace lab_11
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public decimal Cost { get; set; }
        public string Type { get; set; }

        public Book()
        {
        }

        public Book(string author, int date, int length, decimal cost)
        {
            Author = author;
            Year = date;
            Length = length;
            Cost = cost;
        }
        
        
        
    }
}