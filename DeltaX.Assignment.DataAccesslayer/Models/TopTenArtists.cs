using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public class TopTenArtists
    {
        [Key]
        public decimal ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double? AverageRating { get; set; }
    }
}
