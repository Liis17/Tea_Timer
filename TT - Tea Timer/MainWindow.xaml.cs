using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TT___Tea_Timer
{
    public partial class MainWindow : Window
    {
        public int value = 0;

        DispatcherTimer timemachine = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            PreloadStart();
            Screen1Window();
        }

        public void Screen1Window()
        {
            screen1.Visibility = Visibility.Visible;
            screen2.Visibility = Visibility.Hidden;
            nwindow.Height = 250;
            nwindow.Width = 600;
        }

        public void Screen2Window()
        {
            screen1.Visibility = Visibility.Hidden;
            screen2.Visibility = Visibility.Visible;
            nwindow.Height = 350;
            nwindow.Width = 400;
        }

        public void PreloadStart()
        {
            string a = Directory.GetCurrentDirectory() + "\\" + "teatitle.data";
            string b = File.ReadAllText(a);
            if (File.Exists(a) == true)
            {
                if (b == "")
                {
                    MessageBox.Show("Файл Teatitle пуст", "Ошибка");
                    teatitle.Text = "Чай остынет через:";
                }
                else
                {
                    teatitle.Text = b;
                }
                
            }
            else
            {
                teatitle.Text = "Чай остынет через:";
            }
        }

        public void TimerProcess()
        {
            timemachine.Interval = TimeSpan.FromSeconds(1);
            timemachine.Tick += TimerFinish;
            timemachine.Start();
        }

        private void TimerFinish(object sender, EventArgs e)
        {
            value -= 1;
            progresstea.Value += 1;
            valuetime.Text = value + "";
            if (value <= 0)
            {
                timemachine.Stop();
                FinishNotification();
            }
            
        }

        public void FinishNotification()
        {
            MessageBox.Show("уведомление");
        }

        private void timerstart_Click(object sender, RoutedEventArgs e)
        {
            Screen2Window();

            value = int.Parse(inputvalue.Text);

            if (value <= 0)
            {
                MessageBox.Show("Значение меньше или равно нулю" + "\n" + "Установлено значение 25", "Ошибка");
                value = 25;
            }
            else
            {
                valuetime.Text = value + "";
            }
            

            progresstea.Value = 0;
            progresstea.Maximum = value;

            TimerProcess();
        }


        private void inputdata(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
