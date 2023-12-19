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
    /// Логика взаимодействия для redZayvc.xaml
    /// </summary>
    public partial class redZayvc : Window
    {
        public redZayvc()
        {
            InitializeComponent();
            DGridOtdel.ItemsSource = PolyclinicEntities1.GetContext().Record.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ydal
            var recForRemoving = DGridOtdel.SelectedItems.Cast<Record>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие данные{recForRemoving.Count()} элеиентов? ", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PolyclinicEntities1.GetContext().Record.RemoveRange(recForRemoving);
                    PolyclinicEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridOtdel.ItemsSource = PolyclinicEntities1.GetContext().Record.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString()); ;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var admin = new adminca();
            admin.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var dob = new Главная();
            dob.Show();
            this.Close();
        }
    }
}
