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
                string query = "SELECT NAME FROM USER WHERE PH_NO IN (SELECT DISTINCT RECIP_ID FROM ORDERS WHERE DONOR_ID='"+id+"');";
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
                query = "SELECT NAME FROM MED_INST WHERE TYPE_OF_MI='66';";
                d.openConnection();
                cmd = new SQLiteCommand(query, d.con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        BBList.Items.Add(dr.GetString(dr.GetOrdinal("NAME")));
                    }
                }
                else
                {
                    BBList.Items.Add("No BloodBanks");
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
        private void onR_ComboBoxClosed(object sender, EventArgs e)
        {
            BB_details.Visibility = Visibility.Hidden;
            R_details.Visibility = Visibility.Visible;
            Database d = new Database();
            string query = "SELECT PH_NO, NAME, B_GRP, EMAIL, LOCATION, CITY FROM USER WHERE NAME='" + RList.Text + "';";
            try
            {
                d.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        Ph_no.Text = dr["PH_NO"].ToString();
                        R_Name.Text = dr.GetString(dr.GetOrdinal("NAME"));
                        R_Bgrp.Text = dr.GetString(dr.GetOrdinal("B_GRP"));
                        R_Email.Text = dr.GetString(dr.GetOrdinal("EMAIL"));
                        R_Loc.Text = dr.GetString(dr.GetOrdinal("LOCATION"));
                        R_City.Text = dr.GetString(dr.GetOrdinal("CITY"));
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

        private void onBB_ComboBoxClosed(object sender, EventArgs e)
        {
            R_details.Visibility = Visibility.Hidden;
            BB_details.Visibility = Visibility.Visible;
            Database d = new Database();
            string query = "SELECT NAME, PHONE, WEBSITE, EMAIL, LOCATION, CITY FROM MED_INST WHERE NAME='" + BBList.Text + "'";
            try
            {
                d.openConnection();
                SQLiteCommand cmd = new SQLiteCommand(query, d.con);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        BB_Name.Text = dr["NAME"].ToString();
                        BB_Ph.Text = dr["PHONE"].ToString();
                        BB_Website.Text = dr.GetString(dr.GetOrdinal("WEBSITE"));
                        BB_Email.Text = dr.GetString(dr.GetOrdinal("EMAIL"));
                        BB_Loc.Text = dr.GetString(dr.GetOrdinal("LOCATION"));
                        BB_City.Text = dr.GetString(dr.GetOrdinal("CITY"));
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
    }
}
