using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyProj;
using MySql;
using MySql.Data;

namespace MyProj
{

    public partial class controlPanel : Form
    {
        private Form mf = new mainform();
        private int User_Id = 0;
        private int is_admin = 0;
        string addr = "";
        string table = "";
        string fio = "";
        string tel = "";
        public controlPanel(Form f, string login)
        {
            mf = f;
            login = login;

            var con = MyProj.database.Instance();
            if (con.IsConnect())
            {
                string querry = "SELECT * from login where login = '" + login + "' ";

                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(querry, con.Connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {

                        reader.Read();
                        User_Id = Convert.ToInt32(reader[0].ToString());
                        if (reader[5].ToString() == "True")
                            is_admin = 1;
                        else
                            is_admin = 0;
                        fio = reader[3].ToString();
                        addr = reader[4].ToString();
                        tel = reader[6].ToString();

                    }
                }

            }

            InitializeComponent();
            if (is_admin == 0)

            {
                this.comboBox1.Visible = false;
                this.Add.Visible = false;
                this.Delete.Visible = false;
                this.Edit.Visible = false;
            }
        }

        private void updateGrid(string table)
        {
            var con = database.Instance();
            if (con.IsConnect())
            {
                string query = "SELECT * FROM " + table + "";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con.Connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        this.dataGridView1.DataSource = dt;
                        foreach (DataGridViewColumn col in this.dataGridView1.Columns)
                        {
                            col.Width = 140;
                        }

                    }

                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }
        private void controlPanel_Load(object sender, EventArgs e)
        {
            updateGrid("tovari");
            comboBox1.SelectedIndex = 0;

        }

        private void controlPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.User_Id != 0)
                Application.Exit();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {

            mf.Show();
            this.dataGridView1.DataSource = null;
            this.User_Id = 0;
            fio = "";
            addr = "";
            tel = "";
            this.Close();

        }

        private void DeleteRow(string table, int id)
        {
            var con = database.Instance();
            if (con.IsConnect())
            {
                string query = "DELETE FROM " + table + " WHERE " + table + ".id = " + id + "";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con.Connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    table = "tovari";
                    updateGrid("tovari");
                    this.Order.Enabled = true;
                    break;
                case 1:
                    updateGrid("zakazi");
                    table = "zakazi";
                    this.Order.Enabled = false;
                    break;
                case 2:
                    table = "login";
                    updateGrid("login");
                    this.Order.Enabled = false;
                    break;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Add.Visible = false;
            }
            else
            {
                if (is_admin == 1)
                    Add.Visible = true;
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    DeleteRow(table, Convert.ToInt32(row.Cells[0].Value.ToString()));

                }
            }
            updateGrid(table);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                            {

                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;

                }
            }
        }

        private void Order_Click(object sender, EventArgs e)
        {
            int price = 0;
            string oplata = "";
            if (radioButton1.Checked)
            {
                oplata = "Наличные";
            }
            else
            {
                oplata = "Безнал";
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (Convert.ToInt32(row.Cells[4].Value) <= 0)
                    {
                        MessageBox.Show("Товара: " + row.Cells[2].Value.ToString() + ", Нет в наличии ");
                        continue;
                    }
                    var con = database.Instance();
                    if (con.IsConnect())
                    {

                        string query = "INSERT INTO zakazi (Название_товара, цена, оплата, ФИО_Заказчика, Адресс, Телефон) VALUES('" + row.Cells[3].Value.ToString() + "'," + Convert.ToDouble(row.Cells[5].Value.ToString()) + ", '" + oplata + "', '" + fio + "', '" + addr + "', '" + tel + "');\n UPDATE tovari SET `В наличии` = "+(Convert.ToInt32(row.Cells[4].Value) - 1)+" WHERE id = "+Convert.ToInt32(row.Cells[0].Value)+";";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con.Connection))
                        {
                            cmd.ExecuteNonQuery();
                            price += Convert.ToInt32(row.Cells[5].Value);

                        }

                    }
                }
                if (price != 0)
                    MessageBox.Show("Заказ на " + price + " рублей создан");

            }
            else
            {
                MessageBox.Show("Выберите товар");
            }
            updateGrid(table);
        }

        private void Edit_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form1 f = new Form1(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), table);
                f.Text = "Изменение";
                for (int i = 1; i <= 7; i++)
                {

                    Label label = f.Controls["label" + (i).ToString()] as Label;
                    TextBox textbox = f.Controls["textBox" + (i).ToString()] as TextBox;
                    if (i <= dataGridView1.ColumnCount - 1)
                    {

                        if (label != null)
                        {
                            label.Text = dataGridView1.Columns[i].Name;
                            if (dataGridView1.SelectedRows[0].Cells[i].Value.ToString() == "True")
                            {
                                textbox.Text = "1";
                            }
                            else if (dataGridView1.SelectedRows[0].Cells[i].Value.ToString() == "False")
                            {
                                textbox.Text = "0";
                            }
                            else
                            {
                                textbox.Text = dataGridView1.SelectedRows[0].Cells[i].Value.ToString();
                            }

                        }
                    }
                    else
                    {
                        label.Visible = false;
                        textbox.Visible = false;
                    }

                }
                Button b = f.Controls["button1"] as Button;
                b.Text = "Изменить";
                f.ShowDialog();
                updateGrid(table);
            }
            else
            {
                MessageBox.Show("Выберите один элемент");
            }

        }

        private void Add_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(Convert.ToInt32("-5"), table);
            f.Text = "Добавление";
            for (int i = 1; i <= 7; i++)
            {

                Label label = f.Controls["label" + (i).ToString()] as Label;
                TextBox textbox = f.Controls["textBox" + (i).ToString()] as TextBox;
                if (i <= dataGridView1.ColumnCount - 1)
                {

                    if (label != null)
                    {
                        label.Text = dataGridView1.Columns[i].Name;

                    }
                }
                else
                {
                    label.Visible = false;
                    textbox.Visible = false;
                }

            }
            Button b = f.Controls["button1"] as Button;
            b.Text = "Добавить";
            f.ShowDialog();
            updateGrid(table);
        }
    }
}