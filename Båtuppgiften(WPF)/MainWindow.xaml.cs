using Båtuppgiften_WPF_.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Båtuppgiften_WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Harbour.CreateHarbour();
            FileSupport.ImportBoatsFromFile();

            Announcer.CreateHarbourDisplayList();
            BoatBox2.ItemsSource = Announcer.HarbourDisplayList;

            Statistics.CreateStatisticsList();
            AnnouncementBox.ItemsSource = Statistics.AnnouncementList;     
            
            Announcer.CreateBoatTrafficList();
            BoatHappenings.ItemsSource = Announcer.BoatTrafficList;           
        }

        private void UpdateHarbour()
        {
            Harbour.LeavingBoats();

            Harbour.CreateNewBoats();
            Harbour.MoorNewBoats();

            Announcer.CreateHarbourDisplayList();
            BoatBox2.Items.Refresh();

            Statistics.CreateStatisticsList();
            AnnouncementBox.Items.Refresh();

            Announcer.CreateBoatTrafficList();
            BoatHappenings.Items.Refresh();
        }


        private void NextDayButton_Click(object sender, RoutedEventArgs e)
        {
            Harbour.NextDay();
            Announcer.Reset();
            UpdateHarbour();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            FileSupport.ExportBoatsToFile();
            Application.Current.Shutdown();
        }
    }

    
}
