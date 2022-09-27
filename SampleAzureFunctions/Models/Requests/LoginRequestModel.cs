using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SampleAzureFunctions.Models.Requests
{
    [Serializable]
    public class LoginRequestModel
    {
        [Required]
        [StringLength(9)]
        public string UserId  { get; set; }
        [Required]
        //TODO:桁数検討
        public string Password { get; set; }
    }
}
