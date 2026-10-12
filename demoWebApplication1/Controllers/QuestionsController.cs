
using demoWebApplication1.Data;
using demoWebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demoWebApplication1.Controllers
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

        // GET: api/questions?subject=Java
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(
            [FromQuery] string? subject)
        {
            IQueryable<Question> query = _context.Questions;

            if (!string.IsNullOrWhiteSpace(subject))
            {
                query = query.Where(q => q.Subject == subject);
            }

            return Ok(await query.ToListAsync());
        }

        // GET: api/questions/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // POST: api/questions
        [HttpPost]
        public async Task<ActionResult<Question>> CreateQuestion(
            Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetQuestion),
                new { id = question.Id },
                question);
        }

        // PUT: api/questions/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(
            int id, Question updatedQuestion)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            question.Text = updatedQuestion.Text;
            question.Subject = updatedQuestion.Subject;
            question.OptionA = updatedQuestion.OptionA;
            question.OptionB = updatedQuestion.OptionB;
            question.OptionC = updatedQuestion.OptionC;
            question.OptionD = updatedQuestion.OptionD;
            question.CorrectOption = updatedQuestion.CorrectOption;

            await _context.SaveChangesAsync();

            return Ok(question);
        }

        // DELETE: api/questions/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
