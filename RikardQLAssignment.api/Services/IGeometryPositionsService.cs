using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RikardQLAssignment.api.Models;

namespace RikardQLAssignment.api.Services
{
    public interface IGeometryPositionsService
    {
        List<Position> CreateCircle();
    }
}
