using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{

    public class BooksVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public eBookGenre GenreId { get; set; }
        public int PageCount { get; set; }
        public int PublishStore { get; set; }
        public string PublishDate { get; set; }
    }
    
}