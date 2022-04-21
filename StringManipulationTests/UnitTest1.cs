using EX_04_StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringManipulationTests
{
    [TestClass]
    public class UnitTest1
    {
        public Accounts accounts = new Accounts();

        [TestMethod]
        public void FindUserName_marimaasikasgmailcom()
        {
            string result = accounts.FindUserName("mari.maasikas@gmail.com");
            Assert.AreEqual("Name: Mari Maasikas Domain: Gmail", result);
        }

        [TestMethod]
        public void FindUserName_gmailmarimaasikas()
        {
            string result = accounts.FindUserName("gmail/mari.maasikas");
            Assert.AreEqual("Name: Mari Maasikas Domain: Gmail", result);
        }

        [TestMethod]
        public void CreateUserName_ulolipping()
        {
            string result = accounts.CreateUsername("Ülo Lipping");
            Assert.AreEqual("ulo.lipping", result);
        }

        [TestMethod]
        public void CreateUserName_eliissofiatarasov()
        {
            string result = accounts.CreateUsername("Eliis Sofia Tarasov");
            Assert.AreEqual("eliissofia.tarasov", result);
        }

        [TestMethod]
        public void CreateEmailAadress_eliistarasovgmail()
        {
            string result = accounts.CreateEmailAddress("Eliis Tarasov gmail");
            Assert.AreEqual("eliis.tarasov@gmail.eu", result);
        }

        [TestMethod]
        public void CreateEmailAadress_marimaasikascompany()
        {
            string result = accounts.CreateEmailAddress("Mari Maasikas company");
            Assert.AreEqual("mari.maasikas@company.eu", result);
        }

        [TestMethod]
        public void CreateDomainAccount_marimaasikascompany()
        {
            string result = accounts.CreateDomainAccount("Mari Maasikas company");
            Assert.AreEqual("company/mari.maasikas", result);
        }

        [TestMethod]
        public void CreateDomainAccount_juhanjuurikasgmail()
        {
            string result = accounts.CreateDomainAccount("Juhan Juurikas gmail");
            Assert.AreEqual("gmail/juhan.juurikas", result);
        }
    }
}
