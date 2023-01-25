using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlTxt
{
    public class Files
    {
        public string FullName { get; set; }
        public string Name { get; set; }

        public Files(string fullName, string name)
        {
            FullName = fullName;
            Name = name;
        }
    }
}
