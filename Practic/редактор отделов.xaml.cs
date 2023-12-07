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
    /// Логика взаимодействия для редактор_отделов.xaml
    /// </summary>
    public partial class редактор_отделов : Window
    {
        public редактор_отделов()
        {
            InitializeComponent();
            DGridOtdel.ItemsSource = PolyclinicEntities.GetContext().Otdels.ToList();
        }

        private void Button_Click_nazad(object sender, RoutedEventArgs e)
        {
            var Admin = new adminca();
            Admin.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ///ydal
            var otdelForRemovind = DGridOtdel.SelectedItems.Cast<Otdels>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие данные{otdelForRemovind.Count()} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PolyclinicEntities.GetContext().Otdels.RemoveRange(otdelForRemovind);
                    PolyclinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены !");
                    DGridOtdel.ItemsSource = PolyclinicEntities.GetContext().Otdels.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var redd = new Добавление_отделения();
            redd.Show();
            this.Close();
        }
    }
}
