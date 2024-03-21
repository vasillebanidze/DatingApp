using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UserController : BaseApiController
    {

        private readonly AppDbContext context;
        public UserController(AppDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUserList()
        {
            return Ok(await context.AppUsers.ToListAsync());
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AppUser>> GetUserByUserId(int id)
        {
            return Ok(await context.AppUsers.FirstOrDefaultAsync(o => o.Id == id));
        }
    }
}