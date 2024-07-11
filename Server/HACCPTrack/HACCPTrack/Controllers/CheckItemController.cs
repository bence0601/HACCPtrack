using HACCPTrack.Models;
using HACCPTrack.Services.CheckItemServices;
using Microsoft.AspNetCore.Mvc;

namespace HACCPTrack.Controllers
{
    public class CheckItemController : Controller
    {
            private readonly ICheckItemService _checkItemService;
        
        public CheckItemController(ICheckItemService checkItemService)
        {
            _checkItemService = checkItemService;
        }

        [HttpGet("GetAllCheckItems")]
        public async Task<ActionResult<List<CheckItem>>> GetCheckItems()
        {
            try
            {
                var result = await _checkItemService.GetAllItemsAsync();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddCheckItemWithCheckBox")]
        public async Task<ActionResult<List<CheckItem>>> AddCheckItemWithCheckBox(CheckItemWithCheckbox checkItem)
        {
            try
            {
                var result = await _checkItemService.AddCheckItemWithCheckboxAsync(checkItem);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the note: {ex.Message}");

            }
        }
        [HttpPost("AddCheckItemWithInputField")]
        public async Task<ActionResult<List<CheckItem>>> AddCheckItemWithInputField(CheckItemWithInputField checkItem)
        {
            try
            {
                var result = await _checkItemService.AddCheckItemWithInputFieldAsync(checkItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the note: {ex.Message}");

            }
        }
    }
}
