using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  	[Route("api/[controller]")]
	[ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext context;
        public UserController(AppDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUserList()
        {
            return Ok(await context.AppUsers.ToListAsync());
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserByUserId(int id)
        {
            return Ok(await context.AppUsers.FirstOrDefaultAsync(o => o.Id == id));
        }
    }
}