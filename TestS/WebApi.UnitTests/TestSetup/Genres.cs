using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup {

	internal static class Genres {

		public static void AddGenres ( this BookStoreDbContext context ) {

			context.Genres.AddRange( new Genre { Name = "Personel Growth" }, new Genre { Name = "Science Fiction" }, new Genre { Name = "Romance" } );


			context.SaveChanges();


			}

		}
	}
