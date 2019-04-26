using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RikardQLAssignment.api.DataAccess;
using RikardQLAssignment.api.Models;

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

        [Route("circle")]
        [HttpGet]
        public IActionResult GetCircle()
        {
            var positions = new List<Position>();
            for (int i = 0; i < 360; i += 30)
            {
                var radian = i * Math.PI / 180;
                var latitude = Math.Round(40 * Math.Cos(radian));
                var longitude = Math.Round(40 * Math.Sin(radian));
                var title = $"Latitude: {latitude} Longitude: {longitude}";
                var position = new Position()
                {
                    Latitude = latitude.ToString(),
                    Longitude = longitude.ToString(),
                    Title = title
                };
                positions.Add(position);
            }

            return Ok(positions.Select(p => new { p.Latitude, p.Longitude, p.Title }));
        }
    }
}
