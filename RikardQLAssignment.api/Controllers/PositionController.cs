using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RikardQLAssignment.api.DataAccess;

namespace RikardQLAssignment.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository repository;

        public PositionController(IPositionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var positions = repository.Positions;
            return Ok(positions.Select(p => new { p.Latitude, p.Longitude, p.Title }));
        }
    }
}
