using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Assignment.ServiceLayer.Models
{
    public class Songs
    {
        public decimal SongId { get; set; }
        public string SongName { get; set; }
        public DateTime DateOfRelease { get; set; }
        public double AverageRating { get; set; }
        public string ImageCoverLocation { get; set; }
    }
}
