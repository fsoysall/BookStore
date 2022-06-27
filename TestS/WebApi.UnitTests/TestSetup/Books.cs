using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup {

	internal static class Books {

		public static void AddBooks ( this BookStoreDbContext context ) {

			// context.Authors.AddRange( new Author { Name = "Jane", Surname = "Austen", BirthDate = new DateTime( 1775, 01, 12 ) }, new Author { Name = "Lev", Surname = "Tolstoy", BirthDate = new DateTime( 1750, 02, 03 ) } );
			context.Authors.AddRange( new Author { Name = "Jane Austen", BirthDate = new DateTime( 1775, 01, 12 ) }, new Author { Name = "Lev Tolstoy", BirthDate = new DateTime( 1750, 02, 03 ) } );
			context.Authors.AddRange( new Author { Name = "Sil Beni 3", BirthDate = new DateTime( 2022, 01, 12 ) }, new Author { Name = "Sil Beni 4", BirthDate = new DateTime( 2022, 02, 03 ) } );

			context.Books.AddRange(
				 new Book { /* Id = 1, */ Title = "Lean Startup", GenreId = 1, PageCount = 200, PublishDate = new DateTime( 2001, 06, 12 ), AuthorId = 1 },
				 new Book { /* Id = 2, */ Title = "Herland", GenreId = 2, PageCount = 250, PublishDate = new DateTime( 2010, 05, 23 ), AuthorId = 2 },
				 new Book { /* Id = 3, */ Title = "Dune", GenreId = 2, PageCount = 540, PublishDate = new DateTime( 2001, 12, 21 ), AuthorId = 2 } );

			context.SaveChanges();


			}

		}
	}
