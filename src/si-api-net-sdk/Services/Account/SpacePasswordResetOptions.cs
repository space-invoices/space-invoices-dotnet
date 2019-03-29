using System;
using Newtonsoft.Json;
namespace SpaceInvoices
{
    public class SpacePasswordResetOptions
    {
        [JsonProperty("oldPassword")]
        public string OldPassword { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }
}
