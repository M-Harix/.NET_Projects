using Microsoft.EntityFrameworkCore;
using System.Collections;
using MyfavouriteSuperHeros.Data;
using MyfavouriteSuperHeros.Data.Model;
using MyfavouriteSuperHeros.ViewModel;

namespace MyfavouriteSuperHeros.Services
{
    public class SuperHeroService
    {
        private DBContext _DBContext { get; set; }
        public SuperHeroService(DBContext DBContext) 
        {
            this._DBContext = DBContext;
        }
        public async Task<IEnumerable<SuperHeroViewModel>> GetAllSuperHeros()
        {
            var result = await _DBContext.SuperHero.ToListAsync();
            return result.Select(x => new SuperHeroViewModel() { Id = x.Id, Name = x.Name, FirstName = x.FirstName, LastName = x.LastName, Place = x.Place });
        }
        public async Task<SuperHeroViewModel> GetOneSuperHero(int id)
        {
            var result = await _DBContext.SuperHero.FindAsync(id);
            if(result == null)
            {
                return null;
            }
            else
            {
                var r = new SuperHeroViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Place = result.Place
                };
                return r;
            }
        }
        
        public async Task<bool> PutSuperHero(int id, SuperHeroViewModel superHeroViewModel)
        {
            var r = new SuperHero
            {
                Id = superHeroViewModel.Id,
                Name = superHeroViewModel.Name,
                FirstName = superHeroViewModel.FirstName,
                LastName = superHeroViewModel.LastName,
                Place = superHeroViewModel.Place
            };

            if (id != superHeroViewModel.Id)
            {
                return false;
            }

            _DBContext.Entry(r).State = EntityState.Modified;

            try
            {
                await _DBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }
        
        private bool HeroExists(int id)
        {
            return _DBContext.SuperHero.Any(e => e.Id == id);
        }

        public async Task<SuperHeroPostViewModel> CreateSuperHero(SuperHeroPostViewModel superHeroViewModel)
        {
            SuperHero cvm = new SuperHero
            {
                Name = superHeroViewModel.Name,
                FirstName = superHeroViewModel.FirstName,
                LastName = superHeroViewModel.LastName,
                Place = superHeroViewModel.Place
            };
            _DBContext.SuperHero.Add(cvm);
            await _DBContext.SaveChangesAsync();
            return superHeroViewModel;
        }

        public async Task<bool> DeleteHeroAsync(int id)
        {
            var result = await _DBContext.SuperHero.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            _DBContext.SuperHero.Remove(result);
            await _DBContext.SaveChangesAsync();
            return true;
        }
    }
}
