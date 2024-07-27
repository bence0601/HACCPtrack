using HACCPTrack.Data;
using HACCPTrack.DTOs;
using HACCPTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace HACCPTrack.Services.LogServices
{
    public class LogService : ILogService
    {
        private readonly DataContext _context;

        public LogService(DataContext context)
        {
            _context = context;
        }

        public async Task<Log> CreateLogsAsync(Log log)
        {
            try
            {
                _context.Logs.Add(log);
                await _context.SaveChangesAsync();
                return log;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while creating a Log.", ex);
            }
        }

        public async Task<List<Log>> GetAllLogs()
        {
            return await _context.Logs.ToListAsync();
        }

    }
}
