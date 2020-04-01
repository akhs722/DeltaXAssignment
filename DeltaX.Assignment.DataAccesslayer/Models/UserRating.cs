using System;
using System.Collections.Generic;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public partial class UserRating
    {
        public decimal Sno { get; set; }
        public decimal? Userid { get; set; }
        public decimal? SongId { get; set; }

        public Songs Song { get; set; }
        public UserDetails User { get; set; }
    }
}
