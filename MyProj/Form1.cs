using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MyProj;

namespace MyProj
{
    public partial class Form1 : Form
    {
        int item_id = -1;
        string tablet = "";
        public Form1(int item, string table)
        {
            tablet = table;
            item_id = item;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string querry = "";
            if (this.button1.Text == "Изменить") 
            {
                querry = "UPDATE " + tablet + " SET";
                for (int i = 1; i <= 7; i++)
                {
                  Label l =  this.Controls["label" + (i).ToString()] as Label;
                    Label l2 = this.Controls["label" + (i+1).ToString()] as Label;
                    TextBox t = this.Controls["textBox" + (i).ToString()] as TextBox;
                    if (l.Visible == true) 
                    {
                        querry += " `" + l.Text + "` = '" + t.Text + "'";
                    }
                    if (i < 7 && l2.Visible == true) 
                    {
                        querry += ",";
                    }
                    
                }
                querry += " WHERE id = " + item_id + "";
                
            }
            if (this.button1.Text == "Добавить")
            {
                querry = "INSERT INTO " + tablet + " SET";
                for (int i = 1; i <= 7; i++)
                {
                    Label l = this.Controls["label" + (i).ToString()] as Label;
                    Label l2 = this.Controls["label" + (i + 1).ToString()] as Label;
                    TextBox t = this.Controls["textBox" + (i).ToString()] as TextBox;
                    if (l.Visible == true)
                    {
                        querry += " `" + l.Text + "` = '" + t.Text + "'";
                    }
                    if (i < 7 && l2.Visible == true)
                    {
                        querry += ",";
                    }

                }
                querry += ";";
            }



            
                var con = database.Instance();
            if (con.IsConnect())
            {

                
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(querry, con.Connection))
                {
                    cmd.ExecuteNonQuery();
                }


            }

            this.Close();
        }
    }
}
