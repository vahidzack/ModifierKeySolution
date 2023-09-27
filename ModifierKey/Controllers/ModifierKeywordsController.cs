using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModifierKey.Context;
using ModifierKey.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ModifierKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModifierKeywordsController : ControllerBase
    {

        #region Constractor
        private readonly AppDbContext _context;

        public ModifierKeywordsController(AppDbContext context)
        {
            _context = context;
        }
        #endregion


        #region GetAllModifier

        [HttpGet("[action]")]
        public async Task<IActionResult> GetModifierKeywords()
        {
            var Key = await _context.ModifierKeywords.ToListAsync();
            return Ok(Key);
        }
        #endregion

        #region CreateModifier
        [HttpPost("[action]")]

        public async Task<IActionResult> CreateModifierKeyword(ModifierKeyword Keyword)
        {
            _context.ModifierKeywords.Add(Keyword);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetModifierKeywords), new { id = Keyword.Id }, Keyword);
        }
        #endregion

        #region EditModifier
        [HttpPut("[action]")]
        public async Task<IActionResult> EditModifierKeyword(int id, [FromBody] ModifierKeyword updatedKeyword)
        {
           
            var existingKeyword = await _context.ModifierKeywords.FindAsync(id);

            if (existingKeyword == null)
            {
                return NotFound("Modifier keyword not found.");
            }

           
            existingKeyword.Name = updatedKeyword.Name;
            existingKeyword.Description = updatedKeyword.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception if necessary
                throw;
            }

            return Ok("The Modifier is Edited");
        }



        #endregion

        #region DeleteModifier
        [HttpDelete("[action]")]

    public async Task<IActionResult> DeleteModifierKeyword(int id)
    {
        var key = await _context.ModifierKeywords.FindAsync(id);
        if (key == null)
        {
            return BadRequest();
        }
        _context.ModifierKeywords.Remove(key);
        await _context.SaveChangesAsync();
        return Ok("The Modifier Is Deleted");
    }

    #endregion



}

}

