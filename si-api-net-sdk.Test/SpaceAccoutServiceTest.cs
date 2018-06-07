using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvoices;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace si_api_net_sdk.Test
{
    [TestClass]
    public class SpaceAccountServiceTst
    {
        [TestMethod]
        public void CreateAccount()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");
            SpaceAccountCreateOptions acc = new SpaceAccountCreateOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "0090";
            SpaceAccountService accs = new SpaceAccountService();
            //SpaceLogIn l = accs.LogIn(acc);
            SpaceAccount x = accs.Create(acc);

            Assert.IsNotNull(x);
        }

        [TestMethod]
        public async Task CreateAccountAsync()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");
            SpaceAccountCreateOptions acc = new SpaceAccountCreateOptions();
            acc.Email = "david.jeras1@gmail.com";
            acc.Password = "0090";
            SpaceAccountService accs = new SpaceAccountService();
            //SpaceLogIn l = accs.LogIn(acc);
            SpaceAccount x = await accs.CreateAsync(acc);

            Assert.IsNotNull(x);
        }

        [TestMethod]
        public void ListOrganizations()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");
            SpaceAccountLoginOptions acc = new SpaceAccountLoginOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "0090";
            SpaceAccountService accs = new SpaceAccountService();
            SpaceLogIn l = accs.LogIn(acc);



            List<SpaceOrganization> x = accs.ListOrganizations(l.UserId);

            Assert.IsNotNull(x);
        }

        [TestMethod]
        public async Task ListOrganizationsAsync()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");
            SpaceAccountLoginOptions acc = new SpaceAccountLoginOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "0090";
            SpaceAccountService accs = new SpaceAccountService();
            SpaceLogIn l = accs.LogIn(acc);



            List<SpaceOrganization> x = await accs.ListOrganizationsAsync(l.UserId);

            Assert.IsNotNull(x);
        }

        [TestMethod]
        public void IsUnique()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");
            SpaceAccountService accs = new SpaceAccountService();
            var x = accs.IsUnique("david.unique@gmail.com");
            var y = accs.IsUnique("david.jeras@gmail.com");

            Assert.IsTrue(x);
            Assert.IsFalse(y);
            
        }

        [TestMethod]
        public void Details()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");
            SpaceAccountLoginOptions acc = new SpaceAccountLoginOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "0090";
            SpaceAccountService accs = new SpaceAccountService();
            SpaceLogIn l = accs.LogIn(acc);

            SpaceAccount sa = accs.Details(l.UserId);

            Assert.IsNotNull(sa);
            Assert.IsInstanceOfType(sa, typeof(SpaceAccount));
            Assert.AreEqual(sa.Email, acc.Email);

            
        }

        [TestMethod]
        public async Task DetailsAsync()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");
            SpaceAccountLoginOptions acc = new SpaceAccountLoginOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "0090";
            SpaceAccountService accs = new SpaceAccountService();
            SpaceLogIn l = accs.LogIn(acc);

            SpaceAccount sa = await accs.DetailsAsync(l.UserId);

            Assert.IsNotNull(sa);
            Assert.IsInstanceOfType(sa, typeof(SpaceAccount));
            Assert.AreEqual(sa.Email, acc.Email);


        }
    }
}
