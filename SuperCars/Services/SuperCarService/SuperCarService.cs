using Microsoft.EntityFrameworkCore;
using SuperCarAPI.Data;
using SuperCarAPI.Models;

namespace SuperCarAPI.Services.SuperCarService
{
    public class SuperCarService : ISuperCarService
    {
        private readonly DataContext _context;
        public SuperCarService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<SuperCar>> AddCar(SuperCar hero)
        {
            _context.SuperCars.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperCars.ToListAsync();
        }

        public async Task<List<SuperCar>>? DeleteCar(int id)
        {
            var hero = await _context.SuperCars.FindAsync(id);
            if (hero is null)
                return null;

            _context.SuperCars.Remove(hero);
            await _context.SaveChangesAsync();

            return _context.SuperCars.ToList();
        }

        public async Task<SuperCar>? GetOneCar(int id)
        {
            var hero = await _context.SuperCars.FindAsync(id);
            if (hero is null)
                return null;
            return hero;
        }

        public async Task<List<SuperCar>>? UpdateCar(int id, SuperCar request)
        {
            var hero = await _context.SuperCars.FindAsync(id);
            if (hero is null)
                return null;

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperCars.ToListAsync();
        }
        public async Task<List<SuperCar>> GetAllCars()
        {
            var heroes = await _context.SuperCars.ToListAsync();
            return heroes;
        }
    }
}
