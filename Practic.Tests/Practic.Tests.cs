
namespace Practic.Tests
  
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mainWindow = new �������();

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

            mainWindow.Button_Click_1(null, null); // �������� ���������� ������� ��� ��������

            // Assert
            // ���������, ��� MessageBox ��� ������ � ��������� ������� ������
            Assert.That(mainWindow.MessageBoxText, Is.EqualTo("������� ���\r\n������� �������\r\n������� ��������\r\n������� ���� ��������\r\n������� �����\r\n������� �����\r\n������� ����\r\n������� �����\r\n������� �����"));
        }
    }
}