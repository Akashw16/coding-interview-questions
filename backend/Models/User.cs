using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingInterviewQuestionsApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }

        // Navigation property for bookmarks
        public ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>(); // Initialize to avoid null references
    }
}
