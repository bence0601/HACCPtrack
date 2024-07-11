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

        public async Task<List<CheckItem>> AddCheckItemWithCheckboxAsync(CheckItemWithCheckbox checkItem)
        {
            try
            {
                _context.CheckItems.Add(checkItem);
                await _context.SaveChangesAsync();
                return await _context.CheckItems.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating a note.", ex);

            }

        }

        public async Task<List<CheckItem>> AddCheckItemWithInputFieldAsync(CheckItemWithInputField checkItem)
        {
            try
            {
                _context.CheckItems.Add(checkItem);
                await _context.SaveChangesAsync();
                return await _context.CheckItems.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating a note.", ex);
            }
        }

        public Task<List<CheckItem>> GetAllItemsAsync()
        {
            return _context.CheckItems.ToListAsync();
        }
    }
}
