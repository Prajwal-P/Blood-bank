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
using System.Windows.Shapes;

namespace BloodBank
{
    /// <summary>
    /// Interaction logic for HosDashboard.xaml
    /// </summary>
    public partial class HosDashboard : Window
    {
        private string id, name, phone, location, city, website, email, type;

        public HosDashboard(
            string id,
            string name,
            string phone,
            string location,
            string city,
            string website,
            string email,
            string type)
        {
            InitializeComponent();
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.location = location;
            this.city = city;
            this.website = website;
            this.email = email;
            this.type = type;
            if (typ.Equals("68"))
            {
                ReqBlood.Visibility = Visibility.Collapsed;
            }
            else if (typ.Equals("82"))
            {
                ReqView.Visibility = Visibility.Collapsed;
            }
            userDashboard.Content = new UserDashboardView(id, username, mail, bgrp, loc, city, typ);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Minimise_Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            this.Hide();
            login.Show();
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            img.Visibility = Visibility.Collapsed;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            img.Visibility = Visibility.Visible;
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "home":
                    userDashboard.Content = new UserDashboardView(id, username, mail, bgrp, loc, city, typ);
                    break;
                case "ReqBlood":
                    userDashboard.Content = new UserBloodRequestPage(id, hos_id);
                    break;
                case "ReqView":
                    userDashboard.Content = new UserViewRequests(id);
                    break;
                case "orders":
                    userDashboard.Content = new UserOrders(id);
                    break;
                case "settings":
                    userDashboard.Content = new UserSettings(id);
                    break;
                case "logout":
                    LoginPage login = new LoginPage();
                    this.Hide();
                    login.Show();
                    break;
                default:
                    userDashboard.Content = new UserDashboardView(id, username, mail, bgrp, loc, city, typ);
                    break;
            }
        }
    }
}
