using System;
using System.Collections.Generic;
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

namespace WpfTestMailSender1
{
    /// <summary>
    /// Логика взаимодействия для SendExeption.xaml
    /// </summary>
    public partial class SendExeption : Window
    {
        public SendExeption()
        {
            InitializeComponent();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
