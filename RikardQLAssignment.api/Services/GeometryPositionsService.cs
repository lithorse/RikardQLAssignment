using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RikardQLAssignment.api.Models;

namespace RikardQLAssignment.api.Services
{
    public class GeometryPositionsService : IGeometryPositionsService
    {
        public List<Position> CreateCircle()
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

            return positions;
        }
    }
}
