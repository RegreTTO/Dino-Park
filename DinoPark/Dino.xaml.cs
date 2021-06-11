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
    /// Логика взаимодействия для Dino.xaml
    /// </summary>
    public partial class Dino : UserControl
    {
        public static int hp = 100;
        public Dino()
        {
            InitializeComponent();
        }
        
        public static void takeBite(int strength)
        {
            GamePlayground.DecreasePoints(strength);
            hp -= 10;
            GamePlayground.HpBar.Value = hp;
            GamePlayground.HpValue.Content = hp.ToString();
            if (hp <= 0) {
                hp = 100;
                GamePlayground.playground.Close();
                MessageBox.Show("Мы пока не придумали конец, но вы проиграли");
                
            }
        }
    }
}
