using Library.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Data;

public class LibraryDBContext : DbContext
{
    public DbSet<Models.Entities.Library> Libraries { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookDetails> BookDetails { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=LibraryDB;User Id=sa;Password=password;TrustServerCertificate=True");
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    // }
}