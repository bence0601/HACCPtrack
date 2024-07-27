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

        //Étterem létrehozása
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




        //Étterem törlése
        public async Task<List<Restaurant>> DeleteRestaurantByIdAsync(string id)
        {
            try
            {
                var restaurantToDelete = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);

                if (restaurantToDelete == null)
                {
                    throw new Exception("Restaurant not found.");
                }

                _context.Restaurants.Remove(restaurantToDelete);
                await _context.SaveChangesAsync();

                return await _context.Restaurants.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting a restaurant.", ex);
            }
        }




        //Összes étterem lekérdezése
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




        //Étterem lekérdezése ID alapján
        public async Task<Restaurant> GetRestaurantByIdAsync(string id)
        {
            try
            {
                return await _context.Restaurants.FirstAsync(r => r.Id == id);

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while getting info of the restaurant.", ex);
            }
        }

        //Étterem frissítése
        public async Task<Restaurant> UpdateRestaurantAsync(string id, RestaurantDTO updatedRestaurant)
        {
            try
            {
                var existingRestaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);

                if (existingRestaurant == null)
                {
                    throw new Exception("Restaurant not found.");
                }

                existingRestaurant.Name = updatedRestaurant.Name;
                existingRestaurant.Address = updatedRestaurant.Address;
                existingRestaurant.PhoneNumber = updatedRestaurant.PhoneNumber;
                existingRestaurant.CreatedById = updatedRestaurant.CreatedById;
                existingRestaurant.CreatedBy = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedRestaurant.CreatedById);

                _context.Restaurants.Update(existingRestaurant);
                await _context.SaveChangesAsync();

                return existingRestaurant;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating a restaurant.", ex);
            }
        }






    }
}
