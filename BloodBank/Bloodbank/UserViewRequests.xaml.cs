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
    /// Interaction logic for UserViewRequests.xaml
    /// </summary>
    public partial class UserViewRequests : Page
    {
        string id;
        public UserViewRequests(string id)
        {
            InitializeComponent();
            this.id = id;
            loadValues();
        }
        private void loadValues()
        {
            Database d = new Database();
            try
            {
                string query = "SELECT PH_NO, NAME FROM USER WHERE TYPE_OF_USER='68';";
                d.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        RList.Items.Add(dr.GetString(dr.GetOrdinal("NAME")));
                    }
                }
                else
                {
                    RList.Items.Add("No donors");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                d.closeConnection();
            }
        }
        private void onD_ComboBoxClosed(object sender, EventArgs e)
        {
            BB_details.Visibility = Visibility.Hidden;
            R_details.Visibility = Visibility.Visible;
        }

        private void onBB_ComboBoxClosed(object sender, EventArgs e)
        {
            R_details.Visibility = Visibility.Hidden;
            BB_details.Visibility = Visibility.Visible;
        }

        private void DonateToD(object sender, RoutedEventArgs e)
        {

        }

        private void DonateBB(object sender, RoutedEventArgs e)
        {

        }
    }
}
