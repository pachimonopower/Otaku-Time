using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otaku_Time
{
    class DecoratorClass
    {
        private static void DecorateControl(Control Control)
        {
            Color C = GetColor();
            Control.BackColor = C;

        }

        private static Color GetColor()
        {
            switch (VariablesClass.MasterURL)
            {
                case VariablesClass.KissAnimeURL:
                    return SystemColors.MenuHighlight;
                case VariablesClass.KissLewdURL:
                    return Color.MediumPurple;
                case VariablesClass.KissCartoonURL:
                    return Color.OrangeRed;
                default:
                    return Color.Red;
            }
        }

        public static void GoThroughDecorate(Control C)
        {
            if (C.BackColor == SystemColors.MenuHighlight) //default colour so everything doesnt get painted :)
            {
                DecorateControl(C);
            }
            foreach (Control Cont in C.Controls)
            {
                GoThroughDecorate(Cont);
            }
        }

    }
}
