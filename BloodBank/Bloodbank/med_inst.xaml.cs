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
using System.Data.SQLite;

namespace BloodBank
{
    /// <summary>
    /// Interaction logic for med_inst.xaml
    /// </summary>
    public partial class med_inst : Page
    {
        public med_inst()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            if(name.Text.Equals("") || email.Text.Equals("") || ph_no.Text.Equals("") || website.Text.Equals("") || location.Text.Equals("") || city.Text.Equals("") || password.Text.Equals("") || confirm_password.Text.Equals(""))
            {
                passError.Visibility = Visibility.Hidden;
                empty.Visibility = Visibility.Visible;
            }
            else if (!password.Text.Equals(confirm_password.Text))
            {
                empty.Visibility = Visibility.Hidden;
                passError.Visibility = Visibility.Visible;
            }
            else
            {
                char t = 'H';
                string[] q = type.SelectedItem.ToString().Split(':');
                string a = q[1].Trim();
                if ("Hospital".Equals(a))
                {
                    t = 'H';
                }
                else if("Blood Bank".Equals(a))
                {
                    t = 'B';
                }
                Database d = new Database();
                bool flag = true;
                d.openConnection();
                string query = "INSERT INTO MED_INST(NAME,PHONE,LOCATION,CITY,WEBSITE,EMAIL,PASSWORD,TYPE_OF_MI) VALUES(@NAME,@PHONE,@LOCATION,@CITY,@WEBSITE,@EMAIL,@PASSWORD,@TYPE_OF_MI)";
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                cmd.Parameters.AddWithValue("@NAME", name.Text);
                cmd.Parameters.AddWithValue("@PHONE", ph_no.Text);
                cmd.Parameters.AddWithValue("@LOCATION", location.Text);
                cmd.Parameters.AddWithValue("@CITY", city.Text);
                cmd.Parameters.AddWithValue("@WEBSITE", website.Text);
                cmd.Parameters.AddWithValue("@EMAIL", email.Text);
                cmd.Parameters.AddWithValue("@PASSWORD", password.Text);
                cmd.Parameters.AddWithValue("@TYPE_OF_MI", t.ToString());
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    flag = false;
                }
                d.closeConnection();
                if(flag)
                {
                    MessageBox.Show(a + " added successfully");
                }
            }
        }
    }
}
