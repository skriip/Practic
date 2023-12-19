using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        public void VxodAdminTest2()
        {
            //Arrange
            string password = "1";
            string logo = " ";
            //Act
            bool actual = BankAccount.VxodAdmin(password, logo);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void VxodAdminTest1()
        {
            //Arrange
            string password = "1";
            string logo = "1";
            //Act
            bool actual = BankAccount.VxodAdmin(password, logo);
            //Assert
            Assert.IsTrue(actual);
        }
    }
}










