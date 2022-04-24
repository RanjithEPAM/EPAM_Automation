using APIAutomationTests.JsonModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationTests.Helper
{
    public static class Reusable_Methods
    {
        public static string FrameRequest(string name, string job)
        {
            var userData = new Request 
            { Name = name, 
              Job = job 
            };

            string jsonstring = JsonConvert.SerializeObject(userData);

            return jsonstring;
        }
    }
}
