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
    /// Логика взаимодействия для Редактор_врачей.xaml
    /// </summary>
    public partial class Редактор_врачей : Window
    {
        public Редактор_врачей()
        {
            InitializeComponent();
            DGridVrach.ItemsSource = PolyclinicEntities.GetContext().Vrach.ToList();
            
        }

        private void Button_Click_nazad(object sender, RoutedEventArgs e)
        {
            var Admin  = new adminca();
            Admin.Show();
            this.Close();
        }
       
    }
}
