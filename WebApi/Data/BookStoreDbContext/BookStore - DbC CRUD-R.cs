using System.ComponentModel;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Data.BookStore;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebApi.Data.BookStore.CRUD
{

    public class BookStore_CRUD_R
    {
        public BookStoreDbContext dbContext { get; }
        private IMapper _mapper;

        public BookStore_CRUD_R(BookStoreDbContext pDbContext, IMapper mapper) { dbContext = pDbContext; _mapper = mapper; }

        public List<BooksVM> Handle()
        {
            var BookList = dbContext.Books.OrderBy(o => o.Id).ToList();
            if (!BookList.Any()) { throw new InvalidOperationException("KAYIT YOK !"); }

            return _mapper.Map<List<BooksVM>>(BookList);
            // var vm = new List<BooksVM>();
            // foreach (var book in BookList)
            // {
            //     vm.Add(new BooksVM()
            //     {
            //         Id          = book.Id,
            //         Title       = book.Title,
            //         GenreId     = book.GenreId,
            //         Genre       = ((eBookGenre)book.GenreId).ToString(),
            //         PublishDate = book.PublishDate.ToString("yyyy-MM-dd HH:mm:ss"),
            //         PageCount   = book.PageCount
            // 
            //     });
            // }
            // return vm;
        }



        //[HttpGet] public List<Book> GetBooks() { var bl = BookList.OrderBy(o => o.Id).ToList<Book>(); return bl; }
        [HttpGet]
        public List<Book> Get_List() { var bl = dbContext.Books.OrderBy(o => o.Id).ToList<Book>(); return bl; }

        // [HttpGet] [Route("{Id}")] */         public Book GetBy_Id(int pId) { var r = _context.Books.Where(s => s.Id == pId).SingleOrDefault(); return r; }
        [HttpGet("{pId}")]
        public Book GetBy_Id(int pId) { var r = dbContext.Books.Where(s => s.Id == pId).SingleOrDefault(); return r; }
        [HttpGet]
        [Route("{pId2}")]
        public Book GetBy_Id2(int pId2) { var r = dbContext.Books.Where(s => s.Id == pId2).SingleOrDefault(); return r; }
        // [HttpGet]                               public Book Get   ([FromQuery] string Id3) { var r = _context.Books.Where(s => s.Id == Convert.ToInt32(Id3) ).SingleOrDefault(); return r; }


    }





}