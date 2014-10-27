using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo
{
    public abstract class Ligne
    {
        private DateTime _dateCreation;
        public string Nom { get; set; }
        public int NombreStations { get; set; }

        public Ligne()
        {
            _dateCreation = DateTime.Now;
        }

        public Ligne(string nom, int nbStations)
        {
            _dateCreation = DateTime.Now;
            Nom = nom;
            NombreStations = nbStations;
        }

        public abstract string GetDescription();
    }
}
