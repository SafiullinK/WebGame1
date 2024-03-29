﻿using MongoDB;
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
    /// Логика взаимодействия для WariorPage.xaml
    /// </summary>
    public partial class WariorPage : Page
    {
        public static MongoDB.Warrior currentWarrior;
        public WariorPage()
        {

            InitializeComponent();
            WarriorLv.ItemsSource = MongoDB.Warrior.GetWarriors();
            DataContext = this;
        }

        private void RogueLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentWarrior = WarriorLv.SelectedItem as MongoDB.Warrior;
            NavigationService.Navigate(new ListOfHeroWarrior());
        }
    }
}
