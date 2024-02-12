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

namespace WebGame1.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectUnitPage.xaml
    /// </summary>
    public partial class SelectUnitPage : Page
    {
        public SelectUnitPage()
        {
            InitializeComponent();
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ВЫ ВЫБРАЛИ ВОИНА");
            NavigationService.Navigate(new WariorPage());
           //MongoDB.Warrior.CreateWarrior(new MongoDB.Warrior("Warrior1",30,30,250,15,15,80,10,10,50,25,25,100,20));
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ВЫ ВЫБРАЛИ РАЗБОЙНИКА");
            NavigationService.Navigate(new RoguePage());
            //MongoDB.Rogue.CreateRogue(new MongoDB.Rogue("TestRogue", 30, 30, 250, 15, 15, 80, 10, 10, 50, 25, 25, 100, 20));
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ВЫ ВЫБРАЛИ МАГА");
            NavigationService.Navigate(new WizzardPage());
            //MongoDB.Wizard.CreateWizard(new MongoDB.Wizard("Wizard2",15, 15, 45, 20, 20, 80, 35, 35, 250, 15, 15, 70,20));
        }
    }
}
