using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterSubjectAsp.Models
{
    public class ScheduleStudent
    {
        [Key]
        [Column(Order = 1)]
        public int id_user { get; set; }

        [Key]
        [Column(Order = 2)]
        public int id_schedule { get; set; }

        public virtual User User { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}