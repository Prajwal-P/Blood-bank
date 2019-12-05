﻿using System;
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
using System.Data;

namespace BloodBank
{
    /// <summary>
    /// Interaction logic for UserDashboardView.xaml
    /// </summary>
    public partial class UserDashboardView : Page
    {
        string id, username;
        public UserDashboardView(string id, string username)
        {
            string typ = null;
            InitializeComponent();
            this.id = id;
            this.username = username;
            name.Content = username;
            Database d = new Database();
            d.openConnection();
            string query = "SELECT * FROM USER WHERE PH_NO='" + id + "';";
            SQLiteCommand cmd = new SQLiteCommand(query, d.con);
            SQLiteDataReader result = cmd.ExecuteReader();
            try
            {
                if(result.HasRows)
                {
                    if(result.Read())
                    {
                        typ = result["TYPE_OF_USER"].ToString();
                        if (result["TYPE_OF_USER"].Equals("68"))
                            type.Content = "Donor";
                        else if (result["TYPE_OF_USER"].Equals("82"))
                            type.Content = "Recipient";
                        else
                            type.Content = "Invalid";
                    }
                }
                if (typ.Equals("68"))
                {
                    D.Visibility = Visibility.Visible;
                    query = "SELECT NAME, PHONE, LOCATION, CITY, WEBSITE, EMAIL FROM MED_INST WHERE TYPE_OF_MI='66'";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query,d.con);
                    DataTable dt = new DataTable("MED_INST");
                    da.Fill(dt);
                    if(dt.Rows.Count>0)
                    {
                        D_BB_NoData.Visibility = Visibility.Hidden;
                        D_BB_grid.Visibility = Visibility.Visible;
                        D_BBlist.ItemsSource = dt.DefaultView;
                    }
                    else
                    {
                        D_BB_grid.Visibility = Visibility.Hidden;
                        D_BB_NoData.Visibility = Visibility.Visible;
                    }
                }
                else if(typ.Equals("82"))
                {
                    R.Visibility = Visibility.Visible;
                    query = "SELECT NAME, PHONE, LOCATION, CITY, WEBSITE, EMAIL FROM MED_INST WHERE TYPE_OF_MI='66'";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, d.con);
                    DataTable dt = new DataTable("USER");
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        R_BB_NoData.Visibility = Visibility.Hidden;
                        R_BB_grid.Visibility = Visibility.Visible;
                        R_BBlist.ItemsSource = dt.DefaultView;
                    }
                    else
                    {
                        R_BB_grid.Visibility = Visibility.Hidden;
                        R_BB_NoData.Visibility = Visibility.Visible;
                    }
                    query = "SELECT NAME, EMAIL, LOCATION, CITY FROM USER WHERE TYPE_OF_USER='68' AND B_GRP='"+result["B_GRP"].ToString()+"';";
                    da = new SQLiteDataAdapter(query, d.con);
                    dt = new DataTable("USER");
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        R_D_NoData.Visibility = Visibility.Hidden;
                        R_D_grid.Visibility = Visibility.Visible;
                        Dlist.ItemsSource = dt.DefaultView;
                    }
                    else
                    {
                        R_D_grid.Visibility = Visibility.Hidden;
                        R_D_NoData.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    //list.Visibility = Visibility.Hidden;
                    //label.Content = "ERROR";
                    //noData.Visibility = Visibility.Visible;
                }
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            finally
            {
                d.closeConnection();
            }
        }
    }
}
