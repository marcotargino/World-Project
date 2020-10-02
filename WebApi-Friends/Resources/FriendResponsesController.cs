using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Friends.Data;
using WebApi_Friends.Resources.FriendResource;

namespace WebApi_Friends.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendResponsesController : ControllerBase
    {
        private readonly WebApi_FriendsContext _context;

        public FriendResponsesController(WebApi_FriendsContext context)
        {
            _context = context;
        }

        // GET: api/FriendResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFriendResponse()
        {
            return await _context.Friends.ToListAsync();
        }

        // GET: api/FriendResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Friend>> GetFriendResponse(Guid id)
        {
            var friendResponse = await _context.Friends.FindAsync(id);

            if (friendResponse == null)
            {
                return NotFound();
            }

            return friendResponse;
        }

        // PUT: api/FriendResponses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriendResponse(Guid id, FriendResponse friendResponse)
        {
            if (id != friendResponse.Id)
            {
                return BadRequest();
            }

            _context.Entry(friendResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendResponseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FriendResponses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Friend>> PostFriendResponse(Friend friendResponse)
        {
            _context.Friends.Add(friendResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriendResponse", new { id = friendResponse.Id }, friendResponse);
        }

        // DELETE: api/FriendResponses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Friend>> DeleteFriendResponse(Guid id)
        {
            var friendResponse = await _context.Friends.FindAsync(id);
            if (friendResponse == null)
            {
                return NotFound();
            }

            _context.Friends.Remove(friendResponse);
            await _context.SaveChangesAsync();

            return friendResponse;
        }

        private bool FriendResponseExists(Guid id)
        {
            return _context.Friends.Any(e => e.Id == id);
        }
    }
}
