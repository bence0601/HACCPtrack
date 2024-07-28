using HACCPTrack.DTOs;
using HACCPTrack.Models;

namespace HACCPTrack.Services.LogServices
{
    public interface ILogService
    {
        public Task<List<Log>> GetAllLogs();
        public Task<Log> CreateLogsAsync(LogDTO log);
        public Task<Log> GetLogByIdAsync(string id);
    }
}
