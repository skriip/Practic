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
    /// Логика взаимодействия для DobavVrach.xaml
    /// </summary>
    public partial class DobavVrach : Window
    {
        private Vrach _pogr = new Vrach();
        public DobavVrach(Vrach selectedVrach)
        {
            InitializeComponent();

            if (selectedVrach != null)
            {
                _pogr = selectedVrach;
            }
            DataContext = _pogr;
            ComboBox1.ItemsSource = PolyclinicEntities.GetContext().Otdels.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //добавление
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Namm.Text))
                errors.AppendLine("Укажите имя врача");
            if (string.IsNullOrWhiteSpace(Famm.Text))
                errors.AppendLine("Укажите фамилию врача");
            if (string.IsNullOrWhiteSpace(Ott.Text))
                errors.AppendLine("Укажите отчество врача");
            if (ComboBox1.SelectedItem == null)
                errors.AppendLine("Укажите отдел");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_pogr.id_Vrach == 0)
                PolyclinicEntities.GetContext().Vrach.Add(_pogr);

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
            var RedDo = new Редактор_врачей(); 
            RedDo.Show(); 
            this.Close(); 
        }

        
    }
    }
