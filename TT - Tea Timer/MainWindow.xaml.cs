using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TT___Tea_Timer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreloadStart();
        }

        public void PreloadStart()
        {
            string a = Directory.GetCurrentDirectory() + "\\" + "teatitle.data";
            if (File.Exists(a) == true)
            {
                teatitle.Text = File.ReadAllText(a);
            }
            else
            {
                teatitle.Text = "Чай остынет через:";
            }
        }
    }
}
