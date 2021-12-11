using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterSubjectAsp.Models
{
    public class Course
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_course { get; set; }

        [StringLength(255)]
        [Required]
        public string faculty { get; set; }

        public int id_subject { get; set; }

        public virtual Subject Subject { get; set; }
    }
}