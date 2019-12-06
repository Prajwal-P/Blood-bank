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
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Window
    {
        string username, id;
        public UserDashboard(string id,string un)
        {
            InitializeComponent();
            username = un;
            this.id = id;
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
                    userDashboard.Content = new UserDashboardView(id, username);
                    break;
                case "blood":
                    userDashboard.Content = new UserBloodRequestPage(id);
                    break;
                case "orders": 
                    userDashboard.Content = new UserOrders();
                    break;
                case "settings":
                    userDashboard.Content = new UserSettings();
                    break;
                case "logout":
                    LoginPage login = new LoginPage();
                    this.Hide();
                    login.Show();
                    break;
                default: userDashboard.Content = new UserDashboardView(id, username);
                    break;
            }
        }
    }
}
