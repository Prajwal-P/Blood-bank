using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        Database db = new Database();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(username.Text.Equals("Email") || password.Password.Equals(""))
            {
                inavlidLogin.Visibility = Visibility.Hidden;
                notFound.Visibility = Visibility.Hidden;
                empty.Visibility = Visibility.Visible;
            }
            else
            {
                Database d = new Database();
                d.openConnection();
                string query = "SELECT EMAIL,PASSWORD,NAME FROM USER WHERE EMAIL='" + username.Text + "';";
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                SQLiteDataReader result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        if (password.Password.Equals(result["PASSWORD"]))
                        {
                            inavlidLogin.Visibility = Visibility.Hidden;
                            empty.Visibility = Visibility.Hidden;
                            notFound.Visibility = Visibility.Hidden;
                            UserDashboard user = new UserDashboard(result["NAME"].ToString());
                            this.Hide();
                            user.Show();
                        }
                        else
                        {
                            empty.Visibility = Visibility.Hidden;
                            notFound.Visibility = Visibility.Hidden;
                            inavlidLogin.Visibility = Visibility.Visible;
                        }
                    }
                }
                else
                {
                    query = "SELECT EMAIL,PASSWORD,NAME FROM MED_INST WHERE EMAIL='" + username.Text + "';";
                    cmd = new SQLiteCommand(query, d.con);
                    result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        if (result.Read())
                        {
                            if (password.Password.Equals(result["PASSWORD"]))
                            {
                                inavlidLogin.Visibility = Visibility.Hidden;
                                empty.Visibility = Visibility.Hidden;
                                notFound.Visibility = Visibility.Hidden;
                                HosDashboard hos = new HosDashboard(result["NAME"].ToString());
                                this.Hide();
                                hos.Show();
                            }
                            else
                            {
                                empty.Visibility = Visibility.Hidden;
                                notFound.Visibility = Visibility.Hidden;
                                inavlidLogin.Visibility = Visibility.Visible;
                            }
                        }
                    }
                    else
                    {
                        inavlidLogin.Visibility = Visibility.Hidden;
                        empty.Visibility = Visibility.Hidden;
                        notFound.Visibility = Visibility.Visible;
                    }
                }
                d.closeConnection();
            }
            //if(username.Text.Equals("admin") && password.Password.Equals("admin"))
            //{
            //    inavlidLogin.Visibility = Visibility.Hidden;
            //    User user = new User();
            //    this.Hide();
            //    user.Show();
            //}
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
        private void username_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(username.Text.Equals("Email"))
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
                username.Text = "Email";
            }
        }
    }
}
