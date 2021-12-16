using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pad3.DataAccess;

namespace Pad3.Controllers
{
    [ApiController]
    [Route("api/fly")]
    public class FlyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlyController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Fly>> Get(CancellationToken cancellationToken = default)
        {

            return await _context.Flies.ToListAsync(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<Fly> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Flies.FirstOrDefaultAsync(fly => fly.Id == id, cancellationToken);

        }

        [HttpPost]
        public async Task<Fly> Create([FromBody] Fly fly, CancellationToken cancellationToken = default)
        {
            _context.Flies.Add(fly);
            await _context.SaveChangesAsync(cancellationToken);

            return fly;

        }

        [HttpPut]
        public async Task<Fly> Update([FromBody] Fly fly, CancellationToken cancellationToken = default)
        {
            _context.Flies.Update(fly); 
            await _context.SaveChangesAsync(cancellationToken);

            return fly;

        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(int id, CancellationToken cancellationToken = default)
        {
            var fly = await _context.Flies.FirstOrDefaultAsync(fly => fly.Id == id, cancellationToken);
            _context.Flies.Remove(fly!);
            await _context.SaveChangesAsync(cancellationToken);

            return id;
        }
    }
}
