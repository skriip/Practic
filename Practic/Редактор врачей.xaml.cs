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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //удаление
            var VrachForRemoving = DGridVrach.SelectedItems.Cast<Vrach>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие данные{VrachForRemoving.Count()} элеиентов? ", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PolyclinicEntities.GetContext().Vrach.RemoveRange(VrachForRemoving);
                    PolyclinicEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridVrach.ItemsSource = PolyclinicEntities.GetContext().Vrach.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString()); ;
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dobvr = new DobavVrach(null);
            dobvr.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var adm = new adminca();
            adm.Show();
            this.Close();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var dobvr = new DobavVrach((sender as Button).DataContext as Vrach );
            dobvr.Show();
            this.Close();
        }
        


    }

}

