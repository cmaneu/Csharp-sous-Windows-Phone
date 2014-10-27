using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo
{
    public class LigneTrain : Ligne, ICalculTempsTrajet
    {
        public string CompagnieOperatrice { get; set; }

        public LigneTrain(string nom, int nombreArrets, string compagnie)
            : base(nom, nombreArrets)
        {
            CompagnieOperatrice = compagnie;
        }

        public override sealed string GetDescription()
        {
            throw new ApplicationException("LigneTrain ne supporte pas la méthode GetDescription");
           // return base.GetDescription() + " Opéré par " + CompagnieOperatrice;
        }

        public int GetTempsTrajet(string depart, string arrivee)
        {
            return 42;
        }
    }

    public class LigneTGV : LigneTrain
    {
        public LigneTGV(string nom, int nombreArrets, string compagnie)
            : base(nom, nombreArrets,compagnie)
            {

            }

        public new string GetDescription()
        {
            return "Ligne TGV";
        }
    }
}
