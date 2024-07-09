using System;
using System.Text.Json.Serialization;

namespace HACCPTrack.Models
{
    public class CheckItem
    {
        public string Id { get; set; }
        public string LogId { get; set; }
        [JsonIgnore]
        public Log Log { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsChecked { get; set; }
        public string? InputValue { get; set; }
        public string? PhotoPath { get; set; }
        public string? Note { get; set; }

        public CheckItem()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    public class CheckItemWithCheck : CheckItem
    {
        public CheckItemWithCheck()
        {
        }
    }

    public class CheckItemWithInput : CheckItem
    {
        public CheckItemWithInput()
        {
        }
    }
}
