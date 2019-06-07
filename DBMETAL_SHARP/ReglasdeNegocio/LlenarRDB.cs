using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasNegocios
{
    public class LlenarRDB
    {
        public static int ConsultarIdRadioButton(GroupBox Grupo)
        {
            int PosicionRB = 1;
            foreach (Control ctrl in Grupo.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton radio = ctrl as RadioButton;
                    if (radio.Checked)
                        break;
                }
                PosicionRB += 1;
            }
            return PosicionRB;
        }
    }
}
