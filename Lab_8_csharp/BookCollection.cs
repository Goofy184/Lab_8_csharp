﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab_8_csharp
{
    class BookCollection
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public string DisplayBooks()
        {
            string text;
            text = "";
            foreach (var book in books)
               text+=($"{book.Title}, {book.Publisher}, {book.Year}, {book.Pages}, {book.Price},\n");
            return text;
        }

        public void SortByPublisher()
        {
            books = books.OrderBy(b => b.Publisher).ToList();
        }

        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var book in books)
                    writer.WriteLine($"{book.Title};{book.Publisher};{book.Year};{book.Pages};{book.Price}");
            }
        }
        public void PriceChanger() {
            foreach (var book in books)
                book.ApplyDiscount();
        }
        public void Clearbooks() {
            books.Clear();
        }
        public void LoadFromFile(string fileName)
        {
            books.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    books.Add(new Book(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), decimal.Parse(data[4])));
                }
            }
        }
    }
}
