using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidzWorld.Models
{
    public class Age
    {
        [Key]
        public int AgeID { get; set; }

        [Required]
        [StringLength(100)]
        public string AgeName { get; set; }

        public virtual ICollection<Toys> AgeToys { get; set; }

    }
}
