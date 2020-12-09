using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDB_MIA.Models
{
    public class TypeCrime
    {
        [Display(Name = "Код вида преступления")]
        public long ID { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Статья")]
        public string Item { get; set; }
        [Display(Name = "Наказание")]
        public string Judgment { get; set; }
        [Display(Name = "Срок")]
        public int Time { get; set; }


        public IList<Criminal> Criminal { get; set; }
    }
}
