namespace CodingInterviewQuestionsApi.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string CodeSnippet { get; set; }

        public bool IsBookmarked { get; set; }
    }
}
