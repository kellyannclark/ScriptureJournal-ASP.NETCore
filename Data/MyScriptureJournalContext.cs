using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Data
{
    public class MyScriptureJournalContext : DbContext
    {
        public MyScriptureJournalContext(DbContextOptions<MyScriptureJournalContext> options)
            : base(options)
        {
        }

        public DbSet<Scripture> Scriptures { get; set; }
        
    }
}
