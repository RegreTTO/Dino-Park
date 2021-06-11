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
using System.Windows.Threading;

namespace Dino_Park_2._0
{
    /// <summary>
    /// Логика взаимодействия для GamePlayground.xaml
    /// </summary>
    public partial class GamePlayground : Window
    {
        public static Window playground;
        public static TextBlock scoreBlock;
        public static int currentScore = 0;
        public static ProgressBar HpBar;
        public static Canvas HpBox;
        public static Label HpValue;

        Window mainWindow = App.Current.MainWindow;
        public GamePlayground()
        {
            InitializeComponent();
            
        }

        //добавляет очки
        public static void AddPoints(int points)
        {
            currentScore += points;
            scoreBlock.Text = currentScore.ToString();
        }

        //убавляет очки
        public static void DecreasePoints(int points)
        {
            currentScore -= points;
            scoreBlock.Text = currentScore.ToString();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            independentMoving.Stop();
            mainWindow.Top = this.Top;
            mainWindow.Left = this.Left;
            mainWindow.Show();
        }

        int speed = 10;
        const int distanceFromOct = Octopus.distanceFromDino;

        bool up, down, left, right;
        private void dino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A) left = true;
            if (e.Key == Key.D) right = true;
            if (e.Key == Key.W) up = true;
            if (e.Key == Key.S) down = true;

        }
        private void dino_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A) left = false;
            if (e.Key == Key.D) right = false;
            if (e.Key == Key.W) up = false;
            if (e.Key == Key.S) down = false;
        }

        private void IndependentMoving_Tick(object sender, EventArgs e)
        {
            if (!independentMoving.IsEnabled) return;
            if (right) {
                if (LivingThing.Move(dino, speed, Directions.Right)) {
                    LivingThing.Move(dino, speed + distanceFromOct, Directions.Left);
                    Dino.takeBite(Octopus.danger);
                }
                hpBox.Move(speed, Directions.Right);
            }
            if (left) {
                if (LivingThing.Move(dino, speed, Directions.Left)) {
                    LivingThing.Move(dino, speed + distanceFromOct, Directions.Right);
                    Dino.takeBite(Octopus.danger);
                }
                hpBox.Move(speed, Directions.Left);
            }
            if (down) {
                if (LivingThing.Move(dino, speed, Directions.Bottom)) { LivingThing.Move(dino, speed + distanceFromOct, Directions.Top); Dino.takeBite(Octopus.danger); }
                hpBox.Move(speed, Directions.Bottom);
            }
            if (up) {
                if (LivingThing.Move(dino, speed, Directions.Top)) { LivingThing.Move(dino, speed + distanceFromOct, Directions.Bottom); Dino.takeBite(Octopus.danger); }
                hpBox.Move(speed, Directions.Top);
            }
            foreach (UserControl uc in CollectableItems.seashells) {
                if (uc is Seashell seashel && dino.IntersectsWith(seashel)) {
                    GamePlayground.AddPoints(Seashell.value);
                    seashel.respawn();
                }
            }
        }
        DispatcherTimer independentMoving = new DispatcherTimer(DispatcherPriority.Render);
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            playground = this;
            scoreBlock = Score;
            currentScore = 0;
            Score.Text = currentScore.ToString();
            hpBar.Value = Dino.hp;
            HpBar = hpBar;
            HpBox = hpBox;
            HpValue = hpLabel;

            independentMoving.Interval = TimeSpan.FromMilliseconds(100);
            independentMoving.Tick += IndependentMoving_Tick;
            independentMoving.Start();

            NotPassableObjects.solidObjects.Clear();
            NotPassableObjects.solidObjects.Add(octopus);
            NotPassableObjects.solidObjects.Add(dino);


            //добавление всех объектов в соответсвующие коллекции
            foreach (object obj in grid.Children) {
                if (obj is Seashell seashell) CollectableItems.seashells.Add(seashell);
                else if (obj is TextBlock block) NotPassableObjects.solidObjects.Add(block);

            }
        }


    }
}
