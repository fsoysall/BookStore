using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace LinqPractices
{

    public class Student
    {
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }
        public int StudentId { get => Id ; set => Id=value; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int ClassId { get; set; }
    }

    public enum GenreEnum
    {
        PersonalGrowth,
        ScienceFiction
    }

}