using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecureDoor.Models.Response;

namespace SecureDoor.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    pubic class DoorController : ControllerBase
    {
        private readonly ILogger<DoorController> _logger;

        public DoorController(ILogger<DoorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{doorId}")]
        public DoorState Get(Guid doorId)
        {
            return new DoorState
            {
                Id = Guid.NewGuid(),
                DoorId = doorId,
                UpdatedAt = DateTime.UtcNow,
                Locked = true
            };
        }
    }
}
