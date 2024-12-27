using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace InterFaceModul
{
    public partial class Form1 : Form
    {

        public Form1() //конструктор
        {
            InitializeComponent();
            port = new SerialPort("COM256", 9600, Parity.None, 8, StopBits.One); //предупреждение NULL
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
            textBox1.SelectionStart = textBox1.Text.Length; //курсор в конец textbox в конец текста. textBox1.Text.Length возвращает количество всех символов.
            textBox1.ScrollToCaret();  //прокручивает текст так, чтобы была видна текущая позиция курсора // и перемешашет курсор в конец
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

                        if (port.ReadLine() == "Good\r" || arrayTransaction.Length > 0)
                        {
                            //база данных
                        }
                    }
                }
                catch (TimeoutException)
                {
                    // Обработка таймаута при чтении
                    LogMessage("Timeout while reading from port.");
                }
                catch (Exception ex)
                {
                    LogMessage(ex.ToString());
                    LogMessage("Ошибка порта");
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
                    LogMessage("Порт закрыт");
                    timer1.Stop();
                }
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
            catch (Exception ex)
            {
                LogMessage(ex.ToString());
                LogMessage("Не удалось закрыт порт");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form addedClient = new AddedClient();
           addedClient.ShowDialog();
        }
    }
}
