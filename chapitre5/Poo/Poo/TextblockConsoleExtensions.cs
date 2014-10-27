using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Poo
{
    static class TextblockConsoleExtensions
    {
        public static void WriteLine(this TextBlock textBlock, string text)
        {
            textBlock.Text += text + Environment.NewLine;
        }
    }
}
