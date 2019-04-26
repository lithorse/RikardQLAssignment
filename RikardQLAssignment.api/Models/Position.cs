using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RikardQLAssignment.api.Models
{
    public class Position
    {
        public string Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Title { get; set; }
    }
}
