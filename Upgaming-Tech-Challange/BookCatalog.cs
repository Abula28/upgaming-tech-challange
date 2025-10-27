using Microsoft.AspNetCore.Mvc;
using Upgaming_Tech_Challange.Dtos;
using Upgaming_Tech_Challange.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Upgaming_Tech_Challange
{
    public class BookCatalog
    {
        private static List<Author> _authors = new List<Author>
        {
            new Author { ID = 1, Name = "Robert C. Martin" },
            new Author { ID = 2, Name = "Jeffrey Richter" }
        };

        private static List<Book> _books = new List<Book>
        {
            new Book
            {
                ID = 1,
                Title = "Clean Code",
                AuthorID = 1,
                PublicationYear = 2008
            },
            new Book
            {
                ID = 2,
                Title = "CLR via C#",
                AuthorID = 2,
                PublicationYear = 2012
            },
            new Book
            {
                ID = 3,
                Title = "The Clean Coder",
                AuthorID = 1,
                PublicationYear = 2011
            }
        };

        public  List<Book> GetBooks(int? years, string? field)
        {
            List<Book> books = _books;
            if (Convert.ToBoolean(years))
            {
                books = books.Where(b => years == b.PublicationYear).ToList();
            }
            if (field != null)
            {
                if (field == "title")
                {
                    books = books.OrderBy(e => e.Title).ToList();
                }
            }

            return books;
        }

        public List<Book> GetBooksByAuthorId(int id)
        {
            List<Book> books = _books.Where(e => e.AuthorID == id).ToList();
            

            return books;
        }

        public Book CreateBook(BookDto book)
        {
            if(book == null)
            {
                throw new Exception("Enter valid a values");
            }

            if(book.Title == null)
            {
                throw new Exception("Title cannot be null");
            }

            if (book.PublicationYear > DateTime.Now.Year)
            {
                throw new Exception("Date cannot be in the future");
            }

            bool authorExists = _authors.Any(a => a.ID == book.AuthorId);
            if (!authorExists)
            {
                throw new Exception($"Author with id {book.AuthorId} not found");
            }

            var newBook = new Book
            {
                ID = _books.Max(b => b.ID) + 1,
                Title = book.Title,
                AuthorID = book.AuthorId,
                PublicationYear = book.PublicationYear
            };
            _books.Add(newBook);
            return newBook;
        }
    }
}
