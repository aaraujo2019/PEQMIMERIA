using DBMETAL_SHARP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio
{
    class Program
    {
        static void Main(string[] args)
        {
            int Op = Convert.ToInt32(args[0].Trim());

            switch (Op)
            {
                case 1:
                    Principal Forma1 = new Principal();
                    Forma1.ShowDialog();
                    break;
                case 2:
                    Frm_Vehiculo Forma2 = new Frm_Vehiculo("");
                    Forma2.ShowDialog();
                    break;

            }
        }
    }
}

