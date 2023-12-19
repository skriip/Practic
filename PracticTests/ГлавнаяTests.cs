using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practic.Tests
{
    /*[TestClass()]
    public class DobavVrachTests
    {
        [TestMethod()]
        public void ГлавнаяTest()
        {

            var mainWindow = new DobavVrach();

            // Act
            
            mainWindow.Namm.Text = string.Empty;
            mainWindow.Famm.Text = string.Empty;
            mainWindow.Ott.Text = string.Empty;
           
            mainWindow.ComboBox1.SelectedItem = null;
           

            mainWindow.Button_Click_2 (null, null); // вызываем обработчик события для проверки

            // Assert
            // Проверяем, что MessageBox был вызван с ожидаемым текстом ошибок
            Assert.That(mainWindow.MessageBoxText, Is.EqualTo("Укажите имя\r\nУкажите фамилию\r\nУкажите отчество\r\nУкажите дату рождения\r\nУкажите номер\r\nУкажите почту\r\nУкажите дату\r\nУкажите отдел\r\nУкажите время"));
        }
    }*/

    [TestClass()]
    public class MainWindow
    {
        [TestMethod()]
        public void Button_Click_vxod()
        {

            var mainWindow = new MainWindow();

            //Arrange
            string password = "1";
            string login = "1";

            //Act
            bool actual = MainWindow.CurrentUser(password, login);

            //Assert
            Assert.IsTrue(actual);


        }
    }
}
