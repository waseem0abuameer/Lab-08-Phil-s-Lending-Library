using System;
using System.Collections;
using System.Collections.Generic;

namespace lap08
{
    internal class Program
    {

        public class Book
        {
            public string Title { get; set; }

            public string Author { get; set; }
            public int numberOfPages { get; set; }

        }
        class Library: ILibrary
        {
            public string LibraryName { get; set; }
            public int NumberOfBooks { get; set; }

            public int Count => throw new NotImplementedException();

            private  Dictionary<string, Book> books=new Dictionary<string, Book>();
            public Library()
            {
                books = new Dictionary<string, Book>();
            }
            public void Add(string title, string firstName, string lastName, int numberOfPages)
            {
                string Author = firstName + " " + lastName;
              
                books.Add(title, new Book { Author = Author, Title = title, numberOfPages = numberOfPages });
                NumberOfBooks++;
            }
            public Book Borrow(string title)
            {
                if (books.ContainsKey(title))
                {
                    Book book = books[title];
                    books.Remove(title);
                    NumberOfBooks--;
                    return book;
                }
                else { return null; }
            }
            public void Return(Book book)
            {
                Console.WriteLine("enter the key");
                string x = Console.ReadLine();
                books.Add(x, book);
                NumberOfBooks++;
            }
            public void PrintAll()
            {
                foreach(KeyValuePair<string, Book> entry in books)
                {
                    Console.Write(entry.Key+" ");
                    Console.Write(entry.Value.Title + " ");
                    Console.Write(entry.Value.Author + " ");
                    Console.Write(entry.Value.numberOfPages + " ");


                }
                Console.WriteLine(NumberOfBooks);

            }

            public IEnumerator<Book> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public interface ILibrary : IReadOnlyCollection<Book>
        {
            /// <summary>
            /// Add a Book to the library.
            /// </summary>
            void Add(string title, string firstName, string lastName, int numberOfPages);

            /// <summary>
            /// Remove a Book from the library with the given title.
            /// </summary>
            /// <returns>The Book, or null if not found.</returns>
            Book Borrow(string title);

            /// <summary>
            /// Return a Book to the library.
            /// </summary>
            void Return(Book book);
        }
        static void Main(string[] args)
        {
           
          Library l1=new Library();
            l1.Add("gg","gg","gg",100);
            l1.Add("gg", "gg", "gg", 100);
            l1.Add("gg", "gg", "gg", 100);
            l1.Add("gg", "gg", "gg", 100);
            l1.PrintAll();




        }
    }
}
