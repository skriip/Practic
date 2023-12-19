
namespace Practic.Tests
  
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mainWindow = new Главная();

            // Act
            mainWindow.Nam.Text = string.Empty;
            mainWindow.Fami.Text = string.Empty;
            mainWindow.Oti.Text = string.Empty;
            mainWindow.dr.Text = string.Empty;
            mainWindow.teli.Text = string.Empty;
            mainWindow.Poch.Text = string.Empty;
            mainWindow.datePicker.Text = string.Empty;
            mainWindow.ComboBox1.SelectedItem = null;
            mainWindow.cbTime.SelectedItem = null;

            mainWindow.Button_Click_1(null, null); // вызываем обработчик события для проверки

            // Assert
            // Проверяем, что MessageBox был вызван с ожидаемым текстом ошибок
            Assert.That(mainWindow.MessageBoxText, Is.EqualTo("Укажите имя\r\nУкажите фамилию\r\nУкажите отчество\r\nУкажите дату рождения\r\nУкажите номер\r\nУкажите почту\r\nУкажите дату\r\nУкажите отдел\r\nУкажите время"));
        }
    }
}