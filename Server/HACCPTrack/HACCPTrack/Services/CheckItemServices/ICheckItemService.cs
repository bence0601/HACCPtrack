using HACCPTrack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HACCPTrack.Services.CheckItemServices
{
    public interface ICheckItemService
    {
        Task<List<CheckItem>> GetAllItemsAsync();
        Task<List<CheckItem>> AddCheckItemWithCheckboxAsync(CheckItemWithCheckbox checkItem);
        Task<List<CheckItem>> AddCheckItemWithInputFieldAsync(CheckItemWithInputField checkItem);
    }
}
