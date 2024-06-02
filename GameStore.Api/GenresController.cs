//using Microsoft.AspNetCore.Mvc;
//using GameStore.Api.Data;
//using GameStore.Api.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace GameStore.Api.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class GenresController : ControllerBase
//{
//    private readonly GameStoreContext _context;

//    public GenresController(GameStoreContext context)
//    {
//        _context = context;
//    }

//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
//    {
//        return await _context.Genres.ToListAsync();
//    }

//    [HttpPost]
//    public async Task<ActionResult<Genre>> AddGenre(Genre genre)
//    {
//        _context.Genres.Add(genre);
//        await _context.SaveChangesAsync();

//        return CreatedAtAction(nameof(GetGenres), new { id = genre.Id }, genre);
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteGenre(int id)
//    {
//        var genre = await _context.Genres.FindAsync(id);
//        if (genre == null)
//        {
//            return NotFound();
//        }

//        _context.Genres.Remove(genre);
//        await _context.SaveChangesAsync();

//        return NoContent();
//    }
//}
