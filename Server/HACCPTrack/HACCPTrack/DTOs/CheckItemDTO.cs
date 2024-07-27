using HACCPTrack.Models;

namespace HACCPTrack.DTOs
{
    public class CheckItemDTO
    {
        public string LogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public string Note { get; set; }
        public string Type { get;  set; }

    }
}
