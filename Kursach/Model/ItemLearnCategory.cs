using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Model
{
   public class ItemLearnCategory
    {
        public int id_itemLearn { get; set; }
        public string NameItemLearn { get; set; }
        public string Url_toLerningSite { get; set; }
        public string ImageUrlItem { get; set; }
        public int id_LearCathegory { get; set; }
    }
}
