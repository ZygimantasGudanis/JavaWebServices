using System;
using System.Collections.Generic;
using System.Linq;
using Library.Api.Helpers;
using Library.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.Services
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryContext _context;
        private readonly IPropertyMappingService _propertyMappingService;

        public LibraryRepository(LibraryContext context, IPropertyMappingService mappingService)
        {
            _context = context;
            _propertyMappingService = mappingService;

            _context.Database.EnsureCreated();
        }

        public void AddAuthor(Author author)
        {
            author.AuthorId = Guid.NewGuid();
            _context.Authors.Add(author);
            if (author.Books.Any())
            {
                foreach(var book in author.Books)
                {
                    book.Id = Guid.NewGuid();
                }
            }
        }

        public void AddBookForAuthor(Guid authorId, Book book)
        {
            var author = GetAuthor(authorId);
            if(author != null)
            {
                //if (book.Id == Guid.Empty)
                //{
                //    book.Id = Guid.NewGuid();
                //}
                //author.Books.Add(book);

                book.Author = author;
                book.AuthorId = authorId;

                _context.Books.Add(book);
            }
        }

        public bool AuthorExists(Guid authorId)
        {
            return _context.Authors.Any(a => a.AuthorId == authorId);
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public void DeleteBook(Book book)
        {
            _context.Remove(book);
        }

        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
        }

        public PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {
            var collectionBeforePaging =
                _context.Authors.ApplySort(authorsResourceParameters.OrderBy,
                _propertyMappingService.GetPropertyMapping<AuthorDto, Author>());

            if(!string.IsNullOrEmpty(authorsResourceParameters.Genre))
            {
                var genreForWhereClause = authorsResourceParameters.Genre.Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.Genre.ToLowerInvariant() == genreForWhereClause);
            }

            if(!string.IsNullOrEmpty(authorsResourceParameters.SearchQuery))
            {
                var searchQueryforWhereClause = authorsResourceParameters.SearchQuery.Trim().ToLowerInvariant();

                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.Genre.ToLowerInvariant().Contains(searchQueryforWhereClause)
                    || a.FirstName.ToLowerInvariant().Contains(searchQueryforWhereClause)
                    || a.LastName.ToLowerInvariant().Contains(searchQueryforWhereClause));
            }
            return PagedList<Author>.Create(collectionBeforePaging, 
                authorsResourceParameters.PageNumber, 
                authorsResourceParameters.PageSize);
        }

        public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds)
        {
            return _context.Authors.Where(a => authorIds.Contains(a.AuthorId))
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .ToList();
        }

        public Book GetBookForAuthor(Guid authorId, Guid bookId)
        {
            return _context.Books
                .Where(b => b.AuthorId == authorId && b.Id == bookId).FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksForAuthor(Guid authorId)
        {
            return _context.Books.Where(b => b.AuthorId.Equals(authorId))
                .OrderBy(b => b.Title)
                .ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateAuthor(AuthorForUpdate author, Guid authorId)
        {
            var authorEntity = GetAuthor(authorId);
            authorEntity.DateOfBirth = author.DateOfBirth ?? authorEntity.DateOfBirth;
            authorEntity.DateOfDeath = author.DateOfDeath ?? authorEntity.DateOfDeath;
            authorEntity.FirstName = author.FirstName ?? authorEntity.FirstName;
            authorEntity.LastName = author.LastName ?? authorEntity.LastName;
            authorEntity.Genre = author.Genre ?? authorEntity.Genre;
        }

        public void UpdateBookForAuthor(Book book)
        {
            var bookEntity = GetBookForAuthor(book.AuthorId, book.Id);

            if(!book.Equals(bookEntity))
            {
                bookEntity.Title = book.Title;
                bookEntity.Description = bookEntity.Description;
            }
        }
    }
}
