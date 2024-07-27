using HACCPTrack.DTOs;
using HACCPTrack.Models;
using HACCPTrack.Services.CheckItemServices;
using HACCPTrack.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc;

namespace HACCPTrack.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class RestaurantController : ControllerBase
        {
            private readonly IRestaurantService _restaurantService;

            public RestaurantController(IRestaurantService restaurantService)
            {
                _restaurantService = restaurantService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
            {
                var restaurants = await _restaurantService.GetAllRestaurantsAsync();
                return Ok(restaurants);
            }

            [HttpPost]
            public async Task<ActionResult<Restaurant>> CreateRestaurant(RestaurantDTO restaurant)
            {
                var createdRestaurant = await _restaurantService.CreateRestaurantAsync(restaurant);
                return CreatedAtAction(nameof(GetRestaurants), new { id = createdRestaurant.Id }, createdRestaurant);
            }
        }
}

