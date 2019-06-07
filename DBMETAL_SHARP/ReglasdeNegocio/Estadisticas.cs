using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasdeNegocio
{
    public class Estadisticas
    {
        public static double Desv(double[] Array)
        {
            double Media = Array.Average();
            double[] Resultado;
            List<double> Desviacion = new List<double>(); 
            for (int i = 0; i < Array.Length; i++)
            {
                Desviacion.Add((Array[i] - Media) * (Array[i] - Media));
            }
            Resultado = Desviacion.ToArray();
            return Math.Sqrt(Resultado.Average()); 
        }

        public static double Mediana(List<double> List)
        {
            int TotalReg = List.Count();
            List.Sort();
            double Resultado = 0.00;
            if (TotalReg == 1)
            Resultado = List[0];
            else
            if (TotalReg % 2 != 0)
                Resultado = List[TotalReg / 2 -1];
            else
                Resultado = (List[TotalReg / 2 -1] + List[(TotalReg / 2)]) / 2;
            return Resultado;
        }
    }
}
