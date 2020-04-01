using System;
using System.Collections.Generic;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public partial class Artists
    {
        public Artists()
        {
            SongArtistRelation = new HashSet<SongArtistRelation>();
        }

        public decimal ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Bio { get; set; }

        public ICollection<SongArtistRelation> SongArtistRelation { get; set; }
    }
}
