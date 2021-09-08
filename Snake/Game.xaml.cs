using Snake.GameEntities;
using System;
using System.IO;
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
using System.Windows.Threading;

namespace Snake
{
    public partial class Game : Window
    {
        int elementSize = 30;
        int amountofColums;
        int amountofRows;
        double gameWidth;
        double gameHeight;
        Random randomTron;
        DispatcherTimer GetTimer;
        List<SnakeElement> snakeElements;
        SnakeElement tailBackup;
        Apple apple;
        Direction curDirection;
        int GameScore = 0;
        public string Player;
        public Game()
        {
            InitializeComponent();
            
        }

        protected override void OnContentRendered(EventArgs e)
        {
            InitializeGame();
            base.OnContentRendered(e);
        }

        void InitializeGame()
        {
            randomTron = new Random(DateTime.Now.Millisecond / DateTime.Now.Second);
            CreateTimer();
            DrawingPlace();
            CreateSnake();
            DrawSnake();
        }

        void ResetGame()
        {
            if(GetTimer != null)
            {
                GetTimer.Stop();
                GetTimer.Tick -= GameLoop;
                GetTimer = null;
            }
            if(GameWorld != null)
            {
                GameWorld.Children.Clear();
            }
            apple = null;
            if(snakeElements != null)
            {
                snakeElements.Clear();
                snakeElements = null;
            }  
            tailBackup = null;
        }

        private void DrawSnake()
        {
            foreach(var snakeElement in snakeElements)
            {
                if (!GameWorld.Children.Contains(snakeElement.UIElement))
                    GameWorld.Children.Add(snakeElement.UIElement);
                Canvas.SetLeft(snakeElement.UIElement, snakeElement.X);
                Canvas.SetTop(snakeElement.UIElement, snakeElement.Y);
            }
        }

        private void CreateSnake()
        {
            snakeElements = new List<SnakeElement>();
            snakeElements.Add(new SnakeElement(elementSize)
            {
                X = (amountofColums / 2) * elementSize,
                Y = (amountofRows / 2) * elementSize,
                isHead = true
            });
            curDirection = Direction.Right;
        }

        private void MoveSnake()
        {
            SnakeElement head = snakeElements[0];
            SnakeElement tail = snakeElements[snakeElements.Count - 1];
            tailBackup = new SnakeElement(elementSize)
            {
                X = tail.X,
                Y = tail.Y
            }; 

            head.isHead = false;
            tail.isHead = true;
            tail.X = head.X;
            tail.Y = head.Y;
            switch (curDirection)
            {
                case Direction.Right:
                    tail.X += elementSize;
                    break;

                case Direction.Left:
                    tail.X -= elementSize;
                    break;

                case Direction.Up:
                    tail.Y -= elementSize;
                    break;

                case Direction.Down:
                    tail.Y += elementSize;
                    break;
                default:
                    break;
            }
            snakeElements.RemoveAt(snakeElements.Count - 1);
            snakeElements.Insert(0, tail);
        }

        private void DrawingPlace()
        {
            gameWidth = GameWorld.ActualWidth;
            gameHeight = GameWorld.ActualHeight;

            amountofColums = (int)gameWidth / elementSize;
            amountofRows = (int)gameHeight / elementSize;
            for(int i = 0; i < amountofRows; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Green;
                line.X1 = 0;
                line.Y1 = i * elementSize;
                line.X2 = gameWidth;
                line.Y2 = i * elementSize;
                GameWorld.Children.Add(line);
            }
            for (int i = 0; i < amountofColums; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Green;
                line.X1 = i * elementSize;
                line.Y1 = 0;
                line.X2 = i * elementSize;
                line.Y2 = gameHeight;
                GameWorld.Children.Add(line);
            }
            Line line1 = new Line();
            line1.Stroke = Brushes.Green;
            line1.X1 = gameWidth;
            line1.Y1 = 0;
            line1.X2 = gameWidth;
            line1.Y2 = gameHeight;
            GameWorld.Children.Add(line1);
        }

        public void CreateTimer()
        {
            GetTimer = new DispatcherTimer();
            GetTimer.Interval = TimeSpan.FromSeconds(0.2);
            GetTimer.Tick += GameLoop;
            GetTimer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            DrawSnake();
            ShowScore();
            CreateApple();
            DrawApple();
     
        }

