namespace HACCPTrack.Models.Invites
{
    public class Invite
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsUsed { get; set; }
    }
}
