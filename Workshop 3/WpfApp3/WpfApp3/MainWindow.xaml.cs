using System;
using System.Windows;
using System.IO.Ports;

namespace controller_Arduino
{
    /// <summary>    
    /// Interaction logic for MainWindow.xaml    
    /// </summary>    
    public partial class MainWindow : Window
    {
        SerialPort sp = new SerialPort();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void on_Click(object sender, RoutedEventArgs e)
        {
            sp.Write("r");
        }

        private void Of_Click(object sender, RoutedEventArgs e)
        {
            sp.Write("r");
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String portName = comportno.Text;
                sp.PortName = portName;
                sp.BaudRate = 9600;
                sp.Open();
                status.Text = "Connected";
            }
            catch (Exception)
            {

                MessageBox.Show("Please give a valid port number or check your connection");
            }
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sp.Close();
                status.Text = "Disconnected";
            }
            catch (Exception)
            {

                MessageBox.Show("First Connect and then disconnect");
            }
        }

        private void rLedOn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sp.Write(sliderLED.Value.ToString());
        }
    }
}