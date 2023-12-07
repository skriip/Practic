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

namespace Practic
{
    /// <summary>
    /// Логика взаимодействия для adminca.xaml
    /// </summary>
    public partial class adminca : Window
    {
        public adminca()
        {
            InitializeComponent();
        }

        private void Button_Click_nazad(object sender, RoutedEventArgs e)
        {
            var главная = new Главная(); 
            главная.Show(); 
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var редактор = new Редактор_врачей();
            редактор.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ot = new redOtdel();
            ot.Show();
            this.Close();
        }
    }
}
