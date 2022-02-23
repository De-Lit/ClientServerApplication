using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Net.Sockets;

namespace ServerWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow() 
        {
            try
            {
                Server server = new Server(80);
            }
            catch
            {

            }
            InitializeComponent();

            Button.Click += SendMesage;
        }
        private void SendMesage(object sender, RoutedEventArgs e)
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                IPAddress broadcast = IPAddress.Parse(ipAdress.Text);

                byte[] sendbuf = Encoding.ASCII.GetBytes("1");
                IPEndPoint ep = new IPEndPoint(broadcast, 11000);

                s.SendTo(sendbuf, ep);

                Console.WriteLine("Message sent to the broadcast address");
                System.Diagnostics.Process.Start(@"c:\Games\localhost\WebApplication2.exe");
            }
            catch
            {

            }
        }
    }
}

