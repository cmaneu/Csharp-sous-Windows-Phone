using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class Album
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string NomArtiste { get; set; }
        public double Prix { get; set; }

        public Uri ImageUri
        {
            get
            {
                return new Uri(string.Concat("http://api.deezer.com/album/", Id, "/image"));
            }
        }
    }
}
