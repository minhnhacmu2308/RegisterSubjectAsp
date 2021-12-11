using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterSubjectAsp.Models
{
    public class Schedule
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_schedule { get; set; }

        public int id_subject { get; set; }

        public int id_user { get; set; }

        public int id_grade { get; set; }


        public DateTime open_day { get; set; }

        public DateTime close_day { get; set; }

        public int status { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual User User { get; set; }

        public virtual Grade Grade { get; set; }

    }
}