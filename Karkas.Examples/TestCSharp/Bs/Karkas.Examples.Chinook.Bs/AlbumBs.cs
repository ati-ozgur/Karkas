﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Karkas.Data;
using Karkas.Examples.Chinook.TypeLibrary;
using Karkas.Examples.Chinook.Dal;


namespace Karkas.Examples.Chinook.Bs
{
    public partial class AlbumBs
    {

        public bool IsTitleExists(string title)
        {
            return dal.IsTitleExists(title);
        } 

        public void InsertNewArtistAndAlbum(string artistName, string albumTitle)
        {
            this.BeginTransaction();

            var artistDal = GetDalInstance<ArtistDal,Artist>();
            Artist newArtist = new Artist();
            newArtist.Name = artistName;
            var newArtistId = artistDal.Insert(newArtist);


            Album newAlbum = new Album();
            newAlbum.Title = albumTitle;
            newAlbum.ArtistId = newArtistId;
            dal.Insert(newAlbum);

            this.CommitTransaction();
        }

        public void InsertNewArtistAndAlbumError(string artistName, string albumTitle)
        {
            try
            {
                this.BeginTransaction();

                var artistDal = GetDalInstance<ArtistDal, Artist>();
                Artist newArtist = new Artist();
                newArtist.Name = artistName;
                var newArtistId = artistDal.Insert(newArtist);

                throw new Exception("Simulate roll back");
            }
            finally
            {
                this.ClearTransactionInformation();
            }

        }

    }
}
