using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Child2
    {
        public string type { get; set; }
        public string name { get; set; }
        public string style { get; set; }
        public string @class { get; set; }
        public List<Child2> children { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public string @class { get; set; }
        public List<Child2> children { get; set; }
    }

}
