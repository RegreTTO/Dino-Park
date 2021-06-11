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
    /// Логика взаимодействия для MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer clock = new DispatcherTimer(DispatcherPriority.Render);
        int currentFrame, incDec;

        public MainWindow()
        {
            InitializeComponent();

            clock.Interval = new TimeSpan(0, 0, 0, 0, 650);
            clock.Tick += DrawNextFrame;
            currentFrame = 1;
            incDec = 1;
        }

        // Включение/выключение анимации главного меню при переключении окна с/на меню:
        private void MenuWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            clock.IsEnabled = !clock.IsEnabled;
        }

        /// <summary>
        /// Рисует следующий кадр анимации в главном меню.
        /// </summary>
        public void DrawNextFrame(object sender, EventArgs e)
        {
            currentFrame += incDec;
            if (currentFrame == 6 || currentFrame == 1)
                incDec *= -1;
            string way = "pack://application:,,,/MainMenu" + Convert.ToString(currentFrame) + ".png";
            MenuWindow.Background = new ImageBrush(new BitmapImage(new Uri(@way, UriKind.Absolute)));
        }

        // Смена цвета текста на кнопках при взаимодействии мышки с ними:
        private void MakeButtonForegroundRed(object sender, MouseEventArgs e) 
        { 
            (sender as Button).Foreground = new SolidColorBrush(Color.FromRgb(210, 0, 0));
        }
        private void MakeButtonForegroundWhite(object sender, MouseEventArgs e) 
        { 
            (sender as Button).Foreground = new SolidColorBrush(Color.FromRgb(255, 235, 238));
        }

        // Переходы в другие окна по нажатию кнопок:
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            GamePlayground gamePlayground = new GamePlayground();
            gamePlayground.Show();
            this.Hide();
        }
        private void CustomisationButton_Click(object sender, RoutedEventArgs e)
        {
            CustomisationWindow customisationWindow = new CustomisationWindow();
            customisationWindow.Show();
            this.Hide();
        }
        private void TutorialButton_Click(object sender, RoutedEventArgs e)
        {
            TutorialWindow tutorialWindow = new TutorialWindow();
            tutorialWindow.Show();
            this.Hide();
        }
    }
}