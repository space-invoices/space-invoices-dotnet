using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvoices;
using System.Collections.Generic;
using System.Threading.Tasks;



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
        public async Task CreateDocumentAsync()
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
            SpaceDocumentClientOptions sc = new SpaceDocumentClientOptions
            {
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
            SpaceDocument sd = await sds.CreateAsync(so[0].Id, sdo);

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
            var filter = @"{
                               filter: {
                                        where: {
                                            type: 'invoice'
                                        }
                                    } 
                                }";

            List<SpaceDocument> lsd = sds.List(so[0].Id, filter);

            Assert.IsNotNull(lsd);
        }

        [TestMethod]
        public async Task ListDocumentsAync()
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
            var filter = @"{
                               filter: {
                                        where: {
                                            type: 'invoice'
                                        }
                                    } 
                                }";

            List<SpaceDocument> lsd = await sds.ListAsync(so[0].Id, filter);

            Assert.IsNotNull(lsd);
        }

        [TestMethod]
        public void ListDocumentsNoFilter()
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
            var filter = @"{
                               filter: {
                                        where: {
                                            type: 'invoice'
                                        }
                                    } 
                                }";
            List<SpaceDocument> lsd = sds.List(so[0].Id, filter);

            SpaceDocument doc = sds.GetById(lsd[0].Id, filter);

            Assert.IsNotNull(doc);
            Assert.AreEqual(doc.Type, "invoice");
        }

        [TestMethod]
        public async Task GetByIdAsync()
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
            var filter = @"{
                               filter: {
                                        where: {
                                            type: 'invoice'
                                        }
                                    } 
                                }";
            List<SpaceDocument> lsd = sds.List(so[0].Id, filter);

            SpaceDocument doc = await sds.GetByIdAsync(lsd[0].Id, filter);

            Assert.IsNotNull(doc);
            Assert.AreEqual(doc.Type, "invoice");
        }

        [TestMethod]
        public void GetByIdNoFilter()
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

      

        [TestMethod]
        public void TestFiltersBoolean()
        {

            //boolean

            var q2 = @"{
                  filter: {
                    fields: {
                      type: true
                    }
                  }
                }";
            
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

            List<SpaceDocument> lsd = sds.List(so[0].Id, q2);

            Assert.IsNotNull(lsd);
          
        }

        [TestMethod]
        public void TestFiltersLimit()
        {

            //limit

            var q3 = @"{
                          filter: {
                            limit: 5
                          }
                        }";
           
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

            List<SpaceDocument> lsd = sds.List(so[0].Id, q3);

            Assert.IsNotNull(lsd);
        }

        [TestMethod]
        public void TestFiltersOrder()
        {

            //order

            var q4 = @" {
                        filter:
                            {
                            order:
                                {
                                date: 'ASC'
                            }
                            }
                        }";
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

            List<SpaceDocument> lsd = sds.List(so[0].Id, q4);

            Assert.IsNotNull(lsd);
        }

        [TestMethod]
        public void TestFiltersCondition()
        {

            //order
             //TODO what is expected answer?
            var q5 = @"{
                     filter: {
                        where: {
                          and: [{
                              type: 'invoice'
                            }, {
                              draft: false
                            }
                          ]
                        }
                      }
                    }";
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

            List<SpaceDocument> lsd = sds.List(so[0].Id, q5);

            Assert.IsNotNull(lsd);
        }

        [TestMethod]
        public void TestFiltersGt()
        {

            //qte

            var q6 = @"{
                            filter:
                                {
                                where:
                                    {
                                    date:
                                        {
                                        gt: '2018-04-01T18:30:00.000Z'
                                    }
                                    }
                                }
                            }";
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

            List<SpaceDocument> lsd = sds.List(so[0].Id, q6);

            Assert.IsNotNull(lsd);

        }

        [TestMethod]
        public void TestFiltersBetween()
        {

            //qte

            var q6 = @"{
                  filter: {
                    where: {
                      date: {
                        between: [
                          '2017-04-01T18:30:00.000Z',
                          '2018-04-01T18:30:00.000Z'
                        ]
                    }
                }
                  }
                ";
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

            List<SpaceDocument> lsd = sds.List(so[0].Id, q6);

            Assert.IsNotNull(lsd);


        }









    
    }
}
