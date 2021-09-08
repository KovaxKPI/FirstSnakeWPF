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

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для Restart.xaml
    /// </summary>
    public partial class Restart : Window
    {
        public Restart()
        {
            InitializeComponent();
        }

        async private void Restart_Click(object sender, RoutedEventArgs e)
        {
            PreGame pregame = new PreGame();
            pregame.Show();
            await Task.Delay(100);
            this.Close();
        }

        async private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            await Task.Delay(100);
            this.Close();
        }
    }
}
