using Event_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Event_Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
