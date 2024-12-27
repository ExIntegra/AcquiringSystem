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
            components = new System.ComponentModel.Container();
            toolTip = new ToolTip(components);
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button5 = new Button();
            button6 = new Button();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            textBox1 = new TextBox();
            groupBox4 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            timer1 = new System.Windows.Forms.Timer(components);
            InfoForClientGroupBox = new GroupBox();
            emailOutput = new Label();
            phoneLabelOutput = new Label();
            ageLabelOtput = new Label();
            DateOfBirthLabelOutput = new Label();
            AddressLabelOutput = new Label();
            pasportLabelOtput = new Label();
            INNLabelOutput = new Label();
            middleNameLabelOutput = new Label();
            lastnameLabelOutput = new Label();
            nameLabelOutput = new Label();
            middleNameLabel = new Label();
            email = new Label();
            photoGroupBox = new GroupBox();
            phoneLabel = new Label();
            ageLabel = new Label();
            DateOfBirthLabel = new Label();
            AddressLabel = new Label();
            pasportLabel = new Label();
            INNLabel = new Label();
            lastnameLabel = new Label();
            nameLabel = new Label();
            infoForAccountClient = new GroupBox();
            pincodeLabelOutput = new Label();
            balanceLabelOutput = new Label();
            AccountLabelOutput = new Label();
            accounts = new GroupBox();
            pincodeLabel = new Label();
            balanceLabel = new Label();
            AccountLabel = new Label();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            InfoForClientGroupBox.SuspendLayout();
            infoForAccountClient.SuspendLayout();
            SuspendLayout();
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 128, 128);
            button4.Location = new Point(364, 63);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 3;
            button4.Text = "Удалить";
            toolTip.SetToolTip(button4, "Удалить клиента банка");
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Location = new Point(178, 63);
            button3.Name = "button3";
            button3.Size = new Size(145, 34);
            button3.TabIndex = 2;
            button3.Text = "Редактировать";
            toolTip.SetToolTip(button3, "Редактировать клиента банка");
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(22, 63);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 1;
            button2.Text = "Добавить";
            toolTip.SetToolTip(button2, "Добавить нового клиента банка");
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button5
            // 
            button5.Location = new Point(733, 621);
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
            groupBox1.Location = new Point(555, 661);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(501, 145);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Функционал";
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
            radioButton2.Size = new Size(156, 29);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "ВКЛ. терминал";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(170, 29);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "ВЫКЛ. терминал";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // InfoForClientGroupBox
            // 
            InfoForClientGroupBox.Controls.Add(emailOutput);
            InfoForClientGroupBox.Controls.Add(phoneLabelOutput);
            InfoForClientGroupBox.Controls.Add(ageLabelOtput);
            InfoForClientGroupBox.Controls.Add(DateOfBirthLabelOutput);
            InfoForClientGroupBox.Controls.Add(AddressLabelOutput);
            InfoForClientGroupBox.Controls.Add(pasportLabelOtput);
            InfoForClientGroupBox.Controls.Add(INNLabelOutput);
            InfoForClientGroupBox.Controls.Add(middleNameLabelOutput);
            InfoForClientGroupBox.Controls.Add(lastnameLabelOutput);
            InfoForClientGroupBox.Controls.Add(nameLabelOutput);
            InfoForClientGroupBox.Controls.Add(middleNameLabel);
            InfoForClientGroupBox.Controls.Add(email);
            InfoForClientGroupBox.Controls.Add(photoGroupBox);
            InfoForClientGroupBox.Controls.Add(phoneLabel);
            InfoForClientGroupBox.Controls.Add(ageLabel);
            InfoForClientGroupBox.Controls.Add(DateOfBirthLabel);
            InfoForClientGroupBox.Controls.Add(AddressLabel);
            InfoForClientGroupBox.Controls.Add(pasportLabel);
            InfoForClientGroupBox.Controls.Add(INNLabel);
            InfoForClientGroupBox.Controls.Add(lastnameLabel);
            InfoForClientGroupBox.Controls.Add(nameLabel);
            InfoForClientGroupBox.Location = new Point(553, 37);
            InfoForClientGroupBox.Name = "InfoForClientGroupBox";
            InfoForClientGroupBox.Size = new Size(503, 568);
            InfoForClientGroupBox.TabIndex = 6;
            InfoForClientGroupBox.TabStop = false;
            InfoForClientGroupBox.Text = "Данные о клиенте";
            // 
            // emailOutput
            // 
            emailOutput.AutoSize = true;
            emailOutput.Location = new Point(82, 495);
            emailOutput.Name = "emailOutput";
            emailOutput.Size = new Size(0, 25);
            emailOutput.TabIndex = 36;
            // 
            // phoneLabelOutput
            // 
            phoneLabelOutput.AutoSize = true;
            phoneLabelOutput.Location = new Point(105, 447);
            phoneLabelOutput.Name = "phoneLabelOutput";
            phoneLabelOutput.Size = new Size(0, 25);
            phoneLabelOutput.TabIndex = 35;
            // 
            // ageLabelOtput
            // 
            ageLabelOtput.AutoSize = true;
            ageLabelOtput.Location = new Point(106, 400);
            ageLabelOtput.Name = "ageLabelOtput";
            ageLabelOtput.Size = new Size(0, 25);
            ageLabelOtput.TabIndex = 34;
            // 
            // DateOfBirthLabelOutput
            // 
            DateOfBirthLabelOutput.AutoSize = true;
            DateOfBirthLabelOutput.Location = new Point(170, 352);
            DateOfBirthLabelOutput.Name = "DateOfBirthLabelOutput";
            DateOfBirthLabelOutput.Size = new Size(0, 25);
            DateOfBirthLabelOutput.TabIndex = 33;
            // 
            // AddressLabelOutput
            // 
            AddressLabelOutput.AutoSize = true;
            AddressLabelOutput.Location = new Point(92, 306);
            AddressLabelOutput.Name = "AddressLabelOutput";
            AddressLabelOutput.Size = new Size(0, 25);
            AddressLabelOutput.TabIndex = 32;
            // 
            // pasportLabelOtput
            // 
            pasportLabelOtput.AutoSize = true;
            pasportLabelOtput.Location = new Point(111, 263);
            pasportLabelOtput.Name = "pasportLabelOtput";
            pasportLabelOtput.Size = new Size(0, 25);
            pasportLabelOtput.TabIndex = 31;
            // 
            // INNLabelOutput
            // 
            INNLabelOutput.AutoSize = true;
            INNLabelOutput.Location = new Point(81, 218);
            INNLabelOutput.Name = "INNLabelOutput";
            INNLabelOutput.Size = new Size(0, 25);
            INNLabelOutput.TabIndex = 30;
            // 
            // middleNameLabelOutput
            // 
            middleNameLabelOutput.AutoSize = true;
            middleNameLabelOutput.Location = new Point(114, 165);
            middleNameLabelOutput.Name = "middleNameLabelOutput";
            middleNameLabelOutput.Size = new Size(0, 25);
            middleNameLabelOutput.TabIndex = 29;
            // 
            // lastnameLabelOutput
            // 
            lastnameLabelOutput.AutoSize = true;
            lastnameLabelOutput.Location = new Point(111, 112);
            lastnameLabelOutput.Name = "lastnameLabelOutput";
            lastnameLabelOutput.Size = new Size(0, 25);
            lastnameLabelOutput.TabIndex = 28;
            // 
            // nameLabelOutput
            // 
            nameLabelOutput.AutoSize = true;
            nameLabelOutput.Location = new Point(105, 66);
            nameLabelOutput.Name = "nameLabelOutput";
            nameLabelOutput.Size = new Size(0, 25);
            nameLabelOutput.TabIndex = 27;
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new Point(20, 165);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new Size(88, 25);
            middleNameLabel.TabIndex = 26;
            middleNameLabel.Text = "Отчество";
            // 
            // email
            // 
            email.AutoSize = true;
            email.Location = new Point(24, 495);
            email.Name = "email";
            email.Size = new Size(54, 25);
            email.TabIndex = 24;
            email.Text = "email";
            // 
            // photoGroupBox
            // 
            photoGroupBox.Location = new Point(355, 30);
            photoGroupBox.Name = "photoGroupBox";
            photoGroupBox.Size = new Size(142, 150);
            photoGroupBox.TabIndex = 16;
            photoGroupBox.TabStop = false;
            photoGroupBox.Text = "Фото";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(24, 447);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(81, 25);
            phoneLabel.TabIndex = 14;
            phoneLabel.Text = "Телефон";
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(24, 400);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(76, 25);
            ageLabel.TabIndex = 6;
            ageLabel.Text = "Возраст";
            // 
            // DateOfBirthLabel
            // 
            DateOfBirthLabel.AutoSize = true;
            DateOfBirthLabel.Location = new Point(24, 352);
            DateOfBirthLabel.Name = "DateOfBirthLabel";
            DateOfBirthLabel.Size = new Size(140, 25);
            DateOfBirthLabel.TabIndex = 5;
            DateOfBirthLabel.Text = "День рождения";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.Location = new Point(24, 306);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(62, 25);
            AddressLabel.TabIndex = 4;
            AddressLabel.Text = "Адрес";
            // 
            // pasportLabel
            // 
            pasportLabel.AutoSize = true;
            pasportLabel.Location = new Point(24, 263);
            pasportLabel.Name = "pasportLabel";
            pasportLabel.Size = new Size(81, 25);
            pasportLabel.TabIndex = 3;
            pasportLabel.Text = "Паспорт";
            // 
            // INNLabel
            // 
            INNLabel.AutoSize = true;
            INNLabel.Location = new Point(24, 218);
            INNLabel.Name = "INNLabel";
            INNLabel.Size = new Size(51, 25);
            INNLabel.TabIndex = 2;
            INNLabel.Text = "ИНН";
            // 
            // lastnameLabel
            // 
            lastnameLabel.AutoSize = true;
            lastnameLabel.Location = new Point(20, 112);
            lastnameLabel.Name = "lastnameLabel";
            lastnameLabel.Size = new Size(85, 25);
            lastnameLabel.TabIndex = 1;
            lastnameLabel.Text = "Фамилия";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(24, 64);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(47, 25);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя";
            // 
            // infoForAccountClient
            // 
            infoForAccountClient.Controls.Add(pincodeLabelOutput);
            infoForAccountClient.Controls.Add(balanceLabelOutput);
            infoForAccountClient.Controls.Add(AccountLabelOutput);
            infoForAccountClient.Controls.Add(accounts);
            infoForAccountClient.Controls.Add(pincodeLabel);
            infoForAccountClient.Controls.Add(balanceLabel);
            infoForAccountClient.Controls.Add(AccountLabel);
            infoForAccountClient.Location = new Point(1080, 37);
            infoForAccountClient.Name = "infoForAccountClient";
            infoForAccountClient.Size = new Size(477, 568);
            infoForAccountClient.TabIndex = 28;
            infoForAccountClient.TabStop = false;
            infoForAccountClient.Text = "Информация о счете";
            // 
            // pincodeLabelOutput
            // 
            pincodeLabelOutput.AutoSize = true;
            pincodeLabelOutput.Location = new Point(109, 138);
            pincodeLabelOutput.Name = "pincodeLabelOutput";
            pincodeLabelOutput.Size = new Size(0, 25);
            pincodeLabelOutput.TabIndex = 30;
            // 
            // balanceLabelOutput
            // 
            balanceLabelOutput.AutoSize = true;
            balanceLabelOutput.Location = new Point(109, 100);
            balanceLabelOutput.Name = "balanceLabelOutput";
            balanceLabelOutput.Size = new Size(0, 25);
            balanceLabelOutput.TabIndex = 29;
            // 
            // AccountLabelOutput
            // 
            AccountLabelOutput.AutoSize = true;
            AccountLabelOutput.Location = new Point(109, 66);
            AccountLabelOutput.Name = "AccountLabelOutput";
            AccountLabelOutput.Size = new Size(0, 25);
            AccountLabelOutput.TabIndex = 28;
            // 
            // accounts
            // 
            accounts.Location = new Point(36, 311);
            accounts.Name = "accounts";
            accounts.Size = new Size(421, 243);
            accounts.TabIndex = 4;
            accounts.TabStop = false;
            accounts.Text = "Другие счета:";
            // 
            // pincodeLabel
            // 
            pincodeLabel.AutoSize = true;
            pincodeLabel.Location = new Point(22, 138);
            pincodeLabel.Name = "pincodeLabel";
            pincodeLabel.Size = new Size(75, 25);
            pincodeLabel.TabIndex = 3;
            pincodeLabel.Text = "Пинкод";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new Point(24, 100);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new Size(67, 25);
            balanceLabel.TabIndex = 2;
            balanceLabel.Text = "Баланс";
            // 
            // AccountLabel
            // 
            AccountLabel.AutoSize = true;
            AccountLabel.Location = new Point(24, 60);
            AccountLabel.Name = "AccountLabel";
            AccountLabel.Size = new Size(49, 25);
            AccountLabel.TabIndex = 1;
            AccountLabel.Text = "Счет";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 950);
            Controls.Add(infoForAccountClient);
            Controls.Add(InfoForClientGroupBox);
            Controls.Add(button5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Server";
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            InfoForClientGroupBox.ResumeLayout(false);
            InfoForClientGroupBox.PerformLayout();
            infoForAccountClient.ResumeLayout(false);
            infoForAccountClient.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SerialPort port;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ToolTip toolTip;
        private TextBox textBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private System.Windows.Forms.Timer timer1;
        private GroupBox InfoForClientGroupBox;
        private Label middleNameLabel;
        private Label email;
        private GroupBox photoGroupBox;
        private Label phoneLabel;
        private Label ageLabel;
        private Label DateOfBirthLabel;
        private Label AddressLabel;
        private Label pasportLabel;
        private Label INNLabel;
        private Label lastnameLabel;
        private Label nameLabel;
        private Label INNLabelOutput;
        private Label middleNameLabelOutput;
        private Label lastnameLabelOutput;
        private Label nameLabelOutput;
        private GroupBox infoForAccountClient;
        private GroupBox accounts;
        private Label pincodeLabel;
        private Label balanceLabel;
        private Label AccountLabel;
        private Label emailOutput;
        private Label phoneLabelOutput;
        private Label ageLabelOtput;
        private Label DateOfBirthLabelOutput;
        private Label AddressLabelOutput;
        private Label pasportLabelOtput;
        private Label pincodeLabelOutput;
        private Label balanceLabelOutput;
        private Label AccountLabelOutput;
    }
}
