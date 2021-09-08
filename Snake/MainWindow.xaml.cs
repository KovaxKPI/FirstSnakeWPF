﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        async private void Play_Click(object sender, RoutedEventArgs e)
        {
            PreGame preGame = new PreGame();
            preGame.Show();
            await Task.Delay(100);
            this.Close();
        }

        async private void Score_Click(object sender, RoutedEventArgs e)
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.Show();
            await Task.Delay(100);
            this.Close();
        }
    }
}
