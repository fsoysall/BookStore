using System.Runtime.InteropServices;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Data.BookStore;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FluentValidation;

namespace WebApi.Data.BookStore.CRUD
{

    public class BookStore_CRUD_C : DbContext
    {

        public new Book Model { get; set; }
        public BookStoreDbContext DbContext { get; }
        public BookStore_CRUD_C(BookStoreDbContext pDbContext, IMapper pMapper) { DbContext = pDbContext; _mapper = pMapper; }

        private readonly IMapper _mapper;

        public int Handle(Book newBook)
        {
            this.Model = newBook;
            new Book_Validator().ValidateAndThrow(newBook);
            //var r = v.ValidateAndThrow(this);
            //foreach (var e in r.Errors) { Console.WriteLine($"v.e: {e.PropertyName} :: {e.AttemptedValue} :: {e.ErrorMessage} "); }

            var book = DbContext.Books.SingleOrDefault(s => s.Title == newBook.Title);
            if (book is not null) { throw new InvalidOperationException("Kitap Zaten VAR !"); }
            book = _mapper.Map(newBook, book); // new Book();
            // book.Title = newBook.Title;
            // book.GenreId = newBook.GenreId;
            // book.PageCount = newBook.PageCount;
            // book.PublishStore = newBook.PublishStore;
            // book.PublishDate = newBook.PublishDate;

            DbContext.Books.Add(book); DbContext.SaveChanges();
            return DbContext.Books.SingleOrDefault(s => s.Id == book.Id).Id;
            //return Ok($"KİTAP EKLENDİ: {pBook.Id} / {pBook.Title}");

        }




        //[HttpPut]
        public IActionResult AddBook([FromBody] Book pBook)
        {
            // var book = DbC.Books.SingleOrDefault(s => s.Title == pBook.Title);
            // if (book is not null) { return BadRequest("Kitap Zaten VAR !"); }
            // 
            // DbC.Books.Add(pBook); DbC.SaveChanges();
            // return Ok($"KİTAP EKLENDİ: {pBook.Id} / {pBook.Title}");
            return null;
        }




    }
}