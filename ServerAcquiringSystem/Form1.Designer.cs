using System.IO.Ports;

namespace InterFaceModul
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            port = new SerialPort("COM256", 9600, Parity.None, 8, StopBits.One);
            components = new System.ComponentModel.Container();
            toolTip = new ToolTip(components);
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button5 = new Button();
            button6 = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            textBox1 = new TextBox();
            groupBox4 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 128, 128);
            button4.Location = new Point(595, 63);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 3;
            button4.Text = "Удалить";
            toolTip.SetToolTip(button4, "Удалить клиента банка");
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Location = new Point(402, 63);
            button3.Name = "button3";
            button3.Size = new Size(145, 34);
            button3.TabIndex = 2;
            button3.Text = "Редактировать";
            toolTip.SetToolTip(button3, "Редактировать клиента банка");
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(232, 63);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 1;
            button2.Text = "Добавить";
            toolTip.SetToolTip(button2, "Добавить нового клиента банка");
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.PaleGreen;
            button1.Location = new Point(41, 63);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "Создать";
            toolTip.SetToolTip(button1, "Вывести всю базу данных");
            button1.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.Location = new Point(854, 611);
            button5.Name = "button5";
            button5.Size = new Size(147, 34);
            button5.TabIndex = 2;
            button5.Text = "Подробнее";
            toolTip.SetToolTip(button5, "Вывести всю базу данных");
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(192, 367);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 3;
            button6.Text = "Очистить";
            toolTip.SetToolTip(button6, "Очистить логи терминала");
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(553, 688);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(804, 145);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Функционал";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(553, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(804, 583);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Данные о клиентах";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(button6);
            groupBox3.Location = new Point(17, 190);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(508, 429);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Логирование терминала";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 30);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(474, 331);
            textBox1.TabIndex = 0;
            textBox1.WordWrap = false;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Location = new Point(12, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(513, 126);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Статус терминала";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(18, 75);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(141, 29);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(141, 29);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 950);
            Controls.Add(button5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Server";
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ToolTip toolTip;
        private TextBox textBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private System.Windows.Forms.Timer timer1;
    }
}
