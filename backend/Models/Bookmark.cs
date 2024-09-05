namespace CodingInterviewQuestionsApi.Models
{
    public class Bookmark
    {
        public int Id { get; set; }
        
        // Foreign key to Question
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        
        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
