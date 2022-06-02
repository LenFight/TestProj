using MySql.Data.MySqlClient;
namespace MyProj
{
    public partial class mainform : Form
    {
        public bool connected = false;
        public mainform()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           var con = MyProj.database.Instance();
            {
                if (con.IsConnect())
                {
                    this.bdcon.Text = "База данных подключена";
                    this.bdcon.ForeColor = Color.Green;
                    connected = true;

                }
                else
                {
                    this.bdcon.Text = "База данных не подключена";
                    this.bdcon.ForeColor = Color.Red;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte auth = 0;
            var con = MyProj.database.Instance();
            if (con.IsConnect())
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    string querry = " SELECT EXISTS(SELECT login, pass FROM login WHERE login = '" + textBox1.Text + "' AND pass = '" + textBox2.Text + "');";

                    using (var cmd = new MySqlCommand(querry, con.Connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            auth = Convert.ToByte(reader[0].ToString());
                            reader.Close();
                        }
                        if (Convert.ToByte(auth) == 1)
                        {
                            Form f = new controlPanel(this, textBox1.Text);
                            this.Hide();
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("Не найдено пользователя с такими параметрами");
                        }
                        
                    }
                }

                con.Close();
                this.textBox1.Clear();
                this.textBox2.Clear();
            }
            else
            {
                MessageBox.Show("База данных не подключена", "Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reg f = new Reg();
            f.ShowDialog();
        }
    }
}