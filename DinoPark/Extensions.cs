using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;

namespace Dino_Park_2._0
{
    public static class Extensions
    {
        /// <summary>
        /// Коллизия для предметов или персонажей игры
        /// </summary>
        /// <param name="who"> Объект, у которого вызывается данный метод </param>
        /// <param name="with"> Объект, с которым происходит проверка коллизии</param>
        /// <returns></returns>
        public static bool IntersectsWith(this UserControl who, UserControl with)
        {
            if (with == new UserControl()) return false;
            Grid whoGrid = who.FindName("grid") as Grid;
            Grid withGrid = with.FindName("grid") as Grid;

            Thickness whoMargin = who.Margin;
            Thickness withMargin = with.Margin;

            foreach (var obj1 in whoGrid.Children) {
                foreach (var obj2 in withGrid.Children) {
                    if (obj1 is Rectangle rec1 && obj2 is Rectangle rec2) {
                        #region VariablesInitializing

                        // Количества строк и столбцов в объекте:
                        int columnsCount1 = whoGrid.ColumnDefinitions.Count;
                        int columnsCount2 = withGrid.ColumnDefinitions.Count;
                        int rowsCount1 = whoGrid.RowDefinitions.Count;
                        int rowsCount2 = withGrid.RowDefinitions.Count;

                        // Расположение куска в объекте по столбцам:
                        int col1 = Grid.GetColumn(rec1);
                        int col2 = Grid.GetColumn(rec2);
                        int colSpan1 = Grid.GetColumnSpan(rec1);
                        int colSpan2 = Grid.GetColumnSpan(rec2);

                        // Расположение куска в объекте по строкам:
                        int row1 = Grid.GetRow(rec1);
                        int row2 = Grid.GetRow(rec2);
                        int rowSpan1 = Grid.GetRowSpan(rec1);
                        int rowSpan2 = Grid.GetRowSpan(rec2);



                        // Ширина и высота каждого единичного прямоугольника:
                        double colsUnitSegment1 = who.ActualWidth / columnsCount1;
                        double colsUnitSegment2 = with.ActualWidth / columnsCount2;
                        double rowsUnitSegment1 = who.ActualHeight / rowsCount1;
                        double rowsUnitSegment2 = with.ActualHeight / rowsCount2;


                        #endregion

                        #region SearchingMargin

                        // Margin первого прямоугольника:
                        double right1 = (columnsCount1 - col1 - colSpan1) * colsUnitSegment1;
                        double left1 = (columnsCount1 - (columnsCount1 - col1)) * colsUnitSegment1;
                        double bottom1 = (rowsCount1 - row1 - rowSpan1) * rowsUnitSegment1;
                        double top1 = (rowsCount1 - (rowsCount1 - row1)) * rowsUnitSegment1;
                        double globalRight1 = whoMargin.Right + right1;
                        double globalLeft1 = whoMargin.Left + left1;
                        double globalBottom1 = whoMargin.Bottom + bottom1;
                        double globalTop1 = whoMargin.Top + top1;
                        Thickness whoThickness = new Thickness(globalLeft1, globalTop1, globalRight1, globalBottom1);

                        // Margin втрого прямоугольника:
                        double right2 = (columnsCount2 - col2 - colSpan2) * colsUnitSegment2;
                        double left2 = (columnsCount2 - (columnsCount2 - col2)) * colsUnitSegment2;
                        double bottom2 = (rowsCount2 - row2 - rowSpan2) * rowsUnitSegment2;
                        double top2 = (rowsCount2 - (rowsCount2 - row2)) * rowsUnitSegment2;
                        double globalRight2 = withMargin.Right + right2;
                        double globalLeft2 = withMargin.Left + left2;
                        double globalBottom2 = withMargin.Bottom + bottom2;
                        double globalTop2 = withMargin.Top + top2;
                        Thickness withThickness = new Thickness(globalLeft2, globalTop2, globalRight2, globalBottom2);

                        #endregion

                        #region CollisionChecking

                        bool hasVerticalCollision = whoThickness.Top + rec1.ActualHeight > withThickness.Top && whoThickness.Top < withThickness.Top + rec2.ActualHeight;
                        bool hasHorizontalCollision = whoThickness.Left + rec1.ActualWidth > withThickness.Left && whoThickness.Left < withThickness.Left + rec2.ActualWidth;
                        bool hasCollision = hasVerticalCollision && hasHorizontalCollision;

                        if (hasCollision) {
                            return true;
                        }

                        #endregion
                    }
                }
            }
            return false;
        }
        public static bool IntersectsWith(this UserControl who, FrameworkElement with)
        {
            if (with == new FrameworkElement()) return false;
            Grid whoGrid = who.FindName("grid") as Grid;

            Thickness whoMargin = who.Margin;
            Thickness withMargin = with.Margin;

            foreach (var obj1 in whoGrid.Children) {
                if (obj1 is Rectangle rec1) {
                    #region VariablesInitializing

                    // Количества строк и столбцов в объекте:
                    int columnsCount1 = whoGrid.ColumnDefinitions.Count;
                    int rowsCount1 = whoGrid.RowDefinitions.Count;


                    // Расположение куска в объекте по столбцам:
                    int col1 = Grid.GetColumn(rec1);
                    int colSpan1 = Grid.GetColumnSpan(rec1);

                    // Расположение куска в объекте по строкам:
                    int row1 = Grid.GetRow(rec1);
                    int rowSpan1 = Grid.GetRowSpan(rec1);


                    // Ширина и высота каждого единичного прямоугольника:
                    double colsUnitSegment1 = who.ActualWidth / columnsCount1;
                    double rowsUnitSegment1 = who.ActualHeight / rowsCount1;

                    #endregion

                    #region SearchingMargin

                    // Margin первого прямоугольника:
                    double right1 = (columnsCount1 - col1 - colSpan1) * colsUnitSegment1;
                    double left1 = (columnsCount1 - (columnsCount1 - col1)) * colsUnitSegment1;
                    double bottom1 = (rowsCount1 - row1 - rowSpan1) * rowsUnitSegment1;
                    double top1 = (rowsCount1 - (rowsCount1 - row1)) * rowsUnitSegment1;
                    double globalRight1 = whoMargin.Right + right1;
                    double globalLeft1 = whoMargin.Left + left1;
                    double globalBottom1 = whoMargin.Bottom + bottom1;
                    double globalTop1 = whoMargin.Top + top1;
                    Thickness whoThickness = new Thickness(globalLeft1, globalTop1, globalRight1, globalBottom1);

                    // Margin втрого прямоугольника:

                    double globalRight2 = withMargin.Right;
                    double globalLeft2 = withMargin.Left;
                    double globalBottom2 = withMargin.Bottom;
                    double globalTop2 = withMargin.Top;
                    Thickness withThickness = new Thickness(globalLeft2, globalTop2, globalRight2, globalBottom2);

                    #endregion

                    #region CollisionChecking
                    double actualHeight = GamePlayground.playground.ActualHeight - 29 - withThickness.Bottom - withThickness.Top;
                    double actualWidth = GamePlayground.playground.ActualWidth - 6 - withThickness.Left - withThickness.Right;
                    bool hasVerticalCollision = whoThickness.Top + rec1.ActualHeight > withThickness.Top && whoThickness.Top < withThickness.Top +actualHeight;
                    bool hasHorizontalCollision = whoThickness.Left + rec1.ActualWidth > withThickness.Left && whoThickness.Left < withThickness.Left + actualWidth;
                    bool hasCollision = hasVerticalCollision && hasHorizontalCollision;

                    if (hasCollision) {
                        return true;
                    }

                    #endregion
                }
            }
            return false;
        }
        public static double CalculateDistance(this UserControl who, UserControl with)
        {
            //маргин центра объектов слева
            double centreMarginLeftWho = who.Margin.Left + who.ActualWidth / 2;
            double centreMarginLeftWith = with.Margin.Left + with.ActualWidth / 2;

            //маргин центра объектов сверху
            double centreMarginTopWho = who.Margin.Top + who.ActualHeight / 2;
            double centreMarginTopWith = with.Margin.Top + with.ActualHeight / 2;

            double distance = Math.Sqrt(Math.Pow(centreMarginTopWith - centreMarginTopWho, 2) + Math.Pow(centreMarginLeftWith - centreMarginLeftWho, 2));

            return distance;
        }

        /// <summary>
        /// Функция передвижения объектов на форме
        /// </summary>
        /// <param name="creature"> Сам объект </param>
        /// <param name="speed"> То, насколько переместится объект</param>
        /// <param name="direction"> Направление движения </param>
        public static void Move(this FrameworkElement creature, int speed, Directions direction)
        {

            Thickness thickness = creature.Margin;
            Thickness backup = creature.Margin;

            switch (direction) {
                case Directions.Left:
                    thickness.Left -= speed;
                    thickness.Right += speed;
                    break;
                case Directions.Right:
                    thickness.Left += speed;
                    thickness.Right -= speed;
                    break;
                case Directions.Top:

                    thickness.Top -= speed;
                    thickness.Bottom += speed;

                    break;
                case Directions.Bottom:
                    thickness.Top += speed;
                    thickness.Bottom -= speed;
                    break;
            }

            creature.Margin = thickness;
        }
    }
}