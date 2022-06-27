using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Data.BookStore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.BookStore.CRUD
{

    public class BookStore_CRUD_U : DbContext
    {

        public new Book Model { get; set; }
        public BookStoreDbContext DbContext { get; }
        public BookStore_CRUD_U(BookStoreDbContext pDbContext) { DbContext = pDbContext; }

        public int Handle( Book newBook)
        {
            var book = DbContext.Books.SingleOrDefault(s => s.Id == newBook.Id);
            if (book is  null) { throw new InvalidOperationException("Güncellenecek Kitap BULUNAMADI !"); }
            //book              = new Book();
            book.Title        = newBook.Title;
            book.GenreId      = newBook.GenreId;
            book.PageCount    = newBook.PageCount;
            book.PublishStore = newBook.PublishStore;
            //book.PublishDate  = newBook.PublishDate;

            DbContext.SaveChanges();
            return book.Id;

    }



 



    }
}