using LouvOgRathApp.Shared.Entities;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace LouvOgRathApp.ClientSide.GUI
{
    /// <summary>
    /// Interaction logic for Secretary.xaml
    /// </summary>
    public partial class SecretaryGUI : UserControl
    {
        ClientControllers.Client client;
        public SecretaryGUI(ClientControllers.Client client)
        {
            InitializeComponent();
            this.client = new ClientControllers.Client(new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"), 65432));
            if (client.ClientConnected())
            {
                IPersistable[] Iper = client.GetAllCases();
                List<Case> cases = new List<Case>();
                foreach (Case item in Iper)
                {
                    cases.Add(item);
                }
                dgCases.ItemsSource = cases;
            }
            if (client.ClientConnected())
            {
                IPersistable[] Iper = client.GetAllCases();
                List<Case> cases = new List<Case>();
                foreach (Case item in Iper)
                {
                    cases.Add(item);
                }
                dgCases.ItemsSource = cases;
            }
        }

        private void dgCases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSaveSummery1_Click(object sender, RoutedEventArgs e)
        {
            client.Connect();
            Secretary secretary = new Secretary("something", 1);
            if ((Case)dgCases.SelectedItem is Case @case)
            {
                List<MettingSummery> metting = new List<MettingSummery>();
                //MettingSummery summery = new MettingSummery(tbxNewSummery.Text, secretary, @case);
                client.SaveSummery(metting.ToArray());
            }
            else
            {
                MessageBox.Show("you have to select a case before you can safe a summery");
            }
        }
    }
}