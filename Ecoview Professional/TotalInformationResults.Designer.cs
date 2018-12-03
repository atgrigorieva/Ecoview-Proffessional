namespace Ecoview_Professional
{
    partial class TotalInformationResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotalInformationResults));
            this.Description = new System.Windows.Forms.TextBox();
            this.ND = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Opt_dlin_cuvet = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Up = new System.Windows.Forms.TextBox();
            this.Down = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Veshestvo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Direction = new System.Windows.Forms.Label();
            this.Ispolnitel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(6, 20);
            this.Description.MaxLength = 255;
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(595, 20);
            this.Description.TabIndex = 1;
            this.Description.TextChanged += new System.EventHandler(this.Description_TextChanged);
            // 
            // ND
            // 
            this.ND.Location = new System.Drawing.Point(319, 286);
            this.ND.MaxLength = 255;
            this.ND.Name = "ND";
            this.ND.Size = new System.Drawing.Size(284, 20);
            this.ND.TabIndex = 149;
            this.ND.TextChanged += new System.EventHandler(this.ND_TextChanged);
            this.ND.Leave += new System.EventHandler(this.ND_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(316, 270);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 150;
            this.label15.Text = "Методика измерений";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(167, 300);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(126, 20);
            this.textBox4.TabIndex = 147;
            this.textBox4.Text = "0,00";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            this.textBox4.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 300);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(144, 13);
            this.label19.TabIndex = 148;
            this.label19.Text = "Погрешность методики (%)";
            // 
            // Opt_dlin_cuvet
            // 
            this.Opt_dlin_cuvet.FormattingEnabled = true;
            this.Opt_dlin_cuvet.Items.AddRange(new object[] {
            "нет",
            "1 мм",
            "3 мм",
            "5 мм",
            "10 мм",
            "20 мм",
            "30 мм",
            "50 мм",
            "100 мм"});
            this.Opt_dlin_cuvet.Location = new System.Drawing.Point(167, 264);
            this.Opt_dlin_cuvet.Name = "Opt_dlin_cuvet";
            this.Opt_dlin_cuvet.Size = new System.Drawing.Size(127, 21);
            this.Opt_dlin_cuvet.TabIndex = 145;
            this.Opt_dlin_cuvet.Leave += new System.EventHandler(this.Opt_dlin_cuvet_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 13);
            this.label12.TabIndex = 146;
            this.label12.Text = "Оптическая длина кюветы";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Нижняя";
            // 
            // Up
            // 
            this.Up.Location = new System.Drawing.Point(88, 50);
            this.Up.MaxLength = 255;
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(200, 20);
            this.Up.TabIndex = 10;
            this.Up.Text = "0,00";
            this.Up.TextChanged += new System.EventHandler(this.Up_TextChanged);
            this.Up.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Up_KeyPress);
            this.Up.Leave += new System.EventHandler(this.Up_Leave);
            // 
            // Down
            // 
            this.Down.Location = new System.Drawing.Point(88, 19);
            this.Down.MaxLength = 255;
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(199, 20);
            this.Down.TabIndex = 9;
            this.Down.Text = "0,00";
            this.Down.TextChanged += new System.EventHandler(this.Down_TextChanged);
            this.Down.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Down_KeyPress);
            this.Down.Leave += new System.EventHandler(this.Down_Leave);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.Description);
            this.groupBox7.Location = new System.Drawing.Point(9, 83);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(613, 49);
            this.groupBox7.TabIndex = 151;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Градуировка";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.Up);
            this.groupBox8.Controls.Add(this.Down);
            this.groupBox8.Location = new System.Drawing.Point(6, 175);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(301, 76);
            this.groupBox8.TabIndex = 144;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Граница обнаружения";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Верхняя";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(404, 182);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(202, 20);
            this.numericUpDown1.TabIndex = 141;
            this.numericUpDown1.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 143;
            this.label3.Text = "Срок действия";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(406, 149);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 142;
            this.label4.Text = "Дата создания";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "* Все поля обязательны для сохранения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 27);
            this.button1.TabIndex = 138;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Veshestvo
            // 
            this.Veshestvo.Location = new System.Drawing.Point(94, 149);
            this.Veshestvo.MaxLength = 255;
            this.Veshestvo.Name = "Veshestvo";
            this.Veshestvo.Size = new System.Drawing.Size(199, 20);
            this.Veshestvo.TabIndex = 136;
            this.Veshestvo.TextChanged += new System.EventHandler(this.Veshestvo_TextChanged);
            this.Veshestvo.Leave += new System.EventHandler(this.Veshestvo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 137;
            this.label1.Text = "Вещество";
            // 
            // code
            // 
            this.code.AutoSize = true;
            this.code.Location = new System.Drawing.Point(316, 216);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(251, 13);
            this.code.TabIndex = 135;
            this.code.Text = "Идентификационный номер (код) исследования";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(319, 232);
            this.textBox2.MaxLength = 255;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(284, 20);
            this.textBox2.TabIndex = 134;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // Direction
            // 
            this.Direction.AutoSize = true;
            this.Direction.Location = new System.Drawing.Point(320, 333);
            this.Direction.Name = "Direction";
            this.Direction.Size = new System.Drawing.Size(78, 13);
            this.Direction.TabIndex = 133;
            this.Direction.Text = "Руководитель";
            // 
            // Ispolnitel
            // 
            this.Ispolnitel.Location = new System.Drawing.Point(94, 333);
            this.Ispolnitel.MaxLength = 255;
            this.Ispolnitel.Name = "Ispolnitel";
            this.Ispolnitel.Size = new System.Drawing.Size(199, 20);
            this.Ispolnitel.TabIndex = 130;
            this.Ispolnitel.TextChanged += new System.EventHandler(this.Ispolnitel_TextChanged);
            this.Ispolnitel.Leave += new System.EventHandler(this.Ispolnitel_Leave_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 132;
            this.label6.Text = "Исполнитель";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(404, 330);
            this.textBox1.MaxLength = 255;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 131;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Location = new System.Drawing.Point(9, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 48);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Измерение";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 19);
            this.textBox3.MaxLength = 255;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(598, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // TotalInformationResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 415);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ND);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.Opt_dlin_cuvet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Veshestvo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.code);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Direction);
            this.Controls.Add(this.Ispolnitel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TotalInformationResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Общие данные";
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Description;
        public System.Windows.Forms.TextBox ND;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.ComboBox Opt_dlin_cuvet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox Up;
        public System.Windows.Forms.TextBox Down;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox Veshestvo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label code;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Direction;
        public System.Windows.Forms.TextBox Ispolnitel;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox3;
    }
}