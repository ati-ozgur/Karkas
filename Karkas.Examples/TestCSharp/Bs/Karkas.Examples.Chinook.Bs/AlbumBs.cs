
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using Karkas.Core.Data.Sqlite;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using Karkas.Examples.Chinook.TypeLibrary;
using Karkas.Examples.Chinook.Dal;


namespace Karkas.Examples.Chinook.Bs
{
    public partial class AlbumBs : BaseBs<Album, AlbumDal, AdoTemplateSqlite, ParameterBuilderSqlite>
    {

        public void InsertNewArtistAndAlbum(string artistName, string albumTitle)
        {
            this.BeginTransaction();

            var artistDal = dal.GetDalInstance<ArtistDal,Artist, ParameterBuilderSqlite>();
            Artist newArtist = new Artist();
            newArtist.Name = artistName;
            long newArtistId = artistDal.Insert(newArtist);





            Album newAlbum = new Album();
            newAlbum.Title = albumTitle;
            newAlbum.ArtistId = newArtistId;
            dal.Insert(newAlbum);

            this.CommitTransaction();
        }

    }
}
