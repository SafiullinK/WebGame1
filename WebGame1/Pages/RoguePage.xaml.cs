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
using WebGame1.Units;

namespace WebGame1.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoguePage.xaml
    /// </summary>
    public partial class RoguePage : Page
    {
        public static MongoDB.Rogue currentRogue;
        public RoguePage()
        {
            InitializeComponent();
            RogueLv.ItemsSource = MongoDB.Rogue.GetAllRogue();
            DataContext = this;
        }

        private void RogueLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentRogue = RogueLv.SelectedItem as MongoDB.Rogue;
            NavigationService.Navigate(new ListOfHeroRogue());
        }
    }
}
