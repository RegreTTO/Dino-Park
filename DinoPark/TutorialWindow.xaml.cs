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

namespace Dino_Park_2._0
{
    /// <summary>
    /// Логика взаимодействия для TutorialWindow.xaml.
    /// </summary>
    public partial class TutorialWindow : Window
    {
        Window mainWindow = App.Current.MainWindow;

        public TutorialWindow()
        {
            InitializeComponent();

            this.WindowState = mainWindow.WindowState;
            this.Height = mainWindow.Height;
            this.Width = mainWindow.Width;
            this.Top = mainWindow.Top;
            this.Left = mainWindow.Left;
        }

        private void Tutorial_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.WindowState = this.WindowState;
            mainWindow.Height = this.Height;
            mainWindow.Width = this.Width;
            mainWindow.Left = this.Left;
            mainWindow.Top = this.Top;
            mainWindow.Show();
        }
    }
}
