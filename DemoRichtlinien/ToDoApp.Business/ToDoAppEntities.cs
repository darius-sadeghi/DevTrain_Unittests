using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business.Models;

namespace ToDoApp.Business
{
    public class ToDoAppEntities:DbContext
    {

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }


        public ToDoAppEntities()
        {
        }

        public ToDoAppEntities(DbContextOptions<ToDoAppEntities> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToDoAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }

        }

        

    }
}
