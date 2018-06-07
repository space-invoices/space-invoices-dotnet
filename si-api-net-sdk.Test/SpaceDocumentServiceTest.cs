using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvoices;
using System.Collections.Generic;


namespace siapinetsdk.Test
{
    [TestClass]
    public class SpaceDocumentServiceTest
    {
        [TestMethod]
        public void CreateDocument()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");

            SpaceAccountLoginOptions sl = new SpaceAccountLoginOptions
            {
                Email = "david.jeras@gmail.com",
                Password = "0090"
            };

            SpaceAccountService sas = new SpaceAccountService();
            SpaceLogIn sli = sas.LogIn(sl);

            List<SpaceOrganization> so = sas.ListOrganizations(sli.UserId);

            SpaceDocumentCreateOptions sdo = new SpaceDocumentCreateOptions();
            SpaceDocumentClientOptions sc = new SpaceDocumentClientOptions{
                Name = "Rocket Man",
                Country = "USA"

            };
            SpaceDocumentItemOptions si = new SpaceDocumentItemOptions
            {
                Name = "Space sut",
                Quantity = 2,
                Unit = "Item",
                Price = 1000
            };
            sdo.DocumentClient = sc;
            sdo.DocumentItems = new List<SpaceDocumentItemOptions>();
            sdo.DocumentItems.Add(si);
            sdo.Type = "notinvoice";

            SpaceDocumentService sds = new SpaceDocumentService();
            SpaceDocument sd = sds.Create(so[0].Id, sdo);

            Assert.IsNotNull(sd);
            Assert.IsInstanceOfType(sd, typeof(SpaceDocument));

        }

        [TestMethod]
        public void ListDocuments()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");

            SpaceAccountLoginOptions sl = new SpaceAccountLoginOptions
            {
                Email = "david.jeras@gmail.com",
                Password = "0090"
            };

            SpaceAccountService sas = new SpaceAccountService();
            SpaceLogIn sli = sas.LogIn(sl);

            List<SpaceOrganization> so = sas.ListOrganizations(sli.UserId);

            SpaceDocumentService sds = new SpaceDocumentService();
            List<SpaceDocument> lsd = sds.List(so[0].Id);

            Assert.IsNotNull(lsd);
        }

        [TestMethod]
        public void GetById()
        {
            SpaceInvoices.SpaceConfiguration.SetApiKey("prr4ePvtSlRfySzNLgB11HpQhOD8mEs3DwEORbtmNINypEulwcFiWCcc64tQyVEi");

            SpaceAccountLoginOptions sl = new SpaceAccountLoginOptions
            {
                Email = "david.jeras@gmail.com",
                Password = "0090"
            };

            SpaceAccountService sas = new SpaceAccountService();
            SpaceLogIn sli = sas.LogIn(sl);

            List<SpaceOrganization> so = sas.ListOrganizations(sli.UserId);

            SpaceDocumentService sds = new SpaceDocumentService();
            List<SpaceDocument> lsd = sds.List(so[0].Id);

            SpaceDocument doc = sds.GetById(lsd[0].Id);

            Assert.IsNotNull(doc);
            Assert.AreEqual(doc.Type, "invoice");
        }

    
    }
}
