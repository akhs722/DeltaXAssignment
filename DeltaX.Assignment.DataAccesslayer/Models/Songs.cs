using System;
using System.Collections.Generic;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public partial class Songs
    {
        public Songs()
        {
            SongArtistRelation = new HashSet<SongArtistRelation>();
            UserRating = new HashSet<UserRating>();
        }

        public decimal SongId { get; set; }
        public string SongName { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public double? AverageRating { get; set; }
        public string ImageCoverLocation { get; set; }

        public ICollection<SongArtistRelation> SongArtistRelation { get; set; }
        public ICollection<UserRating> UserRating { get; set; }
    }
}
