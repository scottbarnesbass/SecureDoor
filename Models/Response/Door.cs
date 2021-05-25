using System;

namespace SecureDoor.Models.Response
{
    public class Door
    {
        public string Id { get; set; }
        public string DoorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsLocked { get; set; }
    }
}