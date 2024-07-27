using HACCPTrack.DTOs;
using HACCPTrack.Models;

namespace HACCPTrack.Services.RestaurantServices
{
    public interface IRestaurantService
    {
        public Task<List<Restaurant>> GetAllRestaurantsAsync();
        public Task<Restaurant> CreateRestaurantAsync(RestaurantDTO restaurant);
    }
}
