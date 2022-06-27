using System.Linq;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace LinqPractices
{
    public class LinqDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseInMemoryDatabase(databaseName: "LinqDatabase"); }


    }


    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var cnt = new LinqDbContext())
            {
                if (cnt.Students.Any()) { return; }

                cnt.Students.AddRange(
                    new Student() { Name = "Ayşe", SurName = "Yılmaz", ClassId = 1 },
                    new Student() { Name = "Deniz", SurName = "Arda", ClassId = 1 },
                    new Student() { Name = "Umut", SurName = "Arda", ClassId = 2 },
                    new Student() { Name = "Merve", SurName = "Çalışkan", ClassId = 2 }
                );
                cnt.SaveChanges();
            }
        }
    }

}
