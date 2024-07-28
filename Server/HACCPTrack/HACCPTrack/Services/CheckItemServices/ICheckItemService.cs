using HACCPTrack.DTOs;
using HACCPTrack.Models;

namespace HACCPTrack.Services.CheckItemServices
{
    public interface ICheckItemService
    {
        public Task<List<CheckItem>> GetAllCheckItemsAsync();
        public Task<CheckItem> CreateCheckItemAsync(CheckItemDTO checkItem);

        public Task<CheckItem> GetCheckListByIdAsync(string id);
    }
}
