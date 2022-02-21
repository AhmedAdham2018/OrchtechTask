using Microsoft.EntityFrameworkCore;
using DataAccess.Models;


namespace DataAccess.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<StudentClass> StudentClasses { get; set; } = null!;
    }
}
