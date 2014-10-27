using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class CalculPoints
    {
        public int NiveauDifficulte { get; set; }

        public int CalculScore(int piecesRecoltees, int bonus, TimeSpan tempsJeu)
        {
            if(piecesRecoltees < 0)
                throw new ArgumentOutOfRangeException("piecesRecoltees");

            if (bonus < 0)
                throw new ArgumentOutOfRangeException("bonus");

            int score = 0;
            
            score += piecesRecoltees*10;
            score += bonus;

            int pointsTempsJeu = (((int)tempsJeu.TotalMilliseconds) / (NiveauDifficulte * 10));

            if (NiveauDifficulte > 3 && tempsJeu.TotalSeconds < 300)
            {
                score += pointsTempsJeu;            
            }
            
            return score;
        }
    }
}
