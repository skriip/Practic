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
    /// Логика взаимодействия для dobavlenieOtdel.xaml
    /// </summary>
    public partial class dobavlenieOtdel : Window
    {
        private Otdels _pogr = new Otdels();
        public dobavlenieOtdel(Otdels selectedOtdel)
        {
            InitializeComponent();

            if (selectedOtdel != null)
            {
                _pogr = selectedOtdel;
            }
            DataContext = _pogr;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(j.Text))
                errors.AppendLine("Укажите название подраздиления");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_pogr.id_Otdel == 0)
                PolyclinicEntities.GetContext().Otdels.Add(_pogr);

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
            var RedDo = new redOtdel(); //create your new form.
            RedDo.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }
    }
}
