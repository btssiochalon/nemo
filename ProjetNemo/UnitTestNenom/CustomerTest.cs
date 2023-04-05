using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetNemo.Classes;
using System;
using static ProjetNemo.Classes.Customer;

namespace UnitTestNenom
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestInsert()
        {
            try
            {
                Bdd.InsertCustomer("Alexis", "Yanguas", "0782561205", "yanguasalexis@gmail.com", 1);
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
                Bdd.UpdateCustomer(1,"Alexis", "Yanguas", "0782561205", "yanguasalexis@gmail.com", 1);
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
                Bdd.DeleteCustomer(2);
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
