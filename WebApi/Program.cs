using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

using WebApi.Data;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            //2. Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;   //3. Get the instance of BoardGamesDBContext in our services layer
                Data.BookStore.CRUD.DataGenerator.Initialize(services); //4. Call the DataGenerator to create sample data

                // LinqPractices.DataGenerator.Initialize(); //4. Call the DataGenerator to create sample data
                // LinqPractices.LinqDbContext linqDbContext = new LinqPractices.LinqDbContext();
                // var Students= linqDbContext.Students.ToList();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });


    }
}
