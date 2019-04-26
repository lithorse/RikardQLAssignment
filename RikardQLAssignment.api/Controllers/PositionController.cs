using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RikardQLAssignment.api.DataAccess;
using RikardQLAssignment.api.Models;
using RikardQLAssignment.api.Services;

namespace RikardQLAssignment.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository repository;
        private readonly IGeometryPositionsService geometryPositionsService;

        public PositionController(IPositionRepository repository, IGeometryPositionsService geometryPositionsService)
        {
            this.repository = repository;
            this.geometryPositionsService = geometryPositionsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var positions = repository.Positions;
            return Ok(positions.Select(p => new { p.Latitude, p.Longitude, p.Title }));
        }

        [Route("circle")]
        [HttpGet]
        public IActionResult GetCircle()
        {
            var positions = geometryPositionsService.CreateCircle();
            return Ok(positions.Select(p => new { p.Latitude, p.Longitude, p.Title }));
        }
    }
}
