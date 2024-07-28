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
                var checkLogs = await _logservice.GetAllLogs();
                return Ok(checkLogs);
            }

            [HttpPost]
            public async Task<ActionResult<CheckItem>> CreateLog(LogDTO log)
            {
                var createdLog = await _logservice.CreateLogsAsync(log);
                return CreatedAtAction(nameof(GetLogs), new { id = createdLog.Id }, createdLog);
            }
        [HttpGet("GetLogById")]
        public async Task<ActionResult<CheckItem>> GetLogById(string id)
        {
            var checkLog = await _logservice.GetLogByIdAsync(id);
            return Ok(checkLog);
        }
        }
}

