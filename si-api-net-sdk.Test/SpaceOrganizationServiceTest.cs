using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvoices;
using System.Collections.Generic;

namespace siapinetsdk.Test
{
    [TestClass]
    public class SpaceOrganizationServiceTest
    {
        [TestMethod]
        public void CreateOrganization()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");
            SpaceAccountLoginOptions acc = new SpaceAccountLoginOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "0090";
            SpaceAccountService accs = new SpaceAccountService();
            SpaceLogIn l = accs.LogIn(acc);

            SpaceOrganizationService sos = new SpaceOrganizationService();
            SpaceOrganizationCreateOptions soco = new SpaceOrganizationCreateOptions();

            soco.Name = "Space Exploration Technologies corp";
            soco.Address = "Rocket Road";
            soco.City = "Hawthorne";
            soco.Zip = "CA 90250";
            soco.Country = "USA";
            soco.Iban = "123454321 123454321";

            SpaceOrganization x = sos.Create(l.UserId, soco);

            Assert.IsNotNull(x);
            Assert.AreEqual("Space Exploration Technologies corp", x.Name);
            Assert.AreEqual("Rocket Road", x.Address);
            Assert.AreEqual("CA 90250", x.Zip);
            Assert.IsNotNull(x.Defaults);
        }
    }
}
