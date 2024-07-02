namespace HACCPTrack.Models
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Log> Logs { get; set; }
        public Restaurant()
        {
            Id = Guid.NewGuid().ToString();
            Users = new List<User>();
            Logs = new List<Log>();
        }
    }
}
