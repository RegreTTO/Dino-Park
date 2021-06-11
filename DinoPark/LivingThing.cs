using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Dino_Park_2._0
{
    public abstract class LivingThing : UserControl
    {
        /// <summary>
        /// Передвигает объект
        /// </summary>
        /// <param name="creature"> Сам объект </param>
        /// <param name="speed"> То, насколько он сдвинется </param>
        /// <param name="direction"> Направление движения </param>
        /// <returns> Произошла ли коллизия с динозавром после передвижения </returns>
        public static bool Move(UserControl creature, int speed, Directions direction)
        {

            Thickness thickness = creature.Margin;
            Thickness backup = creature.Margin;

            switch (direction) {
                case Directions.Left:
                    if (creature.Margin.Left - speed < 0) speed = (int)creature.Margin.Left;

                    thickness.Left -= speed;
                    thickness.Right += speed;
                    break;
                case Directions.Right:
                    if (creature.Margin.Left + speed > GamePlayground.playground.ActualWidth - creature.ActualWidth) speed = (int)(GamePlayground.playground.ActualWidth - creature.ActualWidth - creature.Margin.Left);

                    thickness.Left += speed;
                    thickness.Right -= speed;

                    break;
                case Directions.Top:
                    if (creature.Margin.Top - speed < 0) speed = (int)creature.Margin.Top;

                    thickness.Top -= speed;
                    thickness.Bottom += speed;

                    break;
                case Directions.Bottom:
                    if (creature.Margin.Top + speed + 35 > GamePlayground.playground.Height - creature.ActualHeight) speed = (int)(GamePlayground.playground.Height - creature.ActualHeight - 35 - creature.Margin.Top);

                    thickness.Top += speed;
                    thickness.Bottom -= speed;

                    break;
            }

            void setHpMargin(Thickness hpMargin)
            {
                if (creature is Dino) {
                    hpMargin.Top -= 48;
                    hpMargin.Bottom = hpMargin.Right = 0;
                    GamePlayground.HpBox.Margin = hpMargin;
                }
            }

            creature.Margin = thickness;
            


            foreach (var obj in NotPassableObjects.solidObjects) {
                bool hasCollision = false;
                bool charCollision = false;
                if (obj is UserControl uc && creature.IntersectsWith(uc) && creature.GetType() != uc.GetType()) {
                    hasCollision = true;
                    if (uc is Dino || uc is Octopus)
                        charCollision = true;
                }
                else if (!(obj is UserControl) && creature.IntersectsWith(obj) && creature.GetType() != obj.GetType()) hasCollision = true;

                if (hasCollision) {
                    creature.Margin = backup;
                    setHpMargin(backup);
                    return charCollision;
                }
            }
            setHpMargin(thickness);
            return false;

        }
        
    }
}
