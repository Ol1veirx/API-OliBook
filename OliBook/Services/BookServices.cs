using Microsoft.AspNetCore.Http.HttpResults;
using OliBook.Models;

namespace OliBook.Services
{
    public class BookServices
    {
        static List<Book> Books { get; }
        static int nextId = 3;
        static BookServices()
        {
            Books = new List<Book>
            {
                new Book() {Id = 1, Title = "Biblioteca da meia noite", Gender = "Romance", WasRead = false},
                new Book() {Id = 2, Title = "Arsene Lupin: Ladrao de Casaca", Gender =  "Aventura",WasRead = true}
            };
        }
        public static List<Book> GetAll() => Books;
        public static Book? Get(int id) => Books.FirstOrDefault(b => b.Id == id);
        public static void Add(Book book)
        {
            book.Id = nextId++;
            Books.Add(book);
        }
        public static void Update(Book book)
        {
            var index = Books.FindIndex(b => b.Id == book.Id);
            if (index < 0) return;
            Books[index] = book;
        }
        public static void Delete(int id)
        {
            var book = Get(id);
            if (book is null) return;
            Books.Remove(book);
        }
    }
}
