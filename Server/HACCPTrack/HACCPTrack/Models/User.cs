using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace HACCPTrack.Models
{
    public class User
    {
        public string Id { get; set; }

        public string IdentityUserId { get; set; }
        [JsonIgnore]
        public IdentityUser IdentityUser { get; set; }

        public string Role { get; set; }

        public string? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<Log> Logs { get; set; }
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Logs = new List<Log>();
        }
    }
}
