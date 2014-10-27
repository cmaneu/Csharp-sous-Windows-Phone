using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class AlbumSource
    {
        public static List<Album> Albums { get; private set; }
        
        public AlbumSource()
        {
            Albums = new List<Album>();
            Albums.Add(new Album() { Id = 7077981, Titre = "Reflection", NomArtiste = "Hooverphonic", Prix = 9.99 });
            Albums.Add(new Album() { Id = 6886576, Titre = "If You Wait", NomArtiste = "London Grammar", Prix = 4.99 });
        }



        public static Album GetAlbum(int albumId)
        {
            return Albums.FirstOrDefault(a => a.Id == albumId);
        }

    }
}
