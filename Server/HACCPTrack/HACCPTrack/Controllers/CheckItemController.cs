using HACCPTrack.DTOs;
using HACCPTrack.Models;
using HACCPTrack.Services;
using HACCPTrack.Services.CheckItemServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HACCPTrack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckItemController : ControllerBase
    {
        private readonly ICheckItemService _checkItemService;

        public CheckItemController(ICheckItemService checkItemService)
        {
            _checkItemService = checkItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckItem>>> GetCheckItems()
        {
            var checkItems = await _checkItemService.GetAllCheckItemsAsync();
            return Ok(checkItems);
        }

        [HttpPost]
        public async Task<ActionResult<CheckItem>> CreateCheckItem(CheckItemDTO checkItem)
        {
            var createdCheckItem = await _checkItemService.CreateCheckItemAsync(checkItem);
            return CreatedAtAction(nameof(GetCheckItems), new { id = createdCheckItem.Id }, createdCheckItem);
        }

        [HttpGet("GetCheckItemById")]
        public async Task<ActionResult<CheckItem>> GetCheckItemById(string id)
        {
            var checkItem = await _checkItemService.GetCheckListByIdAsync(id);
            return Ok(checkItem); 

        }
    }
}
