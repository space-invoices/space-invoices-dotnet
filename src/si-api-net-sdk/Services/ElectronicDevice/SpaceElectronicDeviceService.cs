using System;
using SpaceInvoices;
using System.Collections.Generic;
using SpaceInvoices.Infrastructure;
using Newtonsoft.Json;
namespace SpaceInvoices
{
    public class SpaceElectronicDeviceService : SpaceService
    {
        public SpaceElectronicDeviceService() : base(null) { }
        public SpaceElectronicDeviceService(string apiKey) : base(apiKey) { }

        public virtual SpaceElectronicDevice Create(string businessPremiseId, SpaceElectronicDeviceCreateOptions electronicDevice)
        {
            return Mapper<SpaceElectronicDevice>.MapFromJson(
                Requestor.Post(electronicDevice, $"{Urls.BusinessPremises}/{businessPremiseId}/electronicDevices")
            );
        }

        public virtual List<SpaceElectronicDevice> List(string organizationId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceElectronicDevice>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/electronicDevices", filterObj)
            );
        }

        public virtual SpaceElectronicDevice PatchAttributes(string electronicDeviceId, SpaceEectronicDevicePatchOptions patchOptions)
        {
            return Mapper<SpaceElectronicDevice>.MapFromJson(
                Requestor.Patch(patchOptions, $"{Urls.ElectronicDevices}/{electronicDeviceId}")
            );                                         
        }

    }
}
