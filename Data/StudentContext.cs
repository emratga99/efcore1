using Microsoft.EntityFrameworkCore;
using efcore2.Model;

namespace efcore2.Data;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options)
    : base(options) { }
    public DbSet<Student> Students { get; set; } = null!;
}