using AutoMappers_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace AutoMappers_Project.ApplicationDbContext
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<User> UserTable { get; set; }
    }
}
