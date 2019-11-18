using Library.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Api.Helpers.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto Map(this Author author)
        {
            return new AuthorDto
            {
                Age = author.DateOfDeath == null ?
                    CalculateAgeCorrect(author.DateOfBirth, DateTimeOffset.UtcNow) :
                    CalculateAgeCorrect(author.DateOfBirth, author.DateOfDeath.Value),
                Genre = author.Genre,
                Name = $"{author.FirstName} {author.LastName}",
                Id = author.AuthorId
            };
        }

        public static IEnumerable<AuthorDto> Map(this IEnumerable<Author> authors)
        {
            foreach(var author in authors)
            {
                yield return author.Map();
            }
        }

        public static Author Map(this AuthorForCreationDto author)
        {
            return new Author
            {
                Books = author.Books.Map().ToList(),
                DateOfBirth = author.DateOfBirth,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Genre = author.Genre
            };
        }

        public static IEnumerable<Author> Map(this IEnumerable<AuthorForCreationDto> authors)
        {
            foreach(var author in authors)
            {
                yield return author.Map();
            }
        }

        public static Author Map(this AuthorForCreationWithDateOfDeathDto author)
        {
            return new Author
            {
                Books = author.Books.Map().ToList(),
                DateOfBirth = author.DateOfBirth,
                DateOfDeath = author.DateOfDeath,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Genre = author.Genre
            };
        }

        public static IEnumerable<Author> Map(this IEnumerable<AuthorForCreationWithDateOfDeathDto> authors)
        {
            foreach (var author in authors)
            {
                yield return author.Map();
            }
        }

        private static int CalculateAgeCorrect(DateTimeOffset birthDate, DateTimeOffset now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }
    }
}

