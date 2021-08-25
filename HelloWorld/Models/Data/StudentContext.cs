using HelloWorld.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Models.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>options):base(options)
        {
            
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}