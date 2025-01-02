using InterFaceModul.database.AppContext;
using InterFaceModul.Services;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace InterFaceModul
{
    public partial class Form1 : Form
    {
        LocalDbContext _context;
        DatabaseService databaseService;

        public Form1() //�����������
        {
            _context = new LocalDbContext();
            databaseService = new DatabaseService(_context);
            InitializeComponent();
            port = new SerialPort("COM256", 9600, Parity.None, 8, StopBits.One); //�������������� NULL
            port.ReadTimeout = 2000;
            timer1.Interval = 2000;
            timer1.Tick += Timer_Tick;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogMessage(string message)
        {
            textBox1.AppendText(DateTime.Now.ToString() + " " + message + Environment.NewLine);
            textBox1.SelectionStart = textBox1.Text.Length; //������ � ����� textbox � ����� ������. textBox1.Text.Length ���������� ���������� ���� ��������.
            textBox1.ScrollToCaret();  //������������ ����� ���, ����� ���� ����� ������� ������� ������� // � ����������� ������ � �����
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (port.IsOpen && port.BytesToRead > 0)
            {
                try
                {
                    string messageForServer = port.ReadLine();
                    LogMessage(messageForServer);
                    if (messageForServer == "ConnectServer\r")
                    {
                        Console.WriteLine("�������� ��������� Arduino: ConnectArduino");
                        port.WriteLine("ConnectArduino");
                    }
                    else if (messageForServer.StartsWith("transaction:"))
                    {
                        port.WriteLine(messageForServer);
                        string[] arrayTransaction = messageForServer.Replace("transaction:", "").Split(',');

                        if (port.ReadLine() == "Good\r" || arrayTransaction.Length > 0)
                        {
                            //���� ������
                        }
                    }
                }
                catch (TimeoutException)
                {
                    // ��������� �������� ��� ������
                    LogMessage("Timeout while reading from port.");
                }
                catch (Exception ex)
                {
                    LogMessage(ex.ToString());
                    LogMessage("������ �����");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                    LogMessage("���� ������");
                    timer1.Stop();
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.ToString());
                LogMessage("�� ������� ������� ����");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!port.IsOpen)
                {
                    port.Open();
                    LogMessage("���� ������");
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.ToString());
                LogMessage("�� ������� ������ ����");
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Form addedClient = new AddedClient(databaseService);
        //    addedClient.ShowDialog();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{

        //}

        private void EditButtonClick(object sender, EventArgs e)
        {
            Form addedClient = new AddedClient(databaseService, listBox1.SelectedIndex);
            addedClient.ShowDialog();
        }

        private void AddClientButtonClick(object sender, EventArgs e)
        {
            Form addedClient = new AddedClient(databaseService);

            addedClient.ShowDialog();
        }

        private void ReloadForm(object sender, EventArgs e)
        {
            //listBox1.BeginUpdate();

            ////    listBox1.DataSource = databaseService.GetAllClients();

            //listBox1.EndUpdate();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.BeginUpdate();

            var data = databaseService.GetAllClientsPass();
            foreach (var item in data)
            {
                listBox1.Items.Add(item);
            }

            listBox1.EndUpdate();
        }

        private void DoubleClickListBox(object sender, EventArgs e)
        {
            Form addedClient = new AddedClient(databaseService, listBox1.SelectedIndex);
            addedClient.ShowDialog();
        }
    }
}
