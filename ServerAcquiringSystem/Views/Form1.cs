using InterFaceModul.database;
using InterFaceModul.database.Models;
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
            foreach (var client in data)
            {
                listBoxClients.Items.Add(client);
            }

        }

        private void LogMessage(string message)
        {
            LogMessageTextBox.AppendText(DateTime.Now.ToString() + " " + message + Environment.NewLine);
            LogMessageTextBox.SelectionStart = LogMessageTextBox.Text.Length; //курсор в конец textbox в конец текста. textBox1.Text.Length возвращает количество всех символов.
            LogMessageTextBox.ScrollToCaret();  //прокручивает текст так, чтобы была видна текущая позиция курсора // и перемешашет курсор в конец
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
                        Console.WriteLine("Отправка сообщения Arduino: ConnectArduino");
                        port.WriteLine("ConnectArduino");
                    }
                    else if (messageForServer.StartsWith("transaction:"))
                    {
                        port.WriteLine(messageForServer);
                        string[] arrayTransaction = messageForServer.Replace("transaction:", "").Split(',');

                        if (port.ReadLine() == "Good\r" && arrayTransaction.Length > 0)
                        {
                            string uid = arrayTransaction[0];
                            string pincode = arrayTransaction[1];
                            int price = int.Parse(arrayTransaction[2]);
                            string data = _databaseService.transaction(uid, pincode, price);
                            port.WriteLine(data); //added answer an display terminal
                            LogMessage(data);
                        }
                    }
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    LogMessage("Терминал не подключен");
                }
                catch (UnauthorizedAccessException ex)
                {
                    LogMessage("Терминал не подключен");
                }
                catch (TimeoutException)
                {
                    // Обработка таймаута при чтении
                    LogMessage("Timeout while reading from port.");
                }
                catch (Exception ex)
                {
                    //LogMessage(ex.ToString());
                    LogMessage("Ошибка порта");
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e) //активация окна главной формы для обновления списка клиентов
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
                    LogMessage("Порт закрыт");
                    timer1.Stop();
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                LogMessage("Терминал не подключен");
            }
            catch (UnauthorizedAccessException ex)
            {
                LogMessage("Терминал не подключен");
            }
            catch (Exception ex)
            {
                LogMessage(ex.ToString());
                LogMessage("Не удалось открыть порт");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!port.IsOpen)
                {
                    port.Open();
                    LogMessage("Порт открыт");
                    timer1.Start();
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                LogMessage("Терминал не подключен");
            }
            catch (UnauthorizedAccessException ex)
            {
                LogMessage("Терминал не подключен");
            }
            catch (Exception ex)
            {
                LogMessage(ex.ToString());
                LogMessage("Не удалось закрыт порт");
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

        private void DoubleClickListBox(object sender, EventArgs e) //двойное нажатие для редактирования клиента
        {
            if (listBoxClients.SelectedIndex != -1)
            {
                Form editClient = new AddedClient(_databaseService, listBoxClients.SelectedIndex);
                editClient.ShowDialog();
            };
        }

        private void DeleteClientButton_Click_1(object sender, EventArgs e) //кнопка удаления клиента 
        {
            if (listBoxClients.SelectedIndex != -1)
            {
                Person deletePerson = _databaseService.GetPersonById(listBoxClients.SelectedIndex); //получили кортеж из БД по айди
                _databaseService.Delete(deletePerson);
                listBoxClients.Items.Remove(listBoxClients.SelectedIndex);
                Form1_Activated(sender, e);
            };

        }
    }
}
