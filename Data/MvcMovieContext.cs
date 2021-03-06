using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet.Models;
namespace dotnet.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<Student> Student { get; set; }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<NhanVien> NhanVien { get; set; }
    }
}