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

namespace BloodBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(username.Text.Equals("admin") && password.Password.Equals("admin"))
            {
                inavlidLogin.Visibility = Visibility.Hidden;
                User user = new User();
                this.Hide();
                user.Show();
            }
            else
            {
                inavlidLogin.Visibility = Visibility.Visible;
            }
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

        private void signUP_Click(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            this.Hide();
            signup.Show();
        }
        /* private void username_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
{
   if(username.Text.Equals("Phone Number"))
   {
       username.Clear();
       username.Foreground = new SolidColorBrush(Colors.Black);
   }
}

private void username_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
{
   if (username.Text.Equals(""))
   {
       username.Foreground = new SolidColorBrush(Colors.LightGray);
       username.Text = "Phone Number";
   }
} */
    }
}
