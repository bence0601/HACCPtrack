using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HACCPTrack.Data;
using HACCPTrack.Models;
using HACCPTrack.Services.CheckItemServices;

namespace HACCPTrack.Services
{
    public class CheckItemService : ICheckItemService
    {
        private readonly DataContext _context;

        public CheckItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CheckItem>> GetAllItems()
        {
            try
            {
                return await _context.CheckItems.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all CheckItems.", ex);

            }
        }
    }
}
