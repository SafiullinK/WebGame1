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
    /// Логика взаимодействия для WizzardPage.xaml
    /// </summary>
    public partial class WizzardPage : Page
    {
        public static MongoDB.Wizard currentWizard;
        public WizzardPage()
        {

            InitializeComponent();
            WizzardLv.ItemsSource = MongoDB.Wizard.GetWizards();
            DataContext = this;
        }

        private void RogueLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentWizard = WizzardLv.SelectedItem as MongoDB.Wizard;
            NavigationService.Navigate(new ListOfHeroWizzard());
        }
    }
}
