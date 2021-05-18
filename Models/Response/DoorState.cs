using System;

namespace SecureDoor.Models.Response
{
    public class DoorState
    {
        public Guid Id { get; set; }
        public Guid DoorId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Locked { get; set; }
    }
}