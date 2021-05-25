using System;
using MongoDB.Bson;

namespace SecureDoor.Data.Models
{
    public class Door
    {
        public ObjectId Id { get; set; }
        public string DoorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsLocked { get; set; }
    }
}