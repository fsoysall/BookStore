using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Data.BookStore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.BookStore.CRUD
{

    public class BookStore_CRUD_D : DbContext
    {

        // public new Book Model { get; set; }
        public BookStoreDbContext DbContext { get; }
        public BookStore_CRUD_D(BookStoreDbContext pDbContext) { DbContext = pDbContext; }

        public int Handle( int pId)
        {
            var book = DbContext.Books.SingleOrDefault(s => s.Id == pId);
            if (book is null) { throw new KeyNotFoundException("Kitap Bilgisi BULUNAMADI !"); }

            DbContext.Books.Remove(book);
            DbContext.SaveChanges();
            return book.Id;
    }






    }
}