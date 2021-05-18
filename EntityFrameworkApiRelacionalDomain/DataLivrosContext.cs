using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkApiRelacional.Models
{
    public class DataLivrosContext : DbContext
    {
        public DataLivrosContext(DbContextOptions<DataLivrosContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autors { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EJP79KA;Database=Livraria;User ID=sa;Password=Paradoxo22");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasKey(a => new { a.AutorId });
        }
    }
}