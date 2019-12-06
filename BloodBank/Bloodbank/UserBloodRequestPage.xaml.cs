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
    /// Interaction logic for UserBloodRequestPage.xaml
    /// </summary>
    public partial class UserBloodRequestPage : Page
    {
        string id = null, d_id = null;
        public UserBloodRequestPage(string id)
        {
            InitializeComponent();
            this.id = id;
            loadValues();
        }
        private void loadValues()
        {
            Database d = new Database();
            string query = "SELECT PH_NO, NAME FROM USER WHERE TYPE_OF_USER='68';";
            try
            {
                d.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        DList.Items.Add(dr.GetString(dr.GetOrdinal("NAME")));
                    }
                }
                else
                {
                    DList.Items.Add("No donors");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                d.closeConnection();
            }
        }
        private void onComboBoxClosed(object sender, EventArgs e)
        {
            Database d = new Database();
            string query = "SELECT PH_NO, NAME, B_GRP, EMAIL, LOCATION, CITY FROM USER WHERE NAME='" + DList.Text + "';";
            try
            {
                d.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if(dr.Read())
                    {
                        d_id = dr["PH_NO"].ToString();
                        D_Name.Text = dr.GetString(dr.GetOrdinal("NAME"));
                        B_grp.Text = dr.GetString(dr.GetOrdinal("B_GRP"));
                        Email.Text = dr.GetString(dr.GetOrdinal("EMAIL"));
                        Loc.Text = dr.GetString(dr.GetOrdinal("LOCATION"));
                        City.Text = dr.GetString(dr.GetOrdinal("CITY"));
                    }
                }
                else
                {
                    MessageBox.Show("Some intennal error occured\nPlease select the donor again");
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

        private void BloodRequest_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            Database d = new Database();
            string query = "INSERT INTO ORDERS(B_GRP,RECIP_ID,DONOR_ID,MI_ID,REQ_DATE,QUANTITY) VALUES(@B_GRP,@RECIP_ID,@DONOR_ID,@MI_ID,@REQ_DATE,@QUANTITY)";
            try
            {
                d.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                cmd.Parameters.AddWithValue("@B_GRP", B_grp.Text);
                cmd.Parameters.AddWithValue("@RECIP_ID",id);
                cmd.Parameters.AddWithValue("@DONOR_ID",d_id);
                cmd.Parameters.AddWithValue("@MI_ID","1");
                cmd.Parameters.AddWithValue("@REQ_DATE",System.DateTime.Now);
                cmd.Parameters.AddWithValue("@QUANTITY","1");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                d.closeConnection();
            }
            if (flag)
            {
                MessageBox.Show("Order placed successfully");
            }
        }
    }
}
