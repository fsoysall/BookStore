using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Data.BookStore;
using WebApi.Data.BookStore.CRUD;
using AutoMapper;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        readonly BookStoreDbContext DbContext;
        private readonly IMapper _mapper;

        //public BookController() { }
        public BookController(BookStoreDbContext context,IMapper pMapper) { DbContext = context;_mapper= pMapper; }

        // private static List<Book> BookList = new List<Book>(){
        //                                                         new Book {Id=1, Title="Lean Startup", GenreId=1 /* personal growth */, PageCount=200, PublishDate=new DateTime(2001,06,12) } ,
        //                                                         new Book {Id=2, Title="Herland", GenreId=2 /* science Fiction */, PageCount=250, PublishDate=new DateTime(2010,05,23) },
        //                                                         new Book {Id=3, Title="Dune", GenreId=2 /* science Fiction */, PageCount=540, PublishDate=new DateTime(2001,12,21) }
        //                                                         };


        [HttpGet("Books/List")] public IActionResult GetBooks() => Ok(new BookStore_CRUD_R(DbContext,_mapper).Handle());

        [HttpPost("Books/Add")]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            try { return Ok(new BookStore_CRUD_C(DbContext,_mapper).Handle(newBook)); }
            catch (System.Exception ex) { return BadRequest($"BS.Add.Err : {ex.Message}"); }
        }

        [HttpPost("/Books/Update/{Id}")]
        public IActionResult UpdateBook(int Id, [FromBody] Book pBook)
        {
            pBook.Id=Id;
            try { return Ok($"KİTAP GÜNCELLENDİ: {new BookStore_CRUD_U(DbContext).Handle(pBook)} / {pBook.Title}"); }
            catch (System.Exception ex) { return BadRequest($"BS.Update.Err : {ex.Message}"); }
        }


        [HttpDelete("/Books/Delete/{pId}")]
        public IActionResult DeleteBook(int pId)
        {
            try { return Ok($"Kayıt Silindi: {new BookStore_CRUD_D(DbContext).Handle(pId)}"); }
            catch (System.Exception ex) { return BadRequest($"BS.Delete.Err : {ex.Message}"); }
        }
    }
}
