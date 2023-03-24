using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_csharp
{
    class Book : IComparable<Book>, IEquatable<Book>
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative.");
                price = value;
            }
        }

        public Book() { }

        public Book(string title, string publisher, int year, int pages, decimal price)
        {
            Title = title;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Price = price;
        }

        public void ApplyDiscount()
        {
            if (DateTime.Now.Year - Year > 2)
                Price *= 0.75m;
        }





        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return Publisher.CompareTo(other.Publisher);
        }
        public bool Equals(Book other)
        {
            if (other == null) return false;
            return Title == other.Title && Publisher == other.Publisher && Year == other.Year && Pages == other.Pages && Price == other.Price;
        }
        
    }
}
