using InterFaceModul.database;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace InterFaceModul
{
    public partial class Form1 : Form
    {

        private AppDBContext _context;
        private DatabaseServise _databaseService;

        public Form1() //конструктор
        {
            AppDBContext context = new AppDBContext();
            _context = context;
            _databaseService = new DatabaseServise(_context);
            InitializeComponent();
            port = new SerialPort("COM256", 9600, Parity.None, 8, StopBits.One); //предупреждение NULL
            port.ReadTimeout = 2000;
            timer1.Interval = 2000;
            timer1.Tick += Timer_Tick;

            var data = _databaseService.GetAllClientsPass();
            foreach (var client in data) {
                listBoxClients.Items.Add(client);
            }
        }

        private void LogMessage(string message)
        {
            LogMessageTextBox.AppendText(DateTime.Now.ToString() + " " + message + Environment.NewLine);
            LogMessageTextBox.SelectionStart = LogMessageTextBox.Text.Length; //курсор в конец textbox в конец текста. textBox1.Text.Length возвращает количество всех символов.
            LogMessageTextBox.ScrollToCaret();  //прокручивает текст так, чтобы была видна текуща€ позици€ курсора // и перемешашет курсор в конец
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
                        Console.WriteLine("ќтправка сообщени€ Arduino: ConnectArduino");
                        port.WriteLine("ConnectArduino");
                    }
                    else if (messageForServer.StartsWith("transaction:"))
                    {
                        port.WriteLine(messageForServer);
                        string[] arrayTransaction = messageForServer.Replace("transaction:", "").Split(',');

                        if (port.ReadLine() == "Good\r" || arrayTransaction.Length > 0)
                        {
                            //база данных
                        }
                    }
                }
                catch (TimeoutException)
                {
                    // ќбработка таймаута при чтении
                    LogMessage("Timeout while reading from port.");
                }
                catch (Exception ex)
                {
                    LogMessage(ex.ToString());
                    LogMessage("ќшибка порта");
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e) //активаци€ окна главной формы дл€ обновлени€ списка клиентов
        {
            listBoxClients.Items.Clear();
            listBoxClients.BeginUpdate();

            var data = _databaseService.GetAllClientsPass();
            foreach (var item in data)
            {
                listBoxClients.Items.Add(item);
            }

            listBoxClients.EndUpdate();
        }

        private void clearLogButton_Click(object sender, EventArgs e)
        {
            LogMessageTextBox.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                    LogMessage("ѕорт закрыт");
                    timer1.Stop();
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.ToString());
                LogMessage("Ќе удалось открыть порт");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!port.IsOpen)
                {
                    port.Open();
                    LogMessage("ѕорт открыт");
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.ToString());
                LogMessage("Ќе удалось закрыт порт");
            }
        }

        private void addedClientButton_Click(object sender, EventArgs e) //добавление клиента
        {
            Form addedClient = new AddedClient(_databaseService);
            addedClient.ShowDialog();
        }

        private void EditClientButton_Click(object sender, EventArgs e) //редактирование клиента
        {
            if (listBoxClients.SelectedIndex != -1)
            {
                Form editClient = new AddedClient(_databaseService, listBoxClients.SelectedIndex);
                editClient.ShowDialog();
            }
        }

        private void DoubleClickListBox(object sender, EventArgs e) //двойное нажатие дл€ редактировани€ клиента
        {
            if (listBoxClients.SelectedIndex != -1)
            {
                Form editClient = new AddedClient(_databaseService, listBoxClients.SelectedIndex);
                editClient.ShowDialog();
            };
        }
    }
}
