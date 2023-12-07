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
    /// Логика взаимодействия для Добавление_отделения.xaml
    /// </summary>
    public partial class Добавление_отделения : Window
    {
        private Otdels _pogr = new Otdels();
        public Добавление_отделения()
        {
            InitializeComponent();
            DataContext = _pogr;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(otdell.Text))
                errors.AppendLine("Укажите название отдела");
           
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_pogr.id_Otdel ==0)
               PolyclinicEntities.GetContext().SaveChanges();
            try
            {
                PolyclinicEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Admin = new adminca();
            Admin.Show();
            this.Close();
        }
    }
}
