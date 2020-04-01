using System;
using System.Collections.Generic;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public partial class SongArtistRelation
    {
        public decimal SongId { get; set; }
        public decimal ArtistId { get; set; }

        public Artists Artist { get; set; }
        public Songs Song { get; set; }
    }
}
