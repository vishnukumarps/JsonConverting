using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverting
{
    public partial class MyFileStructure
    {

        public string Node { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }

        public List<MyFileStructure> Children { get; set; }
    }
}
