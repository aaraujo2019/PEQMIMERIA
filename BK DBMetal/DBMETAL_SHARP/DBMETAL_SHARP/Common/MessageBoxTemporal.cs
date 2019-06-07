﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMETAL_SHARP.Common
{
    /// <summary>
    /// Programa MessageBox con contador de tiempo configurable
    /// </summary>
   public class MessageBoxTemporal
    {
        System.Threading.Timer IntervaloTiempo;
        string TituloMessageBox;
        string TextoMessageBox;
        int TiempoMaximo;
        IntPtr hndLabel = IntPtr.Zero;
        bool MostrarContador;

        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll",
            CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true,
            CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
            string lpszClass, string lpszWindow);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true,
            CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern bool SetWindowText(IntPtr hwnd, string lpString);

        /// <summary>
        /// MEtodo expuesto q captura los parametros bajo los cuales se ejecuta el message de manera temporal
        /// </summary>
        /// <param name="texto">Mensaje principal dem MessageBox</param>
        /// <param name="titulo">Titulo que recibe la ventana que se despliega</param>
        /// <param name="tiempo">EL timepo en segudos que se demora en lazarse</param>
        /// <param name="contador">Valida si se muestra o no el contador</param>
        MessageBoxTemporal(string texto, string titulo, int tiempo, bool contador)
        {
            TituloMessageBox = titulo;
            TiempoMaximo = tiempo;
            TextoMessageBox = texto;
            MostrarContador = contador;

            if (TiempoMaximo > 99) return; //Máximo 99 segundos
            IntervaloTiempo = new System.Threading.Timer(EjecutaCada1Segundo,
                null, 1000, 1000);
            if (contador)
            {
                DialogResult ResultadoMensaje = MessageBox.Show(texto + "\r\nEste mensaje se cerrará dentro de " +
                    TiempoMaximo.ToString("00") + " segundos ...", titulo);
                if (ResultadoMensaje == DialogResult.OK) IntervaloTiempo.Dispose();
            }
            else
            {
                DialogResult ResultadoMensaje = MessageBox.Show(texto + "...", titulo);
                if (ResultadoMensaje == DialogResult.OK) IntervaloTiempo.Dispose();
            }
        }
        public static void Show(string texto, string titulo, int tiempo, bool contador)
        {
            new MessageBoxTemporal(texto, titulo, tiempo, contador);
        }
        /// <summary>
        /// Metodo que permite la ejecuciòn en tiempo discrimiando en segundos
        /// </summary>
        /// <param name="state"></param>
        void EjecutaCada1Segundo(object state)
        {
            TiempoMaximo--;
            if (TiempoMaximo <= 0)
            {
                IntPtr hndMBox = FindWindow(null, TituloMessageBox);
                if (hndMBox != IntPtr.Zero)
                {
                    SendMessage(hndMBox, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    IntervaloTiempo.Dispose();
                }
            }
            else if (MostrarContador)
            {
                // Ha pasado un intervalo de 1 seg:
                if (hndLabel != IntPtr.Zero)
                {
                    SetWindowText(hndLabel, TextoMessageBox +
                        "\r\nEste mensaje se cerrará dentro de " +
                        TiempoMaximo.ToString("00") + " segundos");
                }
                else
                {
                    IntPtr hndMBox = FindWindow(null, TituloMessageBox);
                    if (hndMBox != IntPtr.Zero)
                    {
                        // Ha encontrado el MessageBox, busca ahora el texto
                        hndLabel = FindWindowEx(hndMBox, IntPtr.Zero, "Static", null);
                        if (hndLabel != IntPtr.Zero)
                        {
                            // Ha encontrado el texto porque el MessageBox
                            // solo tiene un control "Static".
                            SetWindowText(hndLabel, TextoMessageBox +
                                "\r\nEste mensaje se cerrará dentro de " +
                                TiempoMaximo.ToString("00") + " segundos");
                        }
                    }
                }
            }
        }
    }
 }
