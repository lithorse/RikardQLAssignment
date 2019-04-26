using Microsoft.EntityFrameworkCore;
using RikardQLAssignment.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RikardQLAssignment.api.DataAccess
{
    public interface IPositionRepository
    {
        DbSet<Position> Positions { get; }
    }
}
