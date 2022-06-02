namespace MyProj
{
    partial class controlPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Order = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 395);
            this.dataGridView1.TabIndex = 0;
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(1073, 224);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(195, 23);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Редактировать запись";
            this.Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(1073, 253);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(195, 23);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Удалить запись";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(1073, 384);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(195, 23);
            this.LogOut.TabIndex = 3;
            this.LogOut.Text = "Выйти из аккаунта";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(1073, 282);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(195, 23);
            this.Add.TabIndex = 4;
            this.Add.Text = "Добавить запись";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Order
            // 
            this.Order.Location = new System.Drawing.Point(1073, 12);
            this.Order.Name = "Order";
            this.Order.Size = new System.Drawing.Size(195, 23);
            this.Order.TabIndex = 6;
            this.Order.Text = "Заказать";
            this.Order.UseVisualStyleBackColor = true;
            this.Order.Click += new System.EventHandler(this.Order_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Товары",
            "Заказы",
            "Покупатели"});
            this.comboBox1.Location = new System.Drawing.Point(1073, 311);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 23);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(1073, 41);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(121, 19);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Наличная оплата";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(1073, 66);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(137, 19);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Безналичная оплата";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1073, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 23);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1138, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Поиск";
            // 
            // controlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1280, 429);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Order);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.dataGridView1);
            this.Name = "controlPanel";
            this.Text = "Главное окно";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.controlPanel_FormClosed);
            this.Load += new System.EventHandler(this.controlPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button Edit;
        private Button Delete;
        private Button LogOut;
        private Button Add;
        private Button Order;
        private ComboBox comboBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;
        private Label label1;
    }
}