using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeltaX.Assignment.DataAccesslayer;
using DeltaX.Assignment.DataAccessLayer;
namespace DeltaX.Assignment.ServiceLayer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistsController : Controller
    {

        MusicoRepository repo = new MusicoRepository();

        public ArtistsController()
        {
            repo = new MusicoRepository();
        }

        #region GetTopTenArtistDetails
        [HttpGet]
        public JsonResult GetTopTenArtistDetails()
        {
            List<DataAccesslayer.Models.TopTenArtists> ArtistList = null;

            try
            {
                ArtistList = repo.TopTenArtistDetails();
            }
            catch (Exception)
            {
                ArtistList = null;
            }
            return Json(ArtistList);
        }
        #endregion

        #region SongArtistRelation
        [HttpPost]
        public int SongArtistRelation(Models.SongArtistRelation obj)
        {
            int status = 0;
            try
            {
                status = repo.SongArtistRelation(obj.SongId, obj.ArtistId);
            }
            catch (Exception)
            {
                status = -99;
            }
            return status;
        }
        #endregion


    }
}