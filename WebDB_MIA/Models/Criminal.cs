using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDB_MIA.Models
{
    public class Criminal
    {
        [Display(Name = "Номер дела")]
        public long ID { get; set; }
        [Display(Name = "ФИО")]
        public string Name { get; set; }
        [Display(Name = "Дата рождения")]
        public string Description { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Код вида преступления")]
        public long? TypesCrimesID { get; set; }
        [Display(Name = "Вид преступления")]
        public TypeCrime TypesCrimes { get; set; }
        [Display(Name = "Код пострадавшего")]
        public long? CasualtiesID { get; set; }
        [Display(Name = "Пострадавший")]
        public Casualtie Casualties { get; set; }
        [Display(Name = "Состояние")]
        public string Status { get; set; }
        [Display(Name = "Код сотрудника")]
        public long? StaffID { get; set; }
        [Display(Name = "Сотрудник")]
        public Staff Staff { get; set; }

    }
}
