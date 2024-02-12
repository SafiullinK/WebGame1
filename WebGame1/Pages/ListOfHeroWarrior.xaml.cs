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
    /// Логика взаимодействия для ListOfHeroWarrior.xaml
    /// </summary>
    public partial class ListOfHeroWarrior : Page
    {

        public MongoDB.Warrior currentWarrior = WariorPage.currentWarrior;
        public ListOfHeroWarrior()
        {
            int a = currentWarrior._starpoints;
            InitializeComponent();
            List<MongoDB.Warrior> list = MongoDB.Warrior.GetWarrior(currentWarrior);
            ListSettings.ItemsSource = list;
            DataContext = this;
            myLevelTb.Text = ((a - (a % 1000)) / 1000).ToString();
            CountPointsTb.Text = currentWarrior._starpoints.ToString();


        }
        private void AddPowerBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentWarrior._starpoints > 0)
                {
                    currentWarrior._strenght++;
                    currentWarrior._starpoints--;
                    CountPowerTb.Text = currentWarrior._strenght.ToString();
                    CountPointsTb.Text = currentWarrior._starpoints.ToString();
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
                if (currentWarrior._starpoints > 0)
                {
                    currentWarrior._vitality++;
                    currentWarrior._starpoints--;
                    CountVitalityTb.Text = currentWarrior._vitality.ToString();
                    CountPointsTb.Text = currentWarrior._starpoints.ToString();
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
                if (currentWarrior._starpoints > 0)
                {
                    currentWarrior._dexterity++;
                    currentWarrior._starpoints--;
                    CountDexterityTb.Text = currentWarrior._dexterity.ToString();
                    CountPointsTb.Text = currentWarrior._starpoints.ToString();
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
                if (currentWarrior._starpoints > 0)
                {
                    currentWarrior._inteligence++;
                    currentWarrior._starpoints--;
                    CountInteligienceTb.Text = currentWarrior._inteligence.ToString();
                    CountPointsTb.Text = currentWarrior._starpoints.ToString();
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
                currentWarrior._starpoints += 500;
                myLevelTb.Text = ((currentWarrior._starpoints - (currentWarrior._starpoints % 1000)) / 1000).ToString();
                CountPointsTb.Text = currentWarrior._starpoints.ToString();
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
                currentWarrior = ListSettings.SelectedItem as MongoDB.Warrior;
                myLevelTb.Text = currentWarrior._level.ToString();
                CountDexterityTb.Text = currentWarrior._dexterity.ToString();
                CountInteligienceTb.Text = currentWarrior._inteligence.ToString();
                CountPowerTb.Text = currentWarrior._strenght.ToString();
                CountVitalityTb.Text = currentWarrior._vitality.ToString();
                CountPointsTb.Text = currentWarrior._starpoints.ToString();
            }
            catch
            {
                MessageBox.Show("Выберите героя!", "Невозможно изменить", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            MongoDB.Warrior.UpdateWarrior(currentWarrior as Warrior);
            ListSettings.Items.Refresh();
            List<MongoDB.Warrior> list = MongoDB.Warrior.GetWarrior(currentWarrior);
            currentWarrior._level = Convert.ToInt32(myLevelTb.Text);
            ListSettings.ItemsSource = list;
            DataContext = this;

        }

        
    }
}

