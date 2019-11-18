using Library.Api.Models;
using System.Collections.Generic;

namespace Library.Api.Helpers.Mappers
{
    public static class BookMapper
    {
        public static BookDto Map(this Book book)
        {
            return new BookDto
            {
                AuthorId = book.AuthorId,
                Description = book.Description,
                Id = book.Id,
                Title = book.Title
            };
        }

        public static IEnumerable<BookDto> Map(this IEnumerable<Book> books)
        {
            foreach(var book in books)
            {
                yield return book.Map();
            }
        }

        public static BookForUpdateDto BookForUpdateMap(this Book book)
        {
            return new BookForUpdateDto
            {
                Description = book.Description,
                Title = book.Title
            };
        }

        public static Book Map(this BookForCreationDto book)
        {
            return new Book
            {
                Title = book.Title,
                Description = book.Description
            };
        }

        public static IEnumerable<Book> Map(this IEnumerable<BookForCreationDto> books)
        {
            foreach(var book in books)
            {
                yield return book.Map();
            }
        }

        public static Book Map(this BookForUpdateDto book)
        {
            return new Book
            {
                Title = book.Title,
                Description = book.Description
            };
        }

        public static IEnumerable<Book> Map<TBook>(this IEnumerable<BookForUpdateDto> books)
        {
            foreach (var book in books)
            {
                yield return book.Map();
            }
        }
    }
}
