using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RikardQLAssignment.api.Models;

namespace RikardQLAssignment.api.DataAccess
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataBaseContext context;

        public PositionRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public DbSet<Position> Positions => context.Positions;
    }
}
