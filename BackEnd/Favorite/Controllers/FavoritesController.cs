using Favorite.Models;
using Favorite.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Favorite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoriteService _favoriteService;
        public FavoritesController(FavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _favoriteService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _favoriteService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Favorites favorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _favoriteService.CreateAsync(favorite);
            return Ok(favorite.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Favorites favorite)
        {
            var customer = await _favoriteService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _favoriteService.UpdateAsync(id, favorite);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _favoriteService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _favoriteService.DeleteAsync(customer.Id);
            return NoContent();
        }
    }
}
