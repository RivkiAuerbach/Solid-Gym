using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Entities
{
    public class Training
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Day { get; set; }
        public double Hour { get; set; }
        public int GuideId { get; set; }
        public Guide Guide { get; set; }
        public List<Student> Student { get; set; }

    }
}
