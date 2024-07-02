namespace HACCPTrack.Models.Invites
{
    public class Invite
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool IsUsed { get; set; }
    }
}
