using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public class ArtistsName
    {
        [Key]
        public decimal ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
}
