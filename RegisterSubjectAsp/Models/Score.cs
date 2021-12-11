using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterSubjectAsp.Models
{
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_score { get; set; }

        public int id_subject { get; set; }


        public int id_user { get; set; }


        public float mark { get; set; }

        public virtual Subject Subject { get; set; }


        public virtual User User { get; set; }

    }
}