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
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для Scoreboard.xaml
    /// </summary>
    public partial class Scoreboard : Window
    {
        List<List<string>> Leaders;
        public Scoreboard()
        {
            Leaders = new List<List<string>>();
            ParseUsers();
            InitializeComponent();
            drawBoard();
        }

        private void drawBoard()
        {
            if (Board_Stack != null) Board_Stack.Children.Clear();
            Thickness margin = new Thickness();
            Grid leader = new Grid()
            {
                Height = 80
            };
            margin.Left = 0;
            margin.Right = 1500;
            leader.Children.Add(new TextBlock()
            {
                Margin = margin,
                Width = 100,
                FontFamily = new FontFamily("Arial Rounded MT"),
                Foreground = Brushes.Black,
                FontSize = 60,
                FontStretch = FontStretches.Normal,
                FontStyle = FontStyles.Normal,
                FontWeight = FontWeights.Normal,
                Text = "#",
                TextAlignment = TextAlignment.Center
            });
            margin.Left = 105;
            margin.Right = 611;
            leader.Children.Add(new TextBlock()
            {
                Margin = margin,
                Width = 884,
                FontFamily = new FontFamily("Arial Rounded MT"),
                Foreground = Brushes.Black,
                FontSize = 60,
                FontStretch = FontStretches.Normal,
                FontStyle = FontStyles.Normal,
                FontWeight = FontWeights.Normal,
                Text = "Name",
                TextAlignment = TextAlignment.Center
            });
            margin.Left = 994;
            margin.Right = 330;
            leader.Children.Add(new TextBlock()
            {
                Margin = margin,
                Width = 300,
                FontFamily = new FontFamily("Arial Rounded MT"),
                Foreground = Brushes.Black,
                FontSize = 60,
                FontStretch = FontStretches.Normal,
                FontStyle = FontStyles.Normal,
                FontWeight = FontWeights.Normal,
                Text = "Original",
                TextAlignment = TextAlignment.Center
            });
            Board_Stack.Children.Add(leader);
            for (int i = 0; i < 10; i++)
            {
                leader = new Grid()
                {
                    Height = 80
                };
                margin.Left = 0;
                margin.Right = 1500;
                leader.Children.Add(new TextBlock()
                {
                    Margin = margin,
                    Width = 100,
                    FontFamily = new FontFamily("Arial Rounded MT"),
                    Foreground = Brushes.Black,
                    FontSize = 60,
                    FontStretch = FontStretches.Normal,
                    FontStyle = FontStyles.Normal,
                    FontWeight = FontWeights.Normal,
                    Text = (i + 1).ToString(),
                    TextAlignment = TextAlignment.Center
                });
                margin.Left = 105;
                margin.Right = 611;
                leader.Children.Add(new TextBlock()
                {
                    Margin = margin,
                    Width = 884,
                    FontFamily = new FontFamily("Arial Rounded MT"),
                    Foreground = Brushes.Black,
                    FontSize = 60,
                    FontStretch = FontStretches.Normal,
                    FontStyle = FontStyles.Normal,
                    FontWeight = FontWeights.Normal,
                    Text = i >= Leaders.Count ? "-" : Leaders[i][0],
                    TextAlignment = TextAlignment.Center
                });
                margin.Left = 994;
                margin.Right = 330;
                leader.Children.Add(new TextBlock()
                {
                    Margin = margin,
                    Width = 300,
                    FontFamily = new FontFamily("Arial Rounded MT"),
                    Foreground = Brushes.Black,
                    FontSize = 60,
                    FontStretch = FontStretches.Normal,
                    FontStyle = FontStyles.Normal,
                    FontWeight = FontWeights.Normal,
                    Text = i >= Leaders.Count ? "-" : Leaders[i][1],
                    TextAlignment = TextAlignment.Center
                });
                Board_Stack.Children.Add(leader);
            }
        }
        private void ParseUsers()
        {
            List<string> users = new List<string>();
            users = File.ReadLines("users.txt").ToList();
            foreach (var user in users)
            {
                Leaders.Add(ParseUser(user));
            }

        }
        private List<string> ParseUser(string user)
        {
            List<string> leader = new List<string>();
            var temp = user.Split(' ').ToList();
            String Score1 = temp.Last();
            temp.RemoveAt(temp.Count - 1);
            return new List<string>() { String.Join(" ", temp.ToArray()), Score1};
        }
        async private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            await Task.Delay(100);
            this.Close();
        }
    }
}
