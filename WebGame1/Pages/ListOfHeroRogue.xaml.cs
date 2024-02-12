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
using WebGame1.MongoDB;

namespace WebGame1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListOfHeroRogue.xaml
    /// </summary>
    public partial class ListOfHeroRogue : Page
    {
       
        public MongoDB.Rogue currentRogue = RoguePage.currentRogue;
        public ListOfHeroRogue()
        {
            int a = currentRogue._starpoints;
            InitializeComponent();
            List<MongoDB.Rogue> list = MongoDB.Rogue.GetRogue(currentRogue);
            ListSettings.ItemsSource = list;
            DataContext = this;
            myLevelTb.Text =  ((a - (a % 1000))/ 1000).ToString();
            CountPointsTb.Text = currentRogue._starpoints.ToString();
            

        }
        private void AddPowerBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentRogue._starpoints > 0)
                {
                    currentRogue._strenght++;
                    currentRogue._starpoints--;
                    CountPowerTb.Text = currentRogue._strenght.ToString();
                    CountPointsTb.Text = currentRogue._starpoints.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Выберите героя!", "Невозможно изменить", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddVitalityBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentRogue._starpoints > 0)
                {
                    currentRogue._vitality++;
                    currentRogue._starpoints--;
                    CountVitalityTb.Text = currentRogue._vitality.ToString();
                    CountPointsTb.Text = currentRogue._starpoints.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Выберите героя!", "Невозможно изменить", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AddDexterityBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentRogue._starpoints > 0)
                {
                    currentRogue._dexterity++;
                    currentRogue._starpoints--;
                    CountDexterityTb.Text = currentRogue._dexterity.ToString();
                    CountPointsTb.Text = currentRogue._starpoints.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Выберите героя!", "Невозможно изменить", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddInteligienceBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentRogue._starpoints > 0)
                {
                    currentRogue._inteligence++;
                    currentRogue._starpoints--;
                    CountInteligienceTb.Text = currentRogue._inteligence.ToString();
                    CountPointsTb.Text = currentRogue._starpoints.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Выберите героя!", "Невозможно изменить", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AddPointsBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentRogue._starpoints += 500;
                myLevelTb.Text = ((currentRogue._starpoints - (currentRogue._starpoints % 1000)) / 1000).ToString();
                CountPointsTb.Text = currentRogue._starpoints.ToString();
            }
            catch
            {
                MessageBox.Show("Выберите героя!", "Невозможно изменить", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ListSettings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                currentRogue = ListSettings.SelectedItem as MongoDB.Rogue;
                myLevelTb.Text = currentRogue._level.ToString();
                CountDexterityTb.Text = currentRogue._dexterity.ToString();
                CountInteligienceTb.Text = currentRogue._inteligence.ToString();
                CountPowerTb.Text = currentRogue._strenght.ToString();
                CountVitalityTb.Text = currentRogue._vitality.ToString();
                CountPointsTb.Text = currentRogue._starpoints.ToString();
            }
            catch
            {
                MessageBox.Show("Выберите героя!", "Невозможно изменить", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void SaveBt_Click(object sender, RoutedEventArgs e)
            {
                MongoDB.Rogue.UpdateRogue(currentRogue as Rogue);
                ListSettings.Items.Refresh();
            List<MongoDB.Rogue> list = MongoDB.Rogue.GetRogue(currentRogue);
            currentRogue._level = Convert.ToInt32(myLevelTb.Text);
            ListSettings.ItemsSource = list;
            DataContext = this;

        }

           
    }
}
