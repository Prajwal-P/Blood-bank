using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace BloodBank
{
    public class Database
    {
        public SQLiteConnection con;
        public Database()
        {
            if (!File.Exists("../../BloodBankDB.sqlite3"))
            {
                SQLiteConnection.CreateFile("../../BloodBankDB.sqlite3");
                con = new SQLiteConnection("Data Source=../../BloodBankDB.sqlite3;Version=3;");
                con.Open();
                string query = "CREATE TABLE MED_INST (MI_ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,	NAME CHAR(20) NOT NULL UNIQUE, PHONE NUMBER(10) NOT NULL UNIQUE, LOCATION CHAR(30) NOT NULL, CITY CHAR(30) NOT NULL, WEBSITE CHAR(30) NOT NULL, EMAIL CHAR(20) NOT NULL, PASSWORD CHAR(50) NOT NULL, TYPE_OF_MI CHAR(1));";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                query = "CREATE TABLE USER ( PH_NO NUMBER(10) PRIMARY KEY, NAME CHAR(20) NOT NULL UNIQUE, B_GRP CHAR(3) NOT NULL, EMAIL CHAR(20) NOT NULL UNIQUE, LOCATION CHAR(20) NOT NULL, CITY CHAR(30) NOT NULL, PASSWORD CHAR(50) NOT NULL, TYPE_OF_USER CHAR(1) NOT NULL DEFAULT 'R', MI_ID INTEGER, FOREIGN KEY(MI_ID) REFERENCES MED_INST(MI_ID) ON DELETE CASCADE);";
                cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                query = "CREATE TABLE STOCK (MI_ID INTEGER, B_GRP CHAR(10), QUANTITY INTEGER NOT NULL, RATE INTEGER NOT NULL, PRIMARY KEY(MI_ID, B_GRP), FOREIGN KEY(MI_ID) REFERENCES MED_INST(MI_ID) ON DELETE CASCADE);";
                cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                query = "CREATE TABLE DONOR (PH_NO NUMBER(10) NOT NULL, DOB DATE NOT NULL, WEIGHT NUMBER(2) NOT NULL, LAST_DONATION_DATE DATE NOT NULL, PRIMARY KEY(PH_NO, DOB), FOREIGN KEY (PH_NO) REFERENCES USER(PH_NO) ON DELETE CASCADE);";
                cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery(); query = "CREATE TABLE ORDERS (OR_ID INTEGER PRIMARY KEY AUTOINCREMENT, B_GRP CHAR(10) NOT NULL, RECIP_ID NUMBER(10) NOT  NULL, DONOR_ID NUMBER(10) NOT NULL, MI_ID INTEGER NOT NULL, REQ_DATE DATE NOT NULL, DEL_DATE DATE, QUANTITY INTEGER NOT NULL, FOREIGN KEY(RECIP_ID) REFERENCES USER(PH_NO) ON DELETE CASCADE, FOREIGN KEY(DONOR_ID) REFERENCES USER(PH_NO) ON DELETE CASCADE, FOREIGN KEY(MI_ID) REFERENCES MED_INST(MI_ID) ON DELETE CASCADE);";
                cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con = new SQLiteConnection("Data Source=../../BloodBankDB.sqlite3;Version=3;");
            }
        }
        public void openConnection()
        {
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
        }
        public void closeConnection()
        {
            if(con.State!=System.Data.ConnectionState.Closed)
            {
                con.Close();
            }
        }
    }
}
