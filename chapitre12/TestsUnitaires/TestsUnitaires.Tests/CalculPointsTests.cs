using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace TestsUnitaires.Tests
{
    [TestClass]
    public class CalculPointsTests
    {
        [TestMethod]
        public void CalculScore_Niveau1_SansBonus()
        {
            // Arrange
            CalculPoints calcul = new CalculPoints();
            calcul.NiveauDifficulte = 1;
            int nombrePieces = 10;
            int bonus = 0;
            TimeSpan tempsJeu = TimeSpan.FromSeconds(184);
            
            // Act
            int resultat = calcul.CalculScore(nombrePieces, bonus, tempsJeu);

            // Assert
            Assert.AreEqual(100, resultat);
        }

[TestMethod]
public void CalculScore_Niveau1_BonusNegatif()
{
    // Arrange
    CalculPoints calcul = new CalculPoints();
    calcul.NiveauDifficulte = 1;
    int nombrePieces = 10;
    int bonus = -13;
    TimeSpan tempsJeu = TimeSpan.FromSeconds(184);

    // Act
    // Assert
    Assert.ThrowsException<ArgumentOutOfRangeException>(()=> calcul.CalculScore(nombrePieces, bonus, tempsJeu));
}

        [TestMethod]
        public void CalculScore_Niveau1_NiveauDifficulteZero()
        {
            // Arrange
            CalculPoints calcul = new CalculPoints();
            calcul.NiveauDifficulte = 0;
            int nombrePieces = 10;
            int bonus = 13;
            TimeSpan tempsJeu = TimeSpan.FromSeconds(184);

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => calcul.CalculScore(nombrePieces, bonus, tempsJeu));
        }
    }
}
