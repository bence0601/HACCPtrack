using HACCPTrack.Models;
using System.Text.Json.Serialization;

namespace HACCPTrack.DTOs
{
    public class LogDTO
    {
        public string RestaurantId { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? RegenerationIntervalHours { get; set; }
    }
}
