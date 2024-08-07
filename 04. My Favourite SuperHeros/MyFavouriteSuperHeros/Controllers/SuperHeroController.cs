﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyfavouriteSuperHeros.Services;
using MyfavouriteSuperHeros.ViewModel;

namespace MyfavouriteSuperHeros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroService _superHeroService;

        public SuperHeroController(SuperHeroService superHeroService)
        {
            this._superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<IEnumerable<SuperHeroViewModel>> GetSuperHeros()
        {
            return await _superHeroService.GetAllSuperHeros();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroViewModel>> GetSuperHero(int id)
        {
            var result = await _superHeroService.GetOneSuperHero(id);
            if(result ==  null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHeroViewModel>> PutSuperHero(int id, SuperHeroViewModel superHeroViewModel)
        {
            var result = await _superHeroService.PutSuperHero(id, superHeroViewModel);
            if(result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<SuperHeroPostViewModel>> CreateInstructorAsync(SuperHeroPostViewModel superHeroViewModel)
        {
            return await _superHeroService.CreateSuperHero(superHeroViewModel);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            if (await _superHeroService.DeleteHeroAsync(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
