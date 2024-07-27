using HACCPTrack.DTOs;
using HACCPTrack.Models;

namespace HACCPTrack.Services.RestaurantServices
{
    public interface IRestaurantService
    {
        public Task<List<Restaurant>> GetAllRestaurantsAsync();
        public Task<Restaurant> CreateRestaurantAsync(RestaurantDTO restaurant);
        public Task<List<Restaurant>> DeleteRestaurantByIdAsync(string id);
        public Task<Restaurant> GetRestaurantByIdAsync(string id);
        public Task<Restaurant> UpdateRestaurantAsync(string id, RestaurantDTO updatedRestaurant);
    }
}
