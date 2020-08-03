using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class XMSselect
    {
        public string name { get; set; }
        public string value { get; set; }
        public string selected { get; set; }
        public string disabled { get; set; }
        public IEnumerable<object> children { get; set; }
    }
}
