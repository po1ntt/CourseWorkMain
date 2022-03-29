using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Model
{
   public class Category
    {
        public int CathegoryId { get; set; }
        public string CathegoryName { get; set; }
        public string ImageUrl { get; set; }
        public int TemaID { get; set; }
    }
}
