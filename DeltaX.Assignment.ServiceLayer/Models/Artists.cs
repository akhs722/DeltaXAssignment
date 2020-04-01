using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Assignment.ServiceLayer.Models
{
    public class Artists
    {
        public decimal ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Bio { get; set; }
    }
}
