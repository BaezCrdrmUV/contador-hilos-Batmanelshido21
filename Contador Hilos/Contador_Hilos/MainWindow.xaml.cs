using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace Contador_Hilos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        int contador = 1;
        int contador2 = 1;
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void ButtonAutomatico_Click(object sender, RoutedEventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(contador_Automatico);
            Thread hilo_Automatico = new Thread(threadStart);
            hilo_Automatico.Start();
        }

        public void contador_Automatico()
        {
            TextAutomatico.Dispatcher.Invoke(new Action(() =>
            {
                BotonAutomatico.IsEnabled = false;
                BotonSecundario.IsEnabled = false;
            }
               ));
            
            for (int i=contador2; i<=100; i++)
            {
                TextAutomatico.Dispatcher.Invoke(new Action(() =>
                {
                    TextAutomatico.Text = i.ToString();
                }
                ));                
                Thread.Sleep(1000);
            }
            TextAutomatico.Dispatcher.Invoke(new Action(() =>
            {
                BotonAutomatico.IsEnabled = true;
                BotonSecundario.IsEnabled = true;
            }
     ));
        }

        private void ButtonManual_Click(object sender, RoutedEventArgs e)
        {
            
            if(contador <= 100)
            {
                   TextManual.Text = contador++ +"";

            }          
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (contador2 <= 100)
            {
                TextAutomatico.Text = contador2++ + "";

            }
        }
    }
}
