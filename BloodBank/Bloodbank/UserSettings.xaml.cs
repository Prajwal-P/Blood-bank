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
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : Page
    {
        string id;
        public UserSettings(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void changeLocation(object sender, RoutedEventArgs e)
        {
            chng_City_Grid.Visibility = Visibility.Collapsed;
            chng_Password_Grid.Visibility = Visibility.Collapsed;
            Thickness margin = chng_City_Button.Margin;
            margin.Top = 392;
            chng_City_Button.Margin = margin;
            margin = chng_Password_Button.Margin;
            margin.Top = 442;
            chng_Password_Button.Margin = margin;
            chng_Loc_Grid.Visibility = Visibility.Visible;
        }

        private void new_Loc_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_Loc.Text.Equals("New location"))
            {
                new_Loc.Clear();
                new_Loc.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void new_Loc_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_Loc.Text.Equals(""))
            {
                new_Loc.Foreground = new SolidColorBrush(Colors.Gray);
                new_Loc.Text = "New location";
            }
        }

        private void new_LocButton_Click(object sender, RoutedEventArgs e)
        {
            if (new_Loc.Text.Equals("New location"))
            {
                emptyLoc.Visibility = Visibility.Visible;
            }
            else
            {
                emptyLoc.Visibility = Visibility.Hidden;
                //TODO
            }
        }

        private void changeCity(object sender, RoutedEventArgs e)
        {
            chng_Loc_Grid.Visibility = Visibility.Collapsed;
            chng_Password_Grid.Visibility = Visibility.Hidden;
            Thickness margin = chng_City_Button.Margin;
            margin.Top = 72;
            chng_City_Button.Margin = margin;
            margin = chng_Password_Button.Margin;
            margin.Top = 444;
            chng_Password_Button.Margin = margin;
            chng_City_Grid.Visibility = Visibility.Visible;
        }

        private void new_City_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_City.Text.Equals("New city"))
            {
                new_City.Clear();
                new_City.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void new_City_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (new_City.Text.Equals(""))
            {
                new_City.Foreground = new SolidColorBrush(Colors.Gray);
                new_City.Text = "New city";
            }
        }

        private void new_CityButton_Click(object sender, RoutedEventArgs e)
        {
            if (new_City.Text.Equals("New city"))
            {
                emptyCity.Visibility = Visibility.Visible;
            }
            else
            {
                emptyCity.Visibility = Visibility.Hidden;
                //TODO
            }
        }

        private void changePassword(object sender, RoutedEventArgs e)
        {
            chng_Loc_Grid.Visibility = Visibility.Collapsed;
            chng_City_Grid.Visibility = Visibility.Collapsed;           
            Thickness margin = chng_City_Button.Margin;
            margin.Top = 72;
            chng_City_Button.Margin = margin;
            margin = chng_Password_Button.Margin;
            margin.Top = 124;
            chng_Password_Button.Margin=margin;
            chng_Password_Grid.Visibility = Visibility.Visible;
        }
        
        private void new_PassButton_Click(object sender, RoutedEventArgs e)
        {
            if(old_Pass.Password.Equals("") || new_Pass.Password.Equals("") || confirm_Pass.Password.Equals(""))
            {
                PasswordNotMatching.Visibility = Visibility.Hidden;
                invalidOldPassword.Visibility = Visibility.Hidden;
                emptyPassword.Visibility = Visibility.Visible;
            }
            else if(!new_Pass.Password.Equals(confirm_Pass.Password))
            {
                invalidOldPassword.Visibility = Visibility.Hidden;
                emptyPassword.Visibility = Visibility.Hidden;
                PasswordNotMatching.Visibility = Visibility.Visible;
            }
            else
            {

            }
        }
    }
}
