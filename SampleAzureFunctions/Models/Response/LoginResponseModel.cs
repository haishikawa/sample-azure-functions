using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Models.Response
{
    public class LoginResponseModel
    {
        //TODO:会社コードを含めるか検討
        public string Name { get; set; }
        public string KaishaName { get; set; }
        public string BushoName { get; set; }
    }
}
