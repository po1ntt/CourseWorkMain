using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Model
{
    public class Tests
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string LearningUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
