using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HACCPTrack.Data;
using HACCPTrack.Models;
using HACCPTrack.Services.CheckItemServices;
using HACCPTrack.DTOs;

namespace HACCPTrack.Services
{
    public class CheckItemService : ICheckItemService
    {
        private readonly DataContext _context;

        public CheckItemService (DataContext context)
        {
            _context = context;
        }
        public async Task<List<CheckItem>> GetAllCheckItemsAsync()
        {
            return await _context.CheckItems.ToListAsync();
        }
        public async Task<CheckItem> CreateCheckItemAsync(CheckItemDTO checkItem)
        {
            var NewCheckItem = new CheckItem
            {
                LogId = checkItem.LogId,
                Log = await _context.Logs.FirstOrDefaultAsync(i => i.Id == checkItem.LogId),
                Name = checkItem.Name,
                Description = checkItem.Description,
                PhotoPath = checkItem.PhotoPath,
                Note = checkItem.Note,
                Type = checkItem.Type,
            };
            _context.CheckItems.Add(NewCheckItem);
            await _context.SaveChangesAsync();
            return NewCheckItem;
        }

        public async Task<CheckItem> GetCheckListByIdAsync(string id)
        {
            return await _context.CheckItems.FirstAsync(i => i.Id == id);
        }
    }
}
