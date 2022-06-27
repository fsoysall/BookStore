using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApi.Data
{

    public class Book
    {
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }
        public string Title { get; set; }
        public eBookGenre GenreId { get; set; }
        public int PageCount { get; set; }
        public int PublishStore { get; set; }
        public DateTime PublishDate { get; set; }
    }
 
}