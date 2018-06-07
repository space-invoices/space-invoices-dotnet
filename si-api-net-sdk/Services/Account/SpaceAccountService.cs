using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SpaceInvoices.Infrastructure;


namespace SpaceInvoices
{
    public class SpaceAccountService : SpaceService
    {
        public SpaceAccountService() : base(null) { }
        public SpaceAccountService(string apiKey) : base(apiKey) { }

        //Sync
        public virtual SpaceAccount Create(SpaceAccountCreateOptions account)
        {
            //return Mapper<SpaceAccount>.MapFromJson(
            //    Requestor.PostString(this.ApplyAllParameters(account, $"{Urls.Accounts}", false))
            //);

            return Mapper<SpaceAccount>.MapFromJson(
              Requestor.Post(account, $"{Urls.Accounts}")
          );
        }

        public virtual SpaceLogIn LogIn(SpaceAccountLoginOptions account)
        {
           // return Mapper<SpaceLogIn>.MapFromJson(
           //    Requestor.PostString(this.ApplyAllParameters(account, $"{Urls.Accounts}/login", false))
           //);

            return Mapper<SpaceLogIn>.MapFromJson(
              Requestor.Post(account, $"{Urls.Accounts}/login")
          );

         
        }

        public virtual List<SpaceOrganization> ListOrganizations(string accountId)
        {
            return Mapper<SpaceOrganization>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Accounts}/{accountId}/organizations")
            );
        }

        public virtual bool IsUnique(string email)
        {
            return System.Convert.ToBoolean(Mapper<Unique>.MapFromJson(Requestor.Get($"{Urls.Accounts}/is-unique?email={email}")).IsUnique);

        }

        public virtual SpaceAccount Details(string accountId)
        {
            return Mapper<SpaceAccount>.MapFromJson(Requestor.Get($"{Urls.Accounts}/{accountId}"));
        }

    }
}
