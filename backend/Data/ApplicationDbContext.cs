using Microsoft.EntityFrameworkCore;

using CodingInterviewQuestionsApi.Models;
namespace CodingInterviewQuestionsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       public DbSet<User> Users { get; set; }
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User-Bookmark relationship
            modelBuilder.Entity<Bookmark>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookmarks)
                .HasForeignKey(b => b.UserId);

            // Configure Question-Bookmark relationship
            modelBuilder.Entity<Bookmark>()
                .HasOne(b => b.Question)
                .WithMany(q => q.Bookmarks)
                .HasForeignKey(b => b.QuestionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
