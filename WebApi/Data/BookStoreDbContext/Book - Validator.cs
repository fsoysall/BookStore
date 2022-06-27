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

namespace WebApi.Data.BookStore
{

    public class Book_Validator : AbstractValidator<Book>
    {

        public Book_Validator()
        {
            RuleFor(c => c.Title).NotNull().MinimumLength(2);
            RuleFor(c => c.Title).NotNull();
            RuleFor(c => c.PageCount).GreaterThanOrEqualTo(0);
            RuleFor(c => ((int)c.GenreId)).GreaterThan(0);
        }




    }

}