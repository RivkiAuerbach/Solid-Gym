using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public class Guide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Seniority { get; set; }
        public List<Training> training { get; set; }


    }
}
