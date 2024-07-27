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

        public async Task<Log> CreateLogsAsync(LogDTO log)
        {

            try
            {
                var NewLog = new Log
                {
                    RestaurantId = log.RestaurantId,
                    Restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == log.RestaurantId),
                    CreatedByUserId = log.CreatedByUserId,
                    ExpiryDate = log.ExpiryDate,
                    RegenerationIntervalHours = log.RegenerationIntervalHours,
                };
                _context.Logs.Add(NewLog);
                await _context.SaveChangesAsync();
                return NewLog;
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
