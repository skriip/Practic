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
    /// Логика взаимодействия для redOtdel.xaml
    /// </summary>
    public partial class redOtdel : Window
    {
        public redOtdel()
        {
            InitializeComponent();
            DGridOtdel.ItemsSource = PolyclinicEntities.GetContext(). Otdels.ToList();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var admin = new adminca();
            admin.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ydalit
            var otdForRemoving = DGridOtdel.SelectedItems.Cast<Otdels>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие данные{otdForRemoving.Count()} элеиентов? ", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PolyclinicEntities.GetContext().Otdels.RemoveRange(otdForRemoving);
                    PolyclinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridOtdel.ItemsSource = PolyclinicEntities.GetContext().Otdels.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString()); ;
                }
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var Redpodr = new dobavlenieOtdel(null); 
            Redpodr.Show(); 
            this.Close();
        }
        private void BnEdit_Click(object sender, RoutedEventArgs e)
        {
            var dobo = new dobavlenieOtdel ((sender as Button).DataContext as Otdels);
            dobo.Show();
            this.Close();
        }
    }
    }

