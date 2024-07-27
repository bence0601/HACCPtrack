using HACCPTrack.Data;
using HACCPTrack.DTOs;
using HACCPTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace HACCPTrack.Services.RestaurantServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly DataContext _context;

        public RestaurantService(DataContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> CreateRestaurantAsync(RestaurantDTO restaurant)
        {
            try
            {
                var NewRestaurant = new Restaurant 
                { 
                    Name = restaurant.Name,
                    Address = restaurant.Address,
                    PhoneNumber = restaurant.PhoneNumber,
                    CreatedById = restaurant.CreatedById,
                    CreatedBy = await _context.Users.FirstOrDefaultAsync(u => u.Id == restaurant.CreatedById),

                };
                _context.Restaurants.Add(NewRestaurant);
                await _context.SaveChangesAsync();
                return NewRestaurant;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while creating a restaurant.", ex);
            }
        }

        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            try
            {
                return await _context.Restaurants.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while gettint all the restaurants.", ex);
            }
        }
    }
}
