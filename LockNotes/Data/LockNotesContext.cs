using Microsoft.EntityFrameworkCore;
using LockNotes.Models;

namespace LockNotes.Data
{
    public class LockNotesContext : DbContext
    {
        public LockNotesContext(DbContextOptions<LockNotesContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
