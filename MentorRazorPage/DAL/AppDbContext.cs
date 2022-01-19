using MentorRazorPage.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorRazorPage.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }
        public DbSet<Trainer> Trainers { get; set; }
    }
}
