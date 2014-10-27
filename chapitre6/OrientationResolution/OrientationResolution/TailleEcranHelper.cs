using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Info;

namespace OrientationResolution
{
    public class TailleEcranHelper
    {
        // Taille par défaut, afin de ne recalculer qu'une seule fois la résolution.
        static private double _screenSize = -1.0f;
        static private double _screenDpiX = 0.0f;
        static private double _screenDpiY = 0.0f;
        static private Size _resolution;

        /// <summary>
        /// Permet d'indiquer si l'exécution est sur un grand écran (supérieur à 5 pouces) ou non .
        /// </summary>
        static public bool EstGrandEcran
        {
            get
            {
                // Les émulateurs ne retournent pas une taille utilisable. Le 720p est utilisé pour simuler
                // les grands écrans, et le WVGA les petits écrans.
                if (Microsoft.Devices.Environment.DeviceType == Microsoft.Devices.DeviceType.Emulator)
                {
                    _screenSize = (App.Current.Host.Content.ScaleFactor == 150) ? 6.0f : 0.0f;
                }

                if (_screenSize == -1.0f)
                {
                    try
                    {
                        _screenDpiX = (double)DeviceExtendedProperties.GetValue("RawDpiX");
                        _screenDpiY = (double)DeviceExtendedProperties.GetValue("RawDpiY");
                        _resolution = (Size)DeviceExtendedProperties.GetValue("PhysicalScreenResolution");

                        // Calcul de la taille diagonale de l'écran.
                        _screenSize = Math.Sqrt(Math.Pow(_resolution.Width / _screenDpiX, 2) + Math.Pow(_resolution.Height / _screenDpiY, 2));
                    }
                    catch (Exception e)
                    {
                        // Ce code ne fonctionne pas sur les anciens terminaux, dont aucun n'est un grand écran.
                        Debug.WriteLine("EstGrandEcran erreur: " + e.Message);
                        _screenSize = 0;
                    }
                }

                return (_screenSize > 5.0f);
            }
        }
    }
}
