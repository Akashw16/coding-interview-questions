using System.Collections.Generic;

namespace CodingInterviewQuestionsApi.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string CodeSnippet { get; set; }

        public ICollection<Bookmark> Bookmarks { get; set; }
    }
}
