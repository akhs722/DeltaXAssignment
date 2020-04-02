using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeltaX.Assignment.DataAccessLayer;
namespace DeltaX.Assignment.ServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MusicoRepository repo = null;

        public UserController()
        {
            repo = new MusicoRepository();
        }
        #region ValidateUserCredentials
        [HttpPost]
        public bool ValidateUserCredentials(DataAccesslayer.Models.UserDetails userDetails)
        {
            bool status = false;
            string msg = null;
            try
            {
                status = repo.ValidateUserCredentials(userDetails);
            }
            catch (Exception)
            {
                status = false;
                msg = "Exception Caught";
            }
            return status;
        }
        #endregion


        #region Rating
        [HttpPut]
        public int Rating(Models.Rating Rating)
        {
            int status = 0;
            try
            {
                status = repo.Rating(Rating.Email, Rating.SongId, Rating.rating);
            }
            catch (Exception)
            {
                status = -99;
            }
            return status;
        }
        #endregion

        #region AddSong
        [HttpPost]
        public int AddSong(Models.Songs song)
        {
            int result = 0;
            try
            {
                result = repo.AddSong(song.SongName, song.DateOfRelease, song.AverageRating, song.ImageCoverLocation);
            }
            catch (Exception)
            {
                result = -99;
            }
            return result;
        }
        #endregion

    }

}


