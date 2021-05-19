using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using SecureDoor.Data;
using SecureDoor.Models.Request;
using SecureDoor.Models.Response;
namespace SecureDoor.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DoorController : ControllerBase
    {
        private readonly ILogger<DoorController> _logger;
        private readonly IDoorRepository _repository;

        public DoorController(ILogger<DoorController> logger,
                              IDoorRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("{doorId}")]
        public async Task<IActionResult> Get(string doorId)
        {
            var result = await _repository.Get(ObjectId.Parse(doorId));

            if (result == null)
                return NotFound();

            return new JsonResult(new Door
            {
                Id = result.Id.ToString(),
                DoorName = result.DoorName,
                CreatedAt = result.CreatedAt,
                UpdatedAt = DateTime.UtcNow,
                Locked = result.Locked
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoor door)
        {
            var createdDoorId = await _repository.Create(door.DoorName);

            return new JsonResult(createdDoorId.ToString());
        }
    }
}
