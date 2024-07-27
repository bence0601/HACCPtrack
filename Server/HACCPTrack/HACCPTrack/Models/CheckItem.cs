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
        public string Description { get; set; }
        public string PhotoPath { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }  

        public CheckItem()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    public class CheckItemWithCheckBox : CheckItem
    {
        public bool isChecked { get; set; }

        public CheckItemWithCheckBox()
        {
            Type = "CheckItemWithCheckBox";
        }
    }

    public class CheckItemWithInputField : CheckItem
    {
        public string Inputvalue { get; set; }

        public CheckItemWithInputField()
        {
            Type = "CheckItemWithInputField";
        }
    }
}
