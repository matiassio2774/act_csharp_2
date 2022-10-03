using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using System.IO;


namespace WindowsService2
{
    public partial class Service1 : ServiceBase
    {
        public System.Timers.Timer TimerServicio = new System.Timers.Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Agregue el código aquí para iniciar el servicio. Este método debería poner
            // en movimiento los elementos para que el servicio pueda funcionar.

            string[] linea = System.IO.File.ReadAllLines(@"A:\config.txt");
            string diaConfig = linea[0];
            string horaConfig = linea[1];
            string intervaloConfig = linea[2];

            DayOfWeek diaActual = DateTime.Today.DayOfWeek;
            String horaActual = DateTime.Now.ToString("HH:mm");

            TimerServicio = new System.Timers.Timer();
            TimerServicio.Elapsed += (_, __) => EjecutaUnaAccion();

            switch(diaConfig)
            {
                case "Lunes":
                        if (diaActual == DayOfWeek.Monday)
                            do
                            {
                                horaActual = DateTime.Now.ToString("HH:mm");
                                TimerServicio.Interval = Convert.ToDouble(intervaloConfig);
                            } while (horaActual != horaConfig);
                        TimerServicio.Start();
                    break;
                case "Martes":
                        if (diaActual == DayOfWeek.Tuesday)
                            do
                            {
                                horaActual = DateTime.Now.ToString("HH:mm");
                                TimerServicio.Interval = Convert.ToDouble(intervaloConfig);
                            } while (horaActual != horaConfig);
                        TimerServicio.Start();
                    break;
                case "Miercoles":
                        if (diaActual == DayOfWeek.Wednesday)
                            do
                            {
                                horaActual = DateTime.Now.ToString("HH:mm");
                                TimerServicio.Interval = Convert.ToDouble(intervaloConfig);
                            } while (horaActual != horaConfig);
                        TimerServicio.Start();
                    break;
                case "Jueves":
                        if (diaActual == DayOfWeek.Thursday)
                            do
                            {
                                horaActual = DateTime.Now.ToString("HH:mm");
                                TimerServicio.Interval = Convert.ToDouble(intervaloConfig);
                            } while (horaActual != horaConfig);
                        TimerServicio.Start();
                    break;
                case "Viernes":
                        if (diaActual == DayOfWeek.Friday)
                            do
                            {
                                horaActual = DateTime.Now.ToString("HH:mm");
                                TimerServicio.Interval = Convert.ToDouble(intervaloConfig);
                            } while (horaActual != horaConfig);
                        TimerServicio.Start();
                    break;
                case "Sabado":
                        if (diaActual == DayOfWeek.Saturday)
                            do
                            {
                                horaActual = DateTime.Now.ToString("HH:mm");
                                TimerServicio.Interval = Convert.ToDouble(intervaloConfig);
                            } while (horaActual != horaConfig);
                        TimerServicio.Start();
                    break;
                case "Domingo":
                        if (diaActual == DayOfWeek.Sunday)
                            do
                            {
                                horaActual = DateTime.Now.ToString("HH:mm");
                                TimerServicio.Interval = Convert.ToDouble(intervaloConfig);
                            } while (horaActual != horaConfig);
                        TimerServicio.Start();
                    break;
                default:
                    break;
            }

        }

        public void EjecutaUnaAccion()
        {
            int i;
            for (i = 1; i <= 1000; i++)
            {
                File.AppendAllText(@"A:\INFORME.TXT","LINEA: " + i + System.Environment.NewLine);
            }
            TimerServicio.Close();
        }
        protected override void OnStop()
        {
            TimerServicio.Close();
        }
        protected override void OnPause()
        {
            TimerServicio.Stop();
        }

        protected override void OnContinue()
        {
            TimerServicio.Start();
        }
    }
}
