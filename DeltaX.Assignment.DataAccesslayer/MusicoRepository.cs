using System;
using System.Collections.Generic;
using DeltaX.Assignment.DataAccesslayer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DeltaX.Assignment.DataAccessLayer
{
    public class MusicoRepository
    {
        MusicoDBContext context = null;

        public MusicoRepository()
        {
            context = new MusicoDBContext();
        }

        #region ValidateCredentials
        public bool ValidateUserCredentials(UserDetails userDetails)
        {
            bool status = false;
            try
            {
                var user = context.UserDetails.Where(u => u.Email == userDetails.Email).FirstOrDefault();
                if (user.Password == userDetails.Password)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        #endregion

        #region TopTenSongDetails
        public List<TopTenSongs> TopTenSongDetails()
        {
            List<TopTenSongs> SongsList = null;
            try
            {
                SongsList = context.TopTenSongs.FromSql("SELECT * FROM dbo.ufn_TopTenSongDetails()").ToList();
            }
            catch (Exception)
            {
                SongsList = null;
            }
            return SongsList;
        }
        #endregion


        #region TopTenArtistDetails
        public List<TopTenArtists> TopTenArtistDetails()
        {
            List<TopTenArtists> ArtistsList = null;
            try
            {
                ArtistsList = context.TopTenArtists.FromSql("SELECT * FROM dbo.ufn_TopTenArtistDetails()").ToList();
            }
            catch (Exception e)
            {
                ArtistsList = null;
                Console.WriteLine(e.Message);
            }
            return ArtistsList;
        }
        #endregion

        #region Rating
        public int Rating(string Email, decimal SongId, double rating)
        {
            int result = 0;
            try
            {
                SqlParameter prmEmail = new SqlParameter("@email", Email);
                SqlParameter prmSongId = new SqlParameter("@SongId", SongId);
                prmSongId.SqlDbType = System.Data.SqlDbType.Decimal;
                SqlParameter prmrating = new SqlParameter("@rating", rating);
                prmrating.SqlDbType = System.Data.SqlDbType.Float;
                SqlParameter returnValue = new SqlParameter("@return", System.Data.SqlDbType.Int);
                returnValue.Direction = System.Data.ParameterDirection.Output;
                context.Database.ExecuteSqlCommand("EXEC @return = usp_UpdateRating @email, @SongId, @rating", new[] { returnValue, prmEmail, prmSongId, prmrating });
                result = Convert.ToInt32(returnValue.Value);
            }
            catch (Exception)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region GetArtistsOfSong
        public List<ArtistsName> GetArtistsOfSong(decimal SongId)
        {
            List<ArtistsName> ArtistsList = null;
            
            try
            {
                SqlParameter prmSongId = new SqlParameter("@SongId", SongId);
                prmSongId.SqlDbType = System.Data.SqlDbType.Decimal;
                ArtistsList = context.ArtistsName.FromSql("SELECT * FROM dbo.ufn_GetArtistsOfSong(@SongId)", prmSongId).ToList();
            }
            catch (Exception)
            {
                ArtistsList = null;

            }
            return ArtistsList;
        }
        #endregion


        #region AddSong
        public int AddSong(string SongName, DateTime DateOfRelease, double AverageRating, string ImageCoverLocation)
        {
            int result = 0;
            try
            {
                SqlParameter prmSongName = new SqlParameter("@SongName", SongName);
                SqlParameter prmDateOfRelease = new SqlParameter("@DateOfRelease", DateOfRelease);
                prmDateOfRelease.SqlDbType = System.Data.SqlDbType.DateTime;
                SqlParameter prmAverageRating = new SqlParameter("@AverageRating", AverageRating);
                prmAverageRating.SqlDbType = System.Data.SqlDbType.Float;
                SqlParameter prmImageCoverLocation = new SqlParameter("@ImagecoverLocation", ImageCoverLocation);
                SqlParameter returnValue = new SqlParameter("@return", System.Data.SqlDbType.Int);
                returnValue.Direction = System.Data.ParameterDirection.Output;
                context.Database.ExecuteSqlCommand("EXEC @return = usp_AddSong @SongName, @DateOfRelease, @AverageRating, @ImagecoverLocation", new[] { returnValue, prmSongName, prmDateOfRelease, prmAverageRating, prmImageCoverLocation });
                result = Convert.ToInt32(returnValue.Value);
            }
            catch (Exception e)
            {
                result = -99;
                //Console.WriteLine(e.Message);
            }
            return result;
        }
        #endregion

        #region SongArtistRelation
        public int SongArtistRelation(decimal SongId,decimal ArtistId)
        {
            int result = 0;
            try
            {
                SqlParameter prmSongId = new SqlParameter("@SongId", SongId);
                SqlParameter prmArtistId = new SqlParameter("@ArtistId", ArtistId);
                prmSongId.SqlDbType = System.Data.SqlDbType.Decimal;
                
                SqlParameter returnValue = new SqlParameter("@return", System.Data.SqlDbType.Int);
                returnValue.Direction = System.Data.ParameterDirection.Output;
                context.Database.ExecuteSqlCommand("EXEC @return = usp_SongArtistRelation @SongId, @ArtistId", new[] { returnValue, prmSongId, prmArtistId});
                result = Convert.ToInt32(returnValue.Value);
            }
            catch (Exception e)
            {
                result = -99;
                
            }
            return result;
        }
        #endregion

    }
}





