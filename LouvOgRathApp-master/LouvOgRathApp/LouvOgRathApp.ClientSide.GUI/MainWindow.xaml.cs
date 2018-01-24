using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LouvOgRathApp.Shared.Entities;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using LouvOgRathApp.ClientSide.ClientControllers;

namespace LouvOgRathApp.ClientSide.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SecretaryGUI secretaryGUI;
        ClientGUI clientGUI;
        AddCase add;
        ClientControllers.Client client;
        public MainWindow()
        {
            client = new ClientControllers.Client(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 65432));
            ClientGuiLogic logic = new ClientGuiLogic();
            WeatherApi weather = logic.Weather();
            InitializeComponent();
            lblWeather.Content = weather.Main.Temp;

        }

        private void btnSecretary_Click(object sender, RoutedEventArgs e)
        {
            secretaryGUI = new SecretaryGUI(client);
            AssignUsercontrol(secretaryGUI);
            AddCase.Click += Addcase;
        }

        private void Addcase(object sender, RoutedEventArgs e)
        {
            add = new AddCase(client, new Secretary("something", 1));
            AssignUsercontrol(add);
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            clientGUI = new ClientGUI();
            AssignUsercontrol(clientGUI);
        }
        internal void AssignUsercontrol(UserControl userControl)
        {
            MainStackPanel.Visibility = Visibility.Collapsed;
            MainWindowUserControl.Content = userControl;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (client.ClientConnected())
            {
                ContentBar.Background = Brushes.Green;
                lblServerConnection.Content = "connected";
            }
            else
            {
                ContentBar.Background = Brushes.Red;
                lblServerConnection.Content = "not connected";
                MessageBoxResult result = MessageBox.Show("you are not connected, do you want to connect", "not connected", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK);
                if (result == MessageBoxResult.OK)
                {
                    client.Connect();
                    Window_ContentRendered(sender, e);
                }
            }
        }
    }
}
