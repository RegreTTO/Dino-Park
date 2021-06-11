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

namespace Dino_Park_2._0
{
    /// <summary>
    /// Логика взаимодействия для Mushroom.xaml
    /// </summary>
    public partial class Seashell : UserControl
    {
        public const int value = 2;
        public Seashell()
        {
            InitializeComponent();
        }
        public void respawn()
        {
            Grid gr = GamePlayground.playground.FindName("grid") as Grid;
            Thickness newShroomMargin = this.Margin;

        A:
            Random rnd = new Random();
            double left = (double)rnd.Next(0, (int)GamePlayground.playground.Width - 2 * (int)this.ActualWidth);
            double top = (double)rnd.Next(0, (int)GamePlayground.playground.Height - 2 * (int)this.ActualHeight);

            //если гриб заспавнится в динозавре, мы его перемещаем
            foreach (var obj in NotPassableObjects.solidObjects) {
                rnd = new Random();
                if (obj.GetType() != this.GetType()) {
                    while (left + this.ActualWidth > obj.Margin.Left && left < obj.Margin.Left + obj.ActualWidth) {
                        rnd = new Random();
                        left = (double)rnd.Next(0, (int)GamePlayground.playground.ActualWidth - (int)this.ActualWidth);

                    }

                    while (top + this.ActualHeight > obj.Margin.Top && top < obj.Margin.Top + obj.ActualHeight) {
                        rnd = new Random();
                        top = (double)rnd.Next(0, (int)GamePlayground.playground.ActualHeight - (int)this.ActualHeight);
                    }
                }
            }
            double right = (int)GamePlayground.playground.Width - 6 - left - ((int)this.ActualWidth + 10);
            double bottom = (int)GamePlayground.playground.Height - 29 - top - ((int)this.ActualHeight + 10);
            Thickness newThickness = new Thickness(left, top, right, bottom);

            //если ракушка заспавнилась ближе, чем за 100м от своего прошлого положения, то в спарте таких не любят и производят реролл
            if (this.CalculateDistance(new Seashell { Margin = newThickness }) < 200) {
                goto A;
            }
            this.Margin = newThickness;
        }
    }
}
