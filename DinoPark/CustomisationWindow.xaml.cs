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
    /// Логика взаимодействия для CustomisationWindow.xaml.
    /// </summary>
    public partial class CustomisationWindow : Window
    {
        DispatcherTimer animationTimer = new DispatcherTimer();
        Window mainWindow = App.Current.MainWindow;
        int currentFrame;

        public CustomisationWindow()
        {
            InitializeComponent();

            this.WindowState = mainWindow.WindowState;
            this.Height = mainWindow.Height;
            this.Width = mainWindow.Width;
            this.Top = mainWindow.Top;
            this.Left = mainWindow.Left;

            animationTimer.Interval = new TimeSpan(0, 0, 0, 0, 650);
            animationTimer.Tick += DrawNextFrame;
            animationTimer.IsEnabled = true;
            currentFrame = 1;
        }

        private void Customisation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            animationTimer.IsEnabled = false;
            mainWindow.WindowState = this.WindowState;
            mainWindow.Height = this.Height;
            mainWindow.Width = this.Width;
            mainWindow.Left = this.Left;
            mainWindow.Top = this.Top;
            mainWindow.Show();
        }

        /// <summary>
        /// Прорисовка следующего кадра анимации фона окна кастомизации.
        /// </summary>
        private void DrawNextFrame(object sender, EventArgs e)
        {
            if (currentFrame == 1) currentFrame = 2;
            else currentFrame = 1;
            string way = "pack://application:,,,/SeaBox" + Convert.ToString(currentFrame) + ".png";
            DinoCustomGrid.Background = new ImageBrush(new BitmapImage(new Uri(@way, UriKind.Absolute)));
            OctopusCustonGrid.Background = new ImageBrush(new BitmapImage(new Uri(@way, UriKind.Absolute)));
            ItemCustomGrid.Background = new ImageBrush(new BitmapImage(new Uri(@way, UriKind.Absolute)));
        }

        // Смена цветов текстов на TabItem'ах при взаимодействии с ними:
        private void CustomisationCharacterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] name = { "DinoTabItem", "OctopusTabItem", "ItemTabItem" };
            for (int i = 0; i < 3; i++)
                (FindName(name[i]) as TabItem).Foreground = new SolidColorBrush(Color.FromRgb(255, 235, 238));
            (CustomisationCharacters.SelectedItem as TabItem).Foreground = new SolidColorBrush(Color.FromRgb(213, 0, 0));
        }
        private void MakeTabItemForegroundRed(object sender, MouseEventArgs e)
        {
            (sender as TabItem).Foreground = new SolidColorBrush(Color.FromRgb(213, 0, 0));
        }
        private void MakeTabItemForegroundWhite(object sender, MouseEventArgs e)
        {
            (sender as TabItem).Foreground = new SolidColorBrush(Color.FromRgb(255, 235, 238));
        }
    }
}
