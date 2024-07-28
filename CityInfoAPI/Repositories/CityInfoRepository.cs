﻿using CityInfoAPI.DbContexts;
using CityInfoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPI.Repositories
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoDbContext _context;
        public CityInfoRepository(CityInfoDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<bool> CityExistsAsync(int cityId)
        {
            return await _context.Cities.AnyAsync(c=>c.Id == cityId);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }



        public async Task<City?> GetCityAsync(int cityId, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return await _context.Cities.Include(c => c.PointOfInterest).Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }

            return await _context.Cities.Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }



        public async Task<PointOfInterest?> GetPointOfInterestsForCityAsync(int cityId, int pointOfInterestId)
        {
            return await _context.PointOfInterest.Where(p => p.CityId == cityId && p.Id == pointOfInterestId)
                .FirstOrDefaultAsync();
        }



        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestsForCityAsync(int cityId)
        {
            return await _context.PointOfInterest.Where(p => p.CityId == cityId).ToListAsync();
        }
    }
}
