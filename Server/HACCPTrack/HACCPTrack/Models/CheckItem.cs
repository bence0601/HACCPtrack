using System;
namespace HACCPTrack.Models
{
    public class CheckItem
    {
        public string Id { get; set; }
        public string LogId { get; set; }
        public Log Log { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PhotoPath { get; set; }
        public string? Note { get; set; }

        public CheckItem()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    public class CheckItemWithCheckbox : CheckItem
    {
        public bool IsChecked { get; set; }
    }

    public class CheckItemWithInputField : CheckItem
    {
        public string InputField { get; set; }
    }
}
