using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    /* 3.	Описать класс «домашняя библиотека». Предусмотреть возможность работы с 
     * произвольным числом книг, поиска книги по какому-либо признаку 
     * (например, по автору или по году издания), добавления книг в библиотеку, 
     * удаления книг из нее, сортировки книг по разным полям.
 */

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author}, {Year}";
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public IEnumerable<Book> SearchByAuthor(string author)
        {
            return books.Where(b => b.Author == author);
        }

        public IEnumerable<Book> SearchByYear(int year)
        {
            return books.Where(b => b.Year == year);
        }

        public void SortByTitle()
        {
            books = books.OrderBy(b => b.Title).ToList();
        }

        public void SortByAuthor()
        {
            books = books.OrderBy(b => b.Author).ToList();
        }

        public void SortByYear()
        {
            books = books.OrderBy(b => b.Year).ToList();
        }

        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Library library = new Library();

            library.AddBook(new Book { Title = "Хроники Нарнии", Author = "Клайв Стейплз Льюис", Year = 1956 });
            library.AddBook(new Book { Title = "Гарри Поттер", Author = "Дж. К. Роулинг", Year = 2007 });
            library.AddBook(new Book { Title = "Остров Сокровищ", Author = "Р. Л. Стивенсон", Year = 1883 });

            Console.WriteLine("Книги в библиотеке:");
            library.DisplayBooks();

            Console.WriteLine("\nОтсортированные по названию:");
            library.SortByTitle();
            library.DisplayBooks();

            Console.WriteLine("\nОтсортированные по Автору:");
            library.SortByAuthor();
            library.DisplayBooks();

            Console.WriteLine("\nОтсортированные по году выпуска:");
            library.SortByYear();
            library.DisplayBooks();

            Console.WriteLine("\n Поиска по автору (Р. Л. Стивенсон):");
            foreach (var book in library.SearchByAuthor("Р. Л. Стивенсон"))
            {
                Console.WriteLine(book);
            }
        }
    }
}
