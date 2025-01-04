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
            DeleteClientButton = new Button();
            EditClientButton = new Button();
            addedClientButton = new Button();
            clearLogButton = new Button();
            functionalGroupBox = new GroupBox();
            groupBox3 = new GroupBox();
            LogMessageTextBox = new TextBox();
            groupBox4 = new GroupBox();
            ONTerminal = new RadioButton();
            OFFTerminal = new RadioButton();
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
            listBoxClients = new ListBox();
            groupBox2 = new GroupBox();
            functionalGroupBox.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            InfoForClientGroupBox.SuspendLayout();
            infoForAccountClient.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // DeleteClientButton
            // 
            DeleteClientButton.BackColor = Color.FromArgb(255, 128, 128);
            DeleteClientButton.Location = new Point(364, 63);
            DeleteClientButton.Name = "DeleteClientButton";
            DeleteClientButton.Size = new Size(112, 34);
            DeleteClientButton.TabIndex = 3;
            DeleteClientButton.Text = "Удалить";
            toolTip.SetToolTip(DeleteClientButton, "Удалить клиента банка");
            DeleteClientButton.UseVisualStyleBackColor = false;
            DeleteClientButton.Click += DeleteClientButton_Click_1;
            // 
            // EditClientButton
            // 
            EditClientButton.Location = new Point(178, 63);
            EditClientButton.Name = "EditClientButton";
            EditClientButton.Size = new Size(145, 34);
            EditClientButton.TabIndex = 2;
            EditClientButton.Text = "Редактировать";
            toolTip.SetToolTip(EditClientButton, "Редактировать клиента банка");
            EditClientButton.UseVisualStyleBackColor = true;
            EditClientButton.Click += EditClientButton_Click;
            // 
            // addedClientButton
            // 
            addedClientButton.Location = new Point(22, 63);
            addedClientButton.Name = "addedClientButton";
            addedClientButton.Size = new Size(112, 34);
            addedClientButton.TabIndex = 1;
            addedClientButton.Text = "Добавить";
            toolTip.SetToolTip(addedClientButton, "Добавить нового клиента банка");
            addedClientButton.UseVisualStyleBackColor = true;
            addedClientButton.Click += addedClientButton_Click;
            // 
            // clearLogButton
            // 
            clearLogButton.Location = new Point(136, 372);
            clearLogButton.Name = "clearLogButton";
            clearLogButton.Size = new Size(112, 34);
            clearLogButton.TabIndex = 3;
            clearLogButton.Text = "Очистить";
            toolTip.SetToolTip(clearLogButton, "Очистить логи терминала");
            clearLogButton.UseVisualStyleBackColor = true;
            clearLogButton.Click += clearLogButton_Click;
            // 
            // functionalGroupBox
            // 
            functionalGroupBox.Controls.Add(DeleteClientButton);
            functionalGroupBox.Controls.Add(EditClientButton);
            functionalGroupBox.Controls.Add(addedClientButton);
            functionalGroupBox.Location = new Point(454, 611);
            functionalGroupBox.Name = "functionalGroupBox";
            functionalGroupBox.Size = new Size(492, 145);
            functionalGroupBox.TabIndex = 0;
            functionalGroupBox.TabStop = false;
            functionalGroupBox.Text = "Функционал";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(LogMessageTextBox);
            groupBox3.Controls.Add(clearLogButton);
            groupBox3.Location = new Point(17, 190);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(418, 415);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Логирование терминала";
            // 
            // LogMessageTextBox
            // 
            LogMessageTextBox.Location = new Point(13, 30);
            LogMessageTextBox.Multiline = true;
            LogMessageTextBox.Name = "LogMessageTextBox";
            LogMessageTextBox.ScrollBars = ScrollBars.Vertical;
            LogMessageTextBox.Size = new Size(374, 331);
            LogMessageTextBox.TabIndex = 0;
            LogMessageTextBox.WordWrap = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(ONTerminal);
            groupBox4.Controls.Add(OFFTerminal);
            groupBox4.Location = new Point(12, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(423, 126);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Статус терминала";
            // 
            // ONTerminal
            // 
            ONTerminal.AutoSize = true;
            ONTerminal.Location = new Point(18, 75);
            ONTerminal.Name = "ONTerminal";
            ONTerminal.Size = new Size(156, 29);
            ONTerminal.TabIndex = 1;
            ONTerminal.TabStop = true;
            ONTerminal.Text = "ВКЛ. терминал";
            ONTerminal.UseVisualStyleBackColor = true;
            ONTerminal.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // OFFTerminal
            // 
            OFFTerminal.AutoSize = true;
            OFFTerminal.Location = new Point(18, 40);
            OFFTerminal.Name = "OFFTerminal";
            OFFTerminal.Size = new Size(170, 29);
            OFFTerminal.TabIndex = 0;
            OFFTerminal.TabStop = true;
            OFFTerminal.Text = "ВЫКЛ. терминал";
            OFFTerminal.UseVisualStyleBackColor = true;
            OFFTerminal.CheckedChanged += radioButton1_CheckedChanged;
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
            InfoForClientGroupBox.Controls.Add(phoneLabel);
            InfoForClientGroupBox.Controls.Add(ageLabel);
            InfoForClientGroupBox.Controls.Add(DateOfBirthLabel);
            InfoForClientGroupBox.Controls.Add(AddressLabel);
            InfoForClientGroupBox.Controls.Add(pasportLabel);
            InfoForClientGroupBox.Controls.Add(INNLabel);
            InfoForClientGroupBox.Controls.Add(lastnameLabel);
            InfoForClientGroupBox.Controls.Add(nameLabel);
            InfoForClientGroupBox.Location = new Point(964, 37);
            InfoForClientGroupBox.Name = "InfoForClientGroupBox";
            InfoForClientGroupBox.Size = new Size(423, 568);
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
            middleNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            middleNameLabel.Location = new Point(20, 165);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new Size(93, 25);
            middleNameLabel.TabIndex = 26;
            middleNameLabel.Text = "Отчество";
            // 
            // email
            // 
            email.AutoSize = true;
            email.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            email.Location = new Point(24, 495);
            email.Name = "email";
            email.Size = new Size(58, 25);
            email.TabIndex = 24;
            email.Text = "email";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            phoneLabel.Location = new Point(24, 447);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(89, 25);
            phoneLabel.TabIndex = 14;
            phoneLabel.Text = "Телефон";
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ageLabel.Location = new Point(24, 400);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(82, 25);
            ageLabel.TabIndex = 6;
            ageLabel.Text = "Возраст";
            // 
            // DateOfBirthLabel
            // 
            DateOfBirthLabel.AutoSize = true;
            DateOfBirthLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DateOfBirthLabel.Location = new Point(24, 352);
            DateOfBirthLabel.Name = "DateOfBirthLabel";
            DateOfBirthLabel.Size = new Size(152, 25);
            DateOfBirthLabel.TabIndex = 5;
            DateOfBirthLabel.Text = "День рождения";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddressLabel.Location = new Point(24, 306);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(67, 25);
            AddressLabel.TabIndex = 4;
            AddressLabel.Text = "Адрес";
            // 
            // pasportLabel
            // 
            pasportLabel.AutoSize = true;
            pasportLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            pasportLabel.Location = new Point(24, 263);
            pasportLabel.Name = "pasportLabel";
            pasportLabel.Size = new Size(86, 25);
            pasportLabel.TabIndex = 3;
            pasportLabel.Text = "Паспорт";
            // 
            // INNLabel
            // 
            INNLabel.AutoSize = true;
            INNLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            INNLabel.Location = new Point(24, 218);
            INNLabel.Name = "INNLabel";
            INNLabel.Size = new Size(54, 25);
            INNLabel.TabIndex = 2;
            INNLabel.Text = "ИНН";
            // 
            // lastnameLabel
            // 
            lastnameLabel.AutoSize = true;
            lastnameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lastnameLabel.Location = new Point(20, 112);
            lastnameLabel.Name = "lastnameLabel";
            lastnameLabel.Size = new Size(94, 25);
            lastnameLabel.TabIndex = 1;
            lastnameLabel.Text = "Фамилия";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            nameLabel.Location = new Point(24, 64);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(50, 25);
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
            infoForAccountClient.Location = new Point(1407, 37);
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
            // listBoxClients
            // 
            listBoxClients.FormattingEnabled = true;
            listBoxClients.ItemHeight = 25;
            listBoxClients.Location = new Point(36, 30);
            listBoxClients.Name = "listBoxClients";
            listBoxClients.Size = new Size(431, 529);
            listBoxClients.TabIndex = 29;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBoxClients);
            groupBox2.Location = new Point(454, 37);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(492, 568);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Список клиентов";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1888, 784);
            Controls.Add(groupBox2);
            Controls.Add(infoForAccountClient);
            Controls.Add(InfoForClientGroupBox);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(functionalGroupBox);
            Name = "Form1";
            Text = "Server";
            Activated += Form1_Activated;
            functionalGroupBox.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            InfoForClientGroupBox.ResumeLayout(false);
            InfoForClientGroupBox.PerformLayout();
            infoForAccountClient.ResumeLayout(false);
            infoForAccountClient.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SerialPort port;
        private Button clearLogButton;
        private Button DeleteClientButton;
        private Button EditClientButton;
        private Button addedClientButton;
        private GroupBox functionalGroupBox;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ToolTip toolTip;
        private TextBox LogMessageTextBox;
        private RadioButton ONTerminal;
        private RadioButton OFFTerminal;
        private System.Windows.Forms.Timer timer1;
        private GroupBox InfoForClientGroupBox;
        private Label middleNameLabel;
        private Label email;
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
        private ListBox listBoxClients;
        private GroupBox groupBox2;
    }
}
