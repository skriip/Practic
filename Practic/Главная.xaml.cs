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
using System.Data.Entity;
using System.Globalization;
using System.Xml.Linq;
using System.Security.Cryptography;
using Practic.Properties;

namespace Practic
{
    /// <summary>
    /// Логика взаимодействия для Главная.xaml
    /// </summary>
    public partial class Главная : Window
    {
        private Record  _pogr = new Record();
        public Главная()
        {
            InitializeComponent();
            ComboBox1.ItemsSource = PolyclinicEntities1.GetContext().Otdels.ToList();
            for (int i = 9; i <= 20; i++)
            {
                cbTime.Items.Add(new DateTime(1, 1, 1, i, 0, 0).ToString("HH:mm"));
            }
            
           
            DataContext = _pogr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var adm = new MainWindow ();
            adm.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //добавление
          /*  String fami = Fami.Text.Trim();
            String nami = Nam.Text.Trim();
            String oti = Oti.Text.Trim();
            String tell =teli.Text.Trim();
            String pochti = Poch.Text.Trim();
            String drr = dr.Text.Trim();

            if (nami.Length < 3)
            {
                Nam.ToolTip = "Это поле введено не корректно!";
                Nam.Background = Brushes.DarkRed;
            }
            else if (oti.Length < 3)
            {
                Oti.ToolTip = "Это поле введено не корректно!"; 
            Oti.Background = Brushes.DarkRed;
            }

            else if (fami.Length < 4)
            {
                Fami.ToolTip = "Это поле введено не корректно!";
                Fami.Background = Brushes.DarkRed;
            }
            else if (drr.Length < 5)
            {
                dr.ToolTip = "Это поле введено не корректно!";
                dr.Background = Brushes.DarkRed;
            }
            else if (tell.Length < 11)
            {
                teli.ToolTip = "Это поле введено не корректно!";
                teli.Background = Brushes.DarkRed;
            }
            else if (pochti.Length < 5 || !pochti.Contains("@") || !pochti.Contains("."))
            {
                Poch.ToolTip = "Это поле введено не корректно!";
                Poch.Background = Brushes.DarkRed;
            }
              
            

            else
            {
                teli.ToolTip = "";
                teli.Background = Brushes.Transparent;
                Fami.ToolTip = "";
                Fami.Background = Brushes.Transparent;
                Oti.ToolTip = "";
                Oti.Background = Brushes.Transparent;
                Nam.ToolTip = "";
                Nam.Background = Brushes.Transparent;
                Poch.ToolTip = "";
                Poch.Background = Brushes.Transparent;
                dr.ToolTip = "";
                dr.Background = Brushes.Transparent;
                */

                 StringBuilder errors = new StringBuilder();
                 if (string.IsNullOrWhiteSpace(Nam.Text))
                     errors.AppendLine("Укажите имя ");
                 if (string.IsNullOrWhiteSpace(Fami.Text))
                     errors.AppendLine("Укажите фамилию ");
                 if (string.IsNullOrWhiteSpace(Oti.Text))
                     errors.AppendLine("Укажите отчество ");
                 if (string.IsNullOrWhiteSpace(dr.Text))
                     errors.AppendLine("Укажите дату рождения ");
                 if (string.IsNullOrWhiteSpace(teli.Text))
                     errors.AppendLine("Укажите номер ");
                 if (string.IsNullOrWhiteSpace(Poch.Text))
                     errors.AppendLine("Укажите почту ");
                if (string.IsNullOrWhiteSpace(datePicker.Text))
                     errors.AppendLine("Укажите дату без пробелов и точет");
                 if (ComboBox1.SelectedItem == null)
                     errors.AppendLine("Укажите отдел");
                if (cbTime.SelectedItem == null)
                    errors.AppendLine("Укажите время ");


                if (errors.Length > 0)
                 {
                     MessageBox.Show(errors.ToString());
                     return;
                 }

                var hour = cbTime.SelectedItem;
            Record newd = new Record();
            DateTime selectedDate = datePicker.SelectedDate ?? DateTime.Now.Date;
            DateTime selectedTime = DateTime.ParseExact(hour.ToString(), "HH:mm", CultureInfo.InvariantCulture);
            DateTime combinedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedTime.Hour, selectedTime.Minute, 0);
            newd.dataTime = combinedDateTime;
            var otdel= ComboBox1.SelectedItem as Otdels;
             if (_pogr.id_Record == 0)
            {
                var record = new Record{
                    
                    Name = Nam.Text,
                    Familiy = Fami.Text,
                    Otchestvo = Oti.Text,
                    Pochta = Poch.Text,
                    Telefon = Convert.ToInt32(teli.Text),
                    Datero = Convert.ToInt32(dr.Text),
                    dataTime = newd.dataTime, 
                    id_Otdels = otdel.id_Otdel
                  //  dataTime = DateTime.ParseExact($"{datePicker.Text} {cbTime.Text}", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                };
                  PolyclinicEntities1.GetContext().Record.Add(record);
            }
                

             try
             {
                 PolyclinicEntities1.GetContext().SaveChanges();
                 MessageBox.Show("Информация сохранена");

             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Произошла ошибка при сохранении записи : {ex.Message}");
             }
            DatePicker_SelectedChanged(datePicker, null);

        

      /*  private void DatePicker_SelectedChanged(object sender, SelectionChangedEventArgs e)
            {
                DateTime? selectedDate = datePicker.SelectedDate;

                if (selectedDate.HasValue)
                {
                    var otd = ComboBox1.SelectedItem as Otdels;

                    if (otd != null)
                    {
                        int otdelId =  otd.id_Otdel;

                        var reservations = PolyclinicEntities1.GetContext().Record
                            .Where(r => r.id_Otdels == otdelId && DbFunctions.TruncateTime(r.dataTime) == selectedDate)
                            .ToList();
                        var reserhour = PolyclinicEntities1.GetContext().Record.Where(r => r.id_Otdels == otdelId);
                      
                            for (int x = 9; x <= 20; x++)
                            {
                                cbTime.Items.Add(new DateTime(1, 1, 1, x, 0, 0).ToString("HH:mm"));
                            }
                    }
                    else
                    {
                        MessageBox.Show("Выберите комнату перед выбором даты.");
                    }

                } */
            }
     


