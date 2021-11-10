using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet.Models;
namespace dotnet.Data{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<dotnet.Models.Movie> Movie { get; set; }

        public DbSet<dotnet.Models.Student> Student { get; set; }

        public DbSet<dotnet.Models.Person> Person { get; set; }

        public DbSet<dotnet.Models.Employee> Employee { get; set; }

        public DbSet<dotnet.Models.Product> Product { get; set; }
    }
}