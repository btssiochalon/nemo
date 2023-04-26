using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetNemo.Classes;
using System;
using static ProjetNemo.Classes.Employee;

namespace UnitTestNenom
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestInsert()
        {
            try
            {
                Bdd.InsertEmployee("Alexis", "Yanguas", "0782561205", "yanguasalexis@gmail.com", 1);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(true);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void TestUpdate()
        {
            try
            {
                Bdd.UpdateEmployee(1,"Alexis", "Yanguas", "0782561205", "yanguasalexis@gmail.com", 1);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(true);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }
        [TestMethod]
        public void TestDelete()
        {
            try
            {
                Bdd.DeleteEmployee(2);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(true);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }
    }
}
