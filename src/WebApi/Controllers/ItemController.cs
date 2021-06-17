using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Itefaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repo;
        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostItemAsync(Item item)
        {
            var post = await _repo.PostItemAsync(item);
            if(!post)
                return BadRequest();
            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemAsync(Guid id)
        {
            var item = await _repo.GetItemAsync(id);

            if(item == null) 
                return BadRequest();
            return Ok(item);
        }
    }
}