using HACCPTrack.Models;

namespace HACCPTrack.Services.CheckItemServices
{
    public interface ICheckItemService
    {
        public Task<List<CheckItem>> GetAllItems();



    }
}
