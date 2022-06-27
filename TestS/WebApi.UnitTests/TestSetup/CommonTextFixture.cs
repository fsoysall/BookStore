using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.UnitTests.TestSetup {

	public class CommonTextFixture {

		public BookStoreDbContext Context { get; set; }
		public IMapper Mapper { get; set; }


		public CommonTextFixture () {
			var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase( databaseName: "BookStoreTestDB" ).Options;
			Context = new BookStoreDbContext( options );
			Context.Database.EnsureCreated();

			Context.AddBooks();
			Context.AddGenres();

			Mapper = new MapperConfiguration( c => c.AddProfile<MappingProfile>() ).CreateMapper();

			}

		}
	}
