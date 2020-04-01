using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Assignment.ServiceLayer.Models
{
    public class Rating
    {
        public string Email { get; set; }
        public Decimal SongId { get; set; }
        public double rating { get; set; }
    }
}