        private void DatePicker_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = datePicker.SelectedDate;

            if (selectedDate.HasValue)
            {
                var otdell = ComboBox1.SelectedItem as Otdels;

                /* if (otdell != null)
                 {
                     int otdelId = otdell.id_Otdel;
                     var reservations = PolyclinicEntities1.GetContext().Record
                         .Where(r => r.id_Otdels == otdelId && DbFunctions.TruncateTime(r.dataTime) == selectedDate)
                         .ToList();
                     var reserhour = PolyclinicEntities1.GetContext().Record.Where(r => r.id_Otdels == otdelId);
                     var hourst = reservations.Select(r => r.dataTime.Value.Hour).ToList();
                     var allHours = Enumerable.Range(9, 12).ToList();
                     cbTime.Items.Clear();
                     if (reservations.Any())
                     {
                         for (int i = 9; i <= 20; i++)
                         {
                                 cbTime.Items.Add(new DateTime(1, 1, 1, i, 0, 0).ToString("HH:mm"));
                         }
                     }
                     else
                     {
                         for (int x = 9; x <= 20; x++)
                         {
                             cbTime.Items.Add(new DateTime(1, 1, 1, x, 0, 0).ToString("HH:mm"));
                         }
                     }
                 }
                 else
                 {
                     MessageBox.Show("Выберите комнату перед выбором даты.");
                 }
                */

                if (selectedDate.HasValue)
                {
                    var otdel = ComboBox1.SelectedItem as Otdels;

                    if (otdel != null)
                    {
                        int otdelId = otdel.id_Otdel;

                        var reservedHours = PolyclinicEntities1.GetContext().Record
                            .Where(r => r.id_Otdels == otdelId && DbFunctions.TruncateTime(r.dataTime) == selectedDate)
                            .Select(r => r.dataTime.Value.Hour)
                            .ToList();

                        var availableHours = Enumerable.Range(9, 12).Except(reservedHours).ToList();

                        cbTime.Items.Clear();

                        foreach (int hour in availableHours)
                        {
                            cbTime.Items.Add(new DateTime(1, 1, 1, hour, 0, 0).ToString("HH:mm"));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите отдел перед выбором даты.");
                    }
                }
            }
        }






        /*   private void CreateRecord()
           {
               try
               {
                   var otdel = ComboBox1.SelectedItem as Otdels;
                   if (otdel == null )
                   {
                       MessageBox.Show("Выберите отдел и время");
                       return;
                   }
                  Record newd = new Record();
                   DateTime selectedDate = datePicker.SelectedDate ?? DateTime.Now.Date;
               var endDate = newd.dataTime;
                   var overlappingReservations = PolyclinicEntities1.GetContext().Record.Where(r => r.id_Otdels == otdel.id_Otdel &&
                         ((newd.dataTime >= r.dataTime ) ||
                          (endDate > r.dataTime ))).ToList();
               Record record = new Record();
               /*   {
                   Name = Nam.Text,
                   Familiy = Fami.Text,
                   Otchestvo = Oti.Text,
                   Pochta = Poch.Text,
                   Telefon = Convert.ToInt32(teli.Text),
                   Datero = Convert.ToInt32(dr.Text),
                   id_Otdels = otdel.id_Otdel,
                   dataTime = DateTime.ParseExact($"{datePicker.Text} {cbTime.Text}", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
               };
              var recor = new Record
                 {
                     id_Otdels = otdel.id_Otdel,
                        Name = Nam.Text,
                        Familiy = Fami.Text,
                        Otchestvo = Oti.Text,
                        Pochta = Poch.Text,
                       /* dataTime = datePicker.Text cbTime.Text,
                       Telefon =Convert.ToInt32(teli.Text),
        }
               PolyclinicEntities1.GetContext().Record.Add(record);
                 PolyclinicEntities1.GetContext().SaveChanges();
                     MessageBox.Show("Бронирование успешно сохранено");
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show($"Произошла ошибка при сохранении бронирования: {ex.Message}");
                 }
                 DatePicker_SelectedChanged(datePicker, null);
             /*  PolyclinicEntities1.GetContext().Record.Add(record);
               PolyclinicEntities1.GetContext().SaveChanges();

               MessageBox.Show("Бронирование успешно сохранено");
           }
           catch (Exception ex)
           {
               MessageBox.Show($"Произошла ошибка при сохранении бронирования: {ex.Message}");
           }

           DatePicker_SelectedChanged(datePicker, null);*/
    }

}
    
   
