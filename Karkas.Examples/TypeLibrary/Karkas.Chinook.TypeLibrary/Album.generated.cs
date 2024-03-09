using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using System.ComponentModel.DataAnnotations;

namespace Karkas.Chinook.TypeLibrary
{
	[Serializable]
	[DebuggerDisplay("AlbumId = {AlbumId}")]
	public partial class 	Album: BaseTypeLibrary
	{
		private long albumId;
		private Unknown title;
		private long artistId;

		[Key]
		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long AlbumId
		{
			[DebuggerStepThrough]
			get
			{
				return albumId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (albumId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				albumId = value;
			}
		}

		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Unknown Title
		{
			[DebuggerStepThrough]
			get
			{
				return title;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (title!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				title = value;
			}
		}

		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public long ArtistId
		{
			[DebuggerStepThrough]
			get
			{
				return artistId;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (artistId!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				artistId = value;
			}
		}

		public Album ShallowCopy()
		{
			Album obj = new Album();
			obj.albumId = albumId;
			obj.title = title;
			obj.artistId = artistId;
			return obj;
		}
		
		public class PropertyIsimleri
		{
			public const string AlbumId = "AlbumId";
			public const string Title = "Title";
			public const string ArtistId = "ArtistId";
		}

	}
}
