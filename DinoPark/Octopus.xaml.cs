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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dino_Park_2._0
{
    /// <summary>
    /// Логика взаимодействия для Octopus.xaml
    /// </summary>
    public partial class Octopus : UserControl
    {
        /// <summary>
        /// То, насколько пикселей сдвигается осьминожка при движении
        /// </summary>
        private const int speed = 5;
        public const int distanceFromDino = 150;

        /// <summary>
        /// Количество отнимаемых очков
        /// </summary>
        public const int danger = 10;

        TimeSpan interval = TimeSpan.FromMilliseconds(100);
        public Octopus()
        {
            InitializeComponent();
            autoMover.Tick += AutoMover_Tick;
            autoMover.Interval = interval;
        }

        /// <summary>
        /// Автоматическое передвижение осьминожки
        /// </summary>
        private void AutoMover_Tick(object sender, EventArgs e)
        {
            if (CollectableItems.seashells.Count == 0) { autoMover.Stop(); return; }
            if (autoMover.IsEnabled == false) return;

            Dino poorGreenDude = GamePlayground.playground.FindName("dino") as Dino;

            UserControl collectable = CollectableItems.seashells[0];
            for (int i = 1; i < CollectableItems.seashells.Count; i++) {
                if (collectable.CalculateDistance(this) > CollectableItems.seashells[i].CalculateDistance(this)) collectable = CollectableItems.seashells[i];
            }

            Thickness centreOctMargin = new Thickness(this.Margin.Left + this.ActualWidth / 2, this.Margin.Top + this.ActualHeight / 2, 0, 0);
            Thickness centreSeashellMargin = new Thickness(collectable.Margin.Left + collectable.ActualWidth / 2, collectable.Margin.Top + collectable.ActualHeight / 2, 0, 0);


            //движение к ракушке
            if (centreOctMargin.Top < centreSeashellMargin.Top) {
                if (LivingThing.Move(this, speed, Directions.Bottom)){ LivingThing.Move(this, speed + distanceFromDino, Directions.Top); Dino.takeBite(danger); }
            }
            if (centreOctMargin.Top > centreSeashellMargin.Top) {
                if (LivingThing.Move(this, speed, Directions.Top)) { LivingThing.Move(this, speed + distanceFromDino, Directions.Bottom); Dino.takeBite(danger); }
            }
            if (centreOctMargin.Left < centreSeashellMargin.Left) {
                if (LivingThing.Move(this, speed, Directions.Right)) { LivingThing.Move(this, speed + distanceFromDino, Directions.Left); Dino.takeBite(danger); }
            }
            if (centreOctMargin.Left > centreSeashellMargin.Left) {
                if (LivingThing.Move(this, speed, Directions.Left)) { LivingThing.Move(this, speed + distanceFromDino, Directions.Right); Dino.takeBite(danger); }
            }

            //поедание ракушки
            if ( collectable is Seashell seashell && seashell.IntersectsWith(this)) {
                seashell.respawn();
                GamePlayground.DecreasePoints(Seashell.value);
            }

        }

        DispatcherTimer autoMover = new DispatcherTimer(DispatcherPriority.Render);
        private void octopus_Loaded(object sender, RoutedEventArgs e)
        {

            autoMover.Start();
        }

        private void octopus_Unloaded(object sender, RoutedEventArgs e)
        {
            autoMover.Stop();
        }
    }
}
