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
    /// Логика взаимодействия для ListOfHeroWizzard.xaml
    /// </summary>
    public partial class ListOfHeroWizzard : Page
    {
        public MongoDB.Wizard currentWizard = WizzardPage.currentWizard;
        public ListOfHeroWizzard()
        {
            int a = currentWizard._starpoints;
            InitializeComponent();
            List<MongoDB.Wizard> list = MongoDB.Wizard.GetWizard(currentWizard);
            ListSettings.ItemsSource = list;
            DataContext = this;
            myLevelTb.Text = ((a - (a % 1000)) / 1000).ToString();
            CountPointsTb.Text = currentWizard._starpoints.ToString();


        }
        private void AddPowerBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentWizard._starpoints > 0)
                {
                    currentWizard._strenght++;
                    currentWizard._starpoints--;
                    CountPowerTb.Text = currentWizard._strenght.ToString();
                    CountPointsTb.Text = currentWizard._starpoints.ToString();
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
                if (currentWizard._starpoints > 0)
                {
                    currentWizard._vitality++;
                    currentWizard._starpoints--;
                    CountVitalityTb.Text = currentWizard._vitality.ToString();
                    CountPointsTb.Text = currentWizard._starpoints.ToString();
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
                if (currentWizard._starpoints > 0)
                {
                    currentWizard._dexterity++;
                    currentWizard._starpoints--;
                    CountDexterityTb.Text = currentWizard._dexterity.ToString();
                    CountPointsTb.Text = currentWizard._starpoints.ToString();
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
                if (currentWizard._starpoints > 0)
                {
                    currentWizard._inteligence++;
                    currentWizard._starpoints--;
                    CountInteligienceTb.Text = currentWizard._inteligence.ToString();
                    CountPointsTb.Text = currentWizard._starpoints.ToString();
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
                currentWizard._starpoints += 500;
                myLevelTb.Text = ((currentWizard._starpoints - (currentWizard._starpoints % 1000)) / 1000).ToString();
                CountPointsTb.Text = currentWizard._starpoints.ToString();
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
                currentWizard = ListSettings.SelectedItem as Wizard;
                myLevelTb.Text = currentWizard._level.ToString();
                CountDexterityTb.Text = currentWizard._dexterity.ToString();
                CountInteligienceTb.Text = currentWizard._inteligence.ToString();
                CountPowerTb.Text = currentWizard._strenght.ToString();
                CountVitalityTb.Text = currentWizard._vitality.ToString();
                CountPointsTb.Text = currentWizard._starpoints.ToString();
            }
            catch
            {
                MessageBox.Show("Выберите героя!", "Невозможно изменить", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            Wizard.UpdateWizard(currentWizard as Wizard);
            ListSettings.Items.Refresh();
            List<Wizard> list = Wizard.GetWizard(currentWizard);
            currentWizard._level = Convert.ToInt32(myLevelTb.Text);
            ListSettings.ItemsSource = list;
            DataContext = this;

        }

        
    }
}
