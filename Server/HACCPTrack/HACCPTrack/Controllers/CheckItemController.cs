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
                var result = await _checkItemService.GetAllItems();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
