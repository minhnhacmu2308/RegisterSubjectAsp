using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterSubjectAsp.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_subject { get; set; }

        [StringLength(255)]
        [Required]
        public string name { get; set; }
        public int status { get; set; }

        [StringLength(255)]
        public string code { get; set; }

        [StringLength(255)]
        public string credit { get; set; }

        public DateTime start_day { get; set; }

        public DateTime end_day { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Score> Scores { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}