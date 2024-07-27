using HACCPTrack.DTOs;
using HACCPTrack.Models;
using HACCPTrack.Services.LogServices;
using Microsoft.AspNetCore.Mvc;

namespace HACCPTrack.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class LogController : ControllerBase
        {
            private readonly ILogService _logservice;

            public LogController(ILogService logService)
            {
                _logservice = logService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Log>>> GetLogs()
            {
                var checkItems = await _logservice.GetAllLogs();
                return Ok(checkItems);
            }

            [HttpPost]
            public async Task<ActionResult<CheckItem>> CreateLog(LogDTO log)
            {
                var createdLog = await _logservice.CreateLogsAsync(log);
                return CreatedAtAction(nameof(GetLogs), new { id = createdLog.Id }, createdLog);
            }
        }
}

