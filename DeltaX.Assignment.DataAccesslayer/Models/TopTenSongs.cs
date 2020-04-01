using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public class TopTenSongs
    {
        [Key]
        public decimal SongId { get; set; }
        public string SongName { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public double? AverageRating { get; set; }
        public string ImageCoverLocation { get; set; }
    }
}
