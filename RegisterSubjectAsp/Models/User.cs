using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterSubjectAsp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_user { get; set; }

        [StringLength(255)]
        [Required]
        public string username { get; set; }

        [StringLength(255)]
        [Required]
        public string email { get; set; }

        [StringLength(255)]
        [Required]
        public string password { get; set; }

        [StringLength(255)]
        [Required]
        public string fullname { get; set; }

        [StringLength(255)]
        public string phoneNumber { get; set; }

        [StringLength(255)]
        [Required]
        public string address { get; set; }

        public int gender { get; set; }

        [StringLength(255)]
        [Required]
        public string birthday { get; set; }

        public int status { get; set; }

        public int id_role { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Score> Scores { get;set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}