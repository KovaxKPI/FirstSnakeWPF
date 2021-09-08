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
    /// Логика взаимодействия для PreGame.xaml
    /// </summary>
    public partial class PreGame : Window
    {
        public PreGame()
        {
            InitializeComponent();
        }

        async private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            await Task.Delay(100);
            this.Close();
        }
        async private void One_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game() { Player = PlayerName.Text };
            game.Show();
            await Task.Delay(100);
            this.Close();
        }
    }
}
