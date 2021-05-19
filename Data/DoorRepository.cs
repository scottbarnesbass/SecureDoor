using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SecureDoor.Data.Models;

namespace SecureDoor.Data
{
    public class DoorRepository : IDoorRepository
    {
        private readonly IMongoCollection<Door> _doors;
        public DoorRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("SecureDoor");
            _doors = database.GetCollection<Door>("Doors");
        }

        public async Task<ObjectId> Create(string doorName)
        {
            var newDoor = new Door
            {
                Id = new ObjectId(),
                DoorName = doorName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Locked = false
            };

            await _doors.InsertOneAsync(newDoor);

            return newDoor.Id;
        }

        public async Task<Door> Get(ObjectId objectId)
        {
            var filter = Builders<Door>.Filter.Eq(d => d.Id, objectId);
            return await _doors.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Door door)
        {
            var filter = Builders<Door>.Filter.Eq(d => d.Id, door.Id);
            var update = Builders<Door>.Update
                                       .Set(d => d.Locked, door.Locked)
                                       .Set(d => d.UpdatedAt, door.UpdatedAt);

            var result = await _doors.UpdateOneAsync(filter, update);
            return result.ModifiedCount == 1;
        }
    }
}