using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvoices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Net.Http;

namespace siapinetsdk.Test
{
    [TestClass]
    public class SpaceDefautsTest
    {
        [TestMethod]
        public void GetDefaults()
        {
            SpaceHelper spaceHelper = new SpaceHelper();
            spaceHelper.SetConfig();

            SpaceAccountLoginOptions acc = new SpaceAccountLoginOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "00000000";
            SpaceAccountService accs = new SpaceAccountService();
            SpaceLogIn l = accs.LogIn(acc);

            List<SpaceOrganization> so = accs.ListOrganizations(l.UserId);

            SpaceDefaultService spaceDefaultService = new SpaceDefaultService();

            var defs = spaceDefaultService.List("5c877eb8f8b9ff13ae3953cd");
            Assert.IsNotNull(defs);


            //spaceOrganizationService.UploadImage(so[0].Id, "logo", )
        }

        [TestMethod]
        public void CreateDefaults()
        {
            SpaceHelper spaceHelper = new SpaceHelper();
            spaceHelper.SetConfig();

            SpaceAccountLoginOptions acc = new SpaceAccountLoginOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "00000000";
            SpaceAccountService accs = new SpaceAccountService();
            SpaceLogIn l = accs.LogIn(acc);

            List<SpaceOrganization> so = accs.ListOrganizations(l.UserId);

            SpaceDefaultService spaceDefaultService = new SpaceDefaultService();
            SpaceDefaultCreateOptions createOptions = new SpaceDefaultCreateOptions
            {
                Name = "Test default",
                Value = "neki neki"
            };

            var defs = spaceDefaultService.Create("5c877eb8f8b9ff13ae3953cd", createOptions);
            Assert.IsNotNull(defs);


            //spaceOrganizationService.UploadImage(so[0].Id, "logo", )
        }

        [TestMethod]
        public void UpdateDefaults()
        {
            SpaceHelper spaceHelper = new SpaceHelper();
            spaceHelper.SetConfig();

            SpaceAccountLoginOptions acc = new SpaceAccountLoginOptions();
            acc.Email = "david.jeras@gmail.com";
            acc.Password = "00000000";
            SpaceAccountService accs = new SpaceAccountService();
            SpaceLogIn l = accs.LogIn(acc);

            List<SpaceOrganization> so = accs.ListOrganizations(l.UserId);

            SpaceDefaultService spaceDefaultService = new SpaceDefaultService();
            SpaceDefaultCreateOptions createOptions = new SpaceDefaultCreateOptions
            {
                Name = "Test default",
                Value = "neki neki"
            };

            var defs = spaceDefaultService.List("5c877eb8f8b9ff13ae3953cd");
            var defCh = defs[defs.Count -1];

            SpaceDefaultUpdateOptions spaceDefaultUpdate = new SpaceDefaultUpdateOptions
            {
                Value = "new value"
            };

            var def = spaceDefaultService.Update("5c877eb8f8b9ff13ae3953cd", defCh.Id, spaceDefaultUpdate);
            Assert.IsNotNull(def);


            //spaceOrganizationService.UploadImage(so[0].Id, "logo", )
        }
    }
}
