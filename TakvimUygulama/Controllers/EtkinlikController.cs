// Bu satırda sadece TakvimUygulama.Data'yı kullandığımıza emin ol
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakvimUygulama.Data;
using System.ComponentModel.DataAnnotations;
// İlgili yerlerde Etkinlik kullanımını şu şekilde tam olarak belirtelim.
namespace TakvimUygulama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtkinlikController : ControllerBase
    {
        private readonly UygulamaContext _context;

        public EtkinlikController(UygulamaContext context)
        {
            _context = context;
        }

        // GET: api/Etkinlik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TakvimUygulama.Data.Etkinlik>>> GetEtkinlikler()  // tam kullanım
        {
            try
            {
                var etkinlikler = await _context.Etkinlikler.ToListAsync();
                if (etkinlikler == null || !etkinlikler.Any())
                {
                    return NoContent();
                }
                return Ok(etkinlikler);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Etkinlik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TakvimUygulama.Data.Etkinlik>> GetEtkinlik(int id)  // tam kullanım
        {
            try
            {
                var etkinlik = await _context.Etkinlikler.FindAsync(id);

                if (etkinlik == null)
                {
                    return NotFound();
                }

                return Ok(etkinlik);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Etkinlik
        [HttpPost]
        public async Task<ActionResult<TakvimUygulama.Data.Etkinlik>> PostEtkinlik([FromBody] TakvimUygulama.Data.Etkinlik etkinlik)  // tam kullanım
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Geçersiz model verisi.");
                }

                _context.Etkinlikler.Add(etkinlik);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEtkinlik), new { id = etkinlik.Id }, etkinlik);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Etkinlik/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtkinlik(int id, [FromBody] TakvimUygulama.Data.Etkinlik etkinlik)
{
            try
    {
                if (id != etkinlik.Id)
        {
            return BadRequest("Etkinlik ID'si uyuşmuyor.");
        }

                if (!ModelState.IsValid)
        {
            return BadRequest("Geçersiz model verisi.");
        }

        _context.Entry(etkinlik).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!_context.Etkinlikler.Any(e => e.Id == id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}



        // DELETE: api/Etkinlik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtkinlik(int id)
        {
            try
            {
                var etkinlik = await _context.Etkinlikler.FindAsync(id);
                if (etkinlik == null)
                {
                    return NotFound();
                }

                _context.Etkinlikler.Remove(etkinlik);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
