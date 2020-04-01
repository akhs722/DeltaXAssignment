using System;
using System.Collections.Generic;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            UserRating = new HashSet<UserRating>();
        }

        public decimal Userid { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<UserRating> UserRating { get; set; }
    }
}
