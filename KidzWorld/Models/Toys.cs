using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KidzWorld.Models
{
    public class Toys
    {
        [Key]
        public int ToyID { get; set; }

        [Required]
        [StringLength(50)]
        public string ToyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Price { get; set; }

        public string ToyDescription { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }
        
        [Required]
        public int AgeID { get; set; }

        [ForeignKey("AgeID")]
        [InverseProperty("AgeToys")]
        public virtual Age Ages { get; set; }

        [Required]
        public int SellerID { get; set; }

        [ForeignKey("SellerID")]
        [InverseProperty("SellersToys")]
        public virtual Sellers Sellers { get; set; }

        [NotMapped]
        public SingleFileUploads File { get; set; }
    }

    public class SingleFileUploads
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
