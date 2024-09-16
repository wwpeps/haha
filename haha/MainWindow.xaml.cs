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

namespace haha
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string value = "x";
        private int xWins = 0;
        private int oWins = 0;
        private static readonly Brush defaultbrush = new SolidColorBrush(Color.FromArgb(255, 142, 142, 166));

        private void restart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void but_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Foreground = Brushes.Black;
            bt.IsEnabled = false;
            if (IsWin(buta1, buta2, buta3)) gameover(buta1.Content.ToString());
            if (IsWin(buta4, buta5, buta6)) gameover(buta4.Content.ToString());
            if (IsWin(buta7, buta8, buta9)) gameover(buta7.Content.ToString());
            if (IsWin(buta1, buta4, buta7)) gameover(buta1.Content.ToString());
            if (IsWin(buta2, buta5, buta8)) gameover(buta2.Content.ToString());
            if (IsWin(buta3, buta6, buta9)) gameover(buta3.Content.ToString());
            if (IsWin(buta1, buta5, buta9)) gameover(buta1.Content.ToString());
            if (IsWin(buta3, buta5, buta7)) gameover(buta3.Content.ToString());

            if (!buta1.IsEnabled && !buta2.IsEnabled && !buta3.IsEnabled &&
                !buta4.IsEnabled && !buta5.IsEnabled && !buta6.IsEnabled &&
                !buta7.IsEnabled && !buta8.IsEnabled && !buta9.IsEnabled) gameover("");

            value = value == "x" ? "o" : "x";
        }

        private void gameover(string who)
        {
            if (Ibwinner.IsEnabled) return;
            if (who == "x")
            {
                Ibwinner.Content = "player x win :)";
            }
            else if (who == "o")
            {
                Ibwinner.Content = "player o win :)";
            }
            else Ibwinner.Content = "np winner wonk wonk";
            Ibwinner.Visibility = Visibility.Visible;
            waitsecnstart();
        }

        private async void waitsecnstart()
        {
            await Task.Delay(1000);
            Ibwinner.Visibility = Visibility.Hidden;
            resetbuttons();
        }

        private void resetbuttons()
        {
            resetbutton(buta1);
            resetbutton(buta2);
            resetbutton(buta3);
            resetbutton(buta4);
            resetbutton(buta5);
            resetbutton(buta6);
            resetbutton(buta7);
            resetbutton(buta8);
            resetbutton(buta9);
        }

        private void resetbutton(Button but)
        {
            but.Content = "";
            but.IsEnabled = true;
            but.Foreground = defaultbrush;
        }

        private bool IsWin(Button bt1, Button bt2, Button bt3) =>
            !bt1.IsEnabled && bt1.Content == bt2.Content && bt1.Content == bt3.Content;

        private void but_Enter(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Content = value;
        }
        private void but_leave(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.IsEnabled)
                bt.Content = "";
        }
    }
}
