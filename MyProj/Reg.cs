using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace MyProj
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reg = 0;
            var con = MyProj.database.Instance();
            if (con.IsConnect())
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    string querry = " SELECT EXISTS(SELECT login, pass FROM login WHERE login = '" + textBox1.Text + "' AND pass = '" + textBox2.Text + "');";

                    using (var cmd = new MySqlCommand(querry, con.Connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (Convert.ToByte(reader[0].ToString()) == 0)
                            {
                                reg = 1;
                            }
                            else
                            {
                                MessageBox.Show("Уже существует пользователь с данными параметрами");
                            }
                        }
                        
                    }
                    if (reg == 1)
                    {
                        querry = "INSERT INTO login SET `login` = '" + textBox1.Text + "', `pass` = '" + textBox2.Text + "', `Фамилия_Имя_Отчество` = '" + textBox3.Text + "', `Адресс` = '" + textBox4.Text + "', `tel` = '" + textBox5.Text + "';";
                        using (var cmd = new MySqlCommand(querry, con.Connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Успешно зарегистрированы");

                    }
                }

                con.Close();
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                this.textBox5.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("База данных не подключена", "Ошибка");
            }
        }
    }
}
