using Microsoft.AspNetCore.Mvc;
using CodingInterviewQuestionsApi.Data;
using CodingInterviewQuestionsApi.Models;
using Microsoft.AspNetCore.Authorization;  // Add this directive
using Microsoft.EntityFrameworkCore;

namespace CodingInterviewQuestionsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllQuestions()
        {
            var questions = _context.Questions
                                    .Include(q => q.Bookmarks)
                                    .Select(q => new
                                    {
                                        q.Id,
                                        q.QuestionText,
                                        q.CodeSnippet
                                    })
                                    .ToList();

            return Ok(questions);
        }
    }
}
