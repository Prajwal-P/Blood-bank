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
    /// Interaction logic for user.xaml
    /// </summary>
    public partial class user : Page
    {
        public user()
        {
            InitializeComponent();
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text.Equals("") || email.Text.Equals("") || ph_no.Text.Equals("") || b_group.Text.Equals("") || location.Text.Equals("") || city.Text.Equals("") || password.Password.Equals("") || confirm_password.Password.Equals(""))
            {
                phNoError.Visibility = Visibility.Hidden;
                passError.Visibility = Visibility.Hidden;
                empty.Visibility = Visibility.Visible;
            }
            else if (!phNoCheck())
            {
                passError.Visibility = Visibility.Hidden;
                empty.Visibility = Visibility.Hidden;
                phNoError.Visibility = Visibility.Visible;
            }
            else if (!password.Password.Equals(confirm_password.Password))
            {
                phNoError.Visibility = Visibility.Hidden;
                empty.Visibility = Visibility.Hidden;
                passError.Visibility = Visibility.Visible;
            }
            else
            {
                char t = 'R';           
                if ("Donor".Equals(type.Text))
                {
                    t = 'D';
                }
                else if ("Recipient".Equals(type.Text))
                {
                    t = 'R';
                }
                Database d = new Database();
                bool flag = true;
                d.openConnection();
                string query = "INSERT INTO USER(PH_NO,NAME,B_GRP,EMAIL,LOCATION,CITY,PASSWORD,TYPE_OF_USER) VALUES(@PhNo,@NAME,@B_GRP,@EMAIL,@LOCATION,@CITY,@PASSWORD,@TYPE_OF_USER)";
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                cmd.Parameters.AddWithValue("@PhNo", ph_no.Text);
                cmd.Parameters.AddWithValue("@NAME", name.Text);                
                cmd.Parameters.AddWithValue("@B_GRP", b_group.Text);
                cmd.Parameters.AddWithValue("@EMAIL", email.Text);
                cmd.Parameters.AddWithValue("@LOCATION", location.Text);
                cmd.Parameters.AddWithValue("@CITY", city.Text);
                cmd.Parameters.AddWithValue("@PASSWORD", password.Password);
                cmd.Parameters.AddWithValue("@TYPE_OF_USER", t);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    flag = false;
                }
                finally
                {
                    d.closeConnection();
                }
                passError.Visibility = Visibility.Hidden;
                phNoError.Visibility = Visibility.Hidden;
                empty.Visibility = Visibility.Hidden;
                if (flag)
                {
                    MessageBox.Show(type.Text + " added successfully");
                }
            }
        }
        public bool phNoCheck()
        {
            bool flag = true;
            foreach (char i in ph_no.Text)
            {
                if (i > '9' || i < '0')
                    flag = false;
            }
            if (ph_no.Text.Length == 10 && flag)
                return true;
            else
                return false;
        }
    }
}