        private void ShowScore()
        {
            Score.Content = "Score: " + GameScore;
        }

        private void DrawApple()
        {
            if (apple == null)
                return;
            if (!GameWorld.Children.Contains(apple.UIElement))
                GameWorld.Children.Add(apple.UIElement);
            Canvas.SetLeft(apple.UIElement, apple.X);
            Canvas.SetTop(apple.UIElement, apple.Y); 
        }

        private void CreateApple()
        {
            if (apple != null)
                return;
            apple = new Apple(elementSize) { X = randomTron.Next(0, amountofColums) * elementSize, Y = randomTron.Next(0, amountofRows) * elementSize };
        }

        private void CheckCollision()
        {
            CheckCollisionWithWorldBounds();
            CheckCollisionWithSelf();
            CheckCollisionWithWorldItems();
        }

        private void CheckCollisionWithWorldBounds()
        {
            SnakeElement snakeHead = GetSnakeHead();
            if (snakeHead.X > gameWidth - elementSize || snakeHead.X < 0 || snakeHead.Y < 0 || snakeHead.Y > gameHeight - elementSize)
            {
                MessageBox.Show("Game Over!!!");
                EndGame();
                //ResetGame();
                //InitializeGame();
            }
        }

        async private void EndGame()
        {
            //File.WriteAllText("users.txt", Player);
            List<string> users = new List<string>();
            if (!File.Exists("users.txt"))
            {
                users.Add(Player + " " + GameScore);
                File.WriteAllLines("users.txt", users);
            }
            users = File.ReadLines("users.txt").ToList();
            /*foreach(var user in users)
            {
                var words1 = user.Split(' ');
                var words2 = (Player + " " + Score).Split(' ');
            }*/
            users.Add(Player + " " + GameScore);
            File.WriteAllLines("users.txt", users);
            if (GetTimer != null)
            {
                GetTimer.Stop();
                GetTimer.Tick -= GameLoop;
                GetTimer = null;
            }
            Restart res = new Restart();
            res.Show();
            await Task.Delay(100);
            this.Close();
        }

        private void CheckCollisionWithWorldItems()
        {
            if (apple == null)
                return;
            SnakeElement head = snakeElements[0];
            if(head.X == apple.X && head.Y == apple.Y)
            {    
                GameWorld.Children.Remove(apple.UIElement);
                GrowSnake();
                MakeFaster();
                GameScore += 10;
                apple = null;
            }
        }

        void MakeFaster()
        {
            if (GetTimer.Interval != TimeSpan.FromSeconds(0.1))
            {
                GetTimer.Interval -= TimeSpan.FromSeconds(0.1);
            }
        }
      
        private void GrowSnake()
        {
            SnakeElement oldTail = snakeElements[snakeElements.Count - 1];
            snakeElements.Add(new SnakeElement(elementSize) { X = tailBackup.X, Y = tailBackup.Y });
        }

        private void CheckCollisionWithSelf()
        {
            SnakeElement snakeHead = GetSnakeHead();
            bool hadCollision = false;
            if(snakeHead != null)
            {
                foreach (var snakeElement in snakeElements)
                {
                    if (!snakeElement.isHead)
                    {
                        if(snakeElement.X == snakeHead.X && snakeElement.Y == snakeHead.Y)
                        {
                            hadCollision = true;
                            break;
                        }
                        
                    }
                }
            }
            if (hadCollision)
            {
                MessageBox.Show("Game Over!!!");
                EndGame();
                //ResetGame();
                //InitializeGame();
            }
        }

        private SnakeElement GetSnakeHead()
        {
            SnakeElement snakeHead = null;
            foreach (var snakeElement in snakeElements)
            {
                if (snakeElement.isHead)
                {
                    snakeHead = snakeElement;
                    break;
                }
            }
            return snakeHead;
        }

        
        private void KeyIsReleased(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    if(curDirection != Direction.Down)
                        curDirection = Direction.Up;
                    break;

                case Key.A:
                    if (curDirection != Direction.Right)
                        curDirection = Direction.Left;
                    break;

                case Key.S:
                    if (curDirection != Direction.Up)
                        curDirection = Direction.Down;
                    break;

                case Key.D:
                    if (curDirection != Direction.Left)
                        curDirection = Direction.Right;
                    break;
            }
        }
    }
    enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
}
