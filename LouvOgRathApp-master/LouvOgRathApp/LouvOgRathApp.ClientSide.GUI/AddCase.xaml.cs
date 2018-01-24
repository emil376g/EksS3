using LouvOgRathApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
namespace LouvOgRathApp.ClientSide.GUI
{
    /// <summary>
    /// Interaction logic for AddCase.xaml
    /// </summary>
    public partial class AddCase : UserControl
    {
        ClientControllers.Client client;
        Secretary secretary;
        public AddCase(ClientControllers.Client client, Secretary secretary)
        {
            this.secretary = secretary;
            this.client = client;
            InitializeComponent();
            cmbCaseKind.ItemsSource = Enum.GetValues(typeof(CaseKind));
        }

        private void btnAddCase_Click(object sender, RoutedEventArgs e)
        {
            List<Case> cases = new List<Case>();
            Case @case = new Case(tbxCaseTitle.Text, (CaseKind)cmbCaseKind.SelectedItem, new Lawyer(tbxCaseLawyer.Text), new Shared.Entities.Client(tbxCaseClient.Text), new MettingSummery(tbxResume.Text, secretary));
            cases.Add(@case);
            //Controller.SendData(SaveNewCase(),cases);
            client.SaveCase(cases.ToArray());
            MessageBox.Show("you have sent the request perfect");
        }
    }
}
