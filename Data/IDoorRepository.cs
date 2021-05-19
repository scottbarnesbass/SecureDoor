using System.Threading.Tasks;
using SecureDoor.Data.Models;
using MongoDB.Bson;

namespace SecureDoor.Data
{
    public interface IDoorRepository
    {
        Task<Door> Get(ObjectId objectId);
        Task<ObjectId> Create(string doorName);
        Task<bool> Update(Door door);
    }
}