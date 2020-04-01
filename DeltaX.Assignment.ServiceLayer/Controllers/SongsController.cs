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
    public class SongsController : Controller
    {
        MusicoRepository repo = null;

        public SongsController()
        {
            repo = new MusicoRepository();
        }
        #region GetTopTenSongDetails
        [HttpGet]
        public JsonResult GetTopTenSongDetails()
        {
            List<DataAccesslayer.Models.TopTenSongs> SongsList = null;
            try
            {
                SongsList = repo.TopTenSongDetails();
            }
            catch (Exception)
            {
                SongsList = null;
            }
            return Json(SongsList);
        }
        #endregion

        #region GetArtistsOfSong
        [HttpGet]
        public List<DataAccesslayer.Models.ArtistsName> GetArtistsOfSong(decimal SongId)
        {
            //string Artists = null;
            List<DataAccesslayer.Models.ArtistsName> Artists = null;
            try
            {
                Artists = repo.GetArtistsOfSong(SongId);
            }
            catch (Exception)
            {
                Artists = null;
            }
            return Artists;
        }
        #endregion

       
    }
      
}