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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_vxod(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentUser = AppDate.db.Users.FirstOrDefault(u => u.Login == TextBoxLogo.Text && u.Password == TextBoxPasvord.Text);

                /*  Users user = new Users()
                  {
                      Logo = TextBoxLogo.Text,
                      Pasvord = TextBoxPasvord.Text,
                  };
                  AppDate.db.Users.Add(user);
                  try
                  {
                      AppDate.db.SaveChanges();
                      MessageBox.Show("хуй");
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }

                 */

                if (CurrentUser == null)
                {
                    MessageBox.Show("ошибка входа, повторите еще раз!");


                    /* MessageBox.Show("Вы успешно зашли");
                    var Adminca = new adminca();
                    Adminca.Show();
                    this.Close();*/
                }
                else
                {
                    MessageBox.Show("Вы успешно зашли");
                    var Adminca = new adminca();
                    Adminca.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

