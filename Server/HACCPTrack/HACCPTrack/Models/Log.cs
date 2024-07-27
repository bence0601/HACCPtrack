using System.Text.Json.Serialization;

namespace HACCPTrack.Models
{
    public class Log
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        [JsonIgnore]
        public Restaurant Restaurant { get; set; }
        public string CreatedByUserId { get; set; }

        [JsonIgnore]
        public User CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? RegenerationIntervalHours { get; set; }
        public ICollection<CheckItem> CheckItems { get; set; }

        public Log()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
            CheckItems = new List<CheckItem>();
        }
    }

}
