using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
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
        DispatcherTimer timemachinealarms = new DispatcherTimer();
        DispatcherTimer timemachinealarmscolor = new DispatcherTimer();

        public bool alarmred = false;

        public MainWindow()
        {
            InitializeComponent();
            PreloadStart();
            Screen1Window();
            inputvalue.Focus();
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
            if (File.Exists("C:\\Windows\\Media\\Windows Unlock.wav") == false)
            {
                MessageBox.Show("Как так то? Как можно было потерять системный файл??? Найди его, а потом вернись!", "Файл звука для уведомления не найден!");
                Process.GetCurrentProcess().Kill();
            }

            string a = Directory.GetCurrentDirectory() + "\\" + "teatitle.data";
            
            if (File.Exists(a) == true)
            {
                string b = File.ReadAllText(a);
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
            AlarmsTimer();
            teatitle.Text = "Чай остыл!";
            //SystemSounds.Hand.Play();
            //MessageBox.Show("уведомление");
            //SystemSounds.Asterisk.Play();
        }

        private void timerstart_Click(object sender, RoutedEventArgs e)
        {
            Screen2Window();
            try
            {
                value = int.Parse(inputvalue.Text);
            }
            catch
            {
                value = 0;
            }
            

            if (value <= 0)
            {
                MessageBox.Show("Значение равно нулю" + "\n" + "Установлено значение 25", "Ошибка");
                value = 25;
            }

            valuetime.Text = value + "";

            progresstea.Value = 0;
            progresstea.Maximum = value;

            TimerProcess();
        }


        private void inputdata(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        public void AlarmsTimer()
        {
            timemachinealarms.Interval = TimeSpan.FromMilliseconds(1000);
            timemachinealarms.Tick += Alarms;
            timemachinealarms.Start();

            timemachinealarmscolor.Interval = TimeSpan.FromMilliseconds(250);
            timemachinealarmscolor.Tick += ColorSwith;
            timemachinealarmscolor.Start();
        }

        public void Alarms(object sender, EventArgs e)
        {
            SoundPlayer sound = new SoundPlayer("C:\\Windows\\Media\\Windows Unlock.wav");
            sound.Play();
        }

        public void ColorSwith(object sender, EventArgs e)
        {
            if (alarmred == true)
            {
                valuetime.Foreground = Brushes.Red;
                alarmred = false;
            }
            else if (alarmred == false)
            {
                alarmred = true;
                valuetime.Foreground = Brushes.White;
            }
        }
    }
}
