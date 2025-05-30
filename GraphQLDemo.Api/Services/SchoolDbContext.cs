using GraphQLDemo.Api.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Api.Services;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options) { }

    public DbSet<CourseDTO> Courses { get; set; }
    public DbSet<InstructorDTO> Instructors { get; set; }
    public DbSet<StudentDTO> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InstructorDTO>().HasData(
            new InstructorDTO()
            {
                Id = new Guid("5ed6729c-6d82-428e-809a-0fe47cf48168"),
                FirstName = "SomeInstructorFirstname",
                LastName = "SomeInstructorLastname",
                Salary = 1.20
            }
            );
        base.OnModelCreating(modelBuilder);
    }
}