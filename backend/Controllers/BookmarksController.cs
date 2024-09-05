using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using CodingInterviewQuestionsApi.Data;
using CodingInterviewQuestionsApi.Models;
using CodingInterviewQuestionsApi.DTOs;
using System.Threading.Tasks;
using System;

namespace CodingInterviewQuestionsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookmarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Explicitly specify the DTO namespace for BookmarkRequest
        [HttpPost("add")]
        public async Task<IActionResult> AddBookmark([FromBody] CodingInterviewQuestionsApi.DTOs.BookmarkRequest request)  // Explicitly use DTO namespace
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized(new { Success = false, Message = "User ID not found in the token." });
                }

                var userId = int.Parse(userIdClaim);

                var existingBookmark = await _context.Bookmarks
                    .FirstOrDefaultAsync(b => b.UserId == userId && b.QuestionId == request.QuestionId);

                if (existingBookmark != null)
                {
                    return BadRequest(new { Success = false, Message = "Bookmark already exists." });
                }

                var bookmark = new Bookmark
                {
                    UserId = userId,
                    QuestionId = request.QuestionId
                };

                _context.Bookmarks.Add(bookmark);
                await _context.SaveChangesAsync();

                return Ok(new { Success = true, Message = "Bookmark added successfully." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddBookmark: {ex.Message}");
                return StatusCode(500, new { Success = false, Message = "An error occurred while adding the bookmark." });
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveBookmark([FromBody] CodingInterviewQuestionsApi.DTOs.BookmarkRequest request)  // Explicitly use DTO namespace
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized(new { Success = false, Message = "User ID not found in the token." });
                }

                var userId = int.Parse(userIdClaim);

                var bookmark = await _context.Bookmarks
                    .FirstOrDefaultAsync(b => b.UserId == userId && b.QuestionId == request.QuestionId);

                if (bookmark == null)
                {
                    return NotFound(new { Success = false, Message = "Bookmark not found." });
                }

                _context.Bookmarks.Remove(bookmark);
                await _context.SaveChangesAsync();

                return Ok(new { Success = true, Message = "Bookmark removed successfully." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RemoveBookmark: {ex.Message}");
                return StatusCode(500, new { Success = false, Message = "An error occurred while removing the bookmark." });
            }
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserBookmarks()
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return Unauthorized(new { Success = false, Message = "User ID not found in the token." });
                }

                var userId = int.Parse(userIdClaim);

                var bookmarks = await _context.Bookmarks
                    .Where(b => b.UserId == userId)
                    .Select(b => new
                    {
                        b.QuestionId,
                        b.Question.QuestionText,
                        b.Question.CodeSnippet
                    })
                    .ToListAsync();

                return Ok(bookmarks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserBookmarks: {ex.Message}");
                return StatusCode(500, new { Success = false, Message = "An error occurred while retrieving bookmarks." });
            }
        }
    }
}
