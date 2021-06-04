using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeaTimer
{
    /// <summary>
    /// Логика взаимодействия для Normal_Mode.xaml
    /// </summary>
    public partial class Normal_Mode : Window
    {
        public Normal_Mode()
        {
            InitializeComponent();
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        } //перетаскивание окна за любое место

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KillMePls.Kill();
        } //сомоубийство

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nmWindow.WindowState = WindowState.Minimized;
        } // сворачивает окно

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("tg://resolve?domain=Li_is");
            }
            catch
            {
                MessageBox.Show("Проблема, действие не может быть выполнено!", "Хмм, и почему оно все еще не работает, раньше работало...");
            }
        } //пытается открыть тг
    }
}
