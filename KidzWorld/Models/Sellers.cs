using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace KidzWorld.Models
{
    public class Sellers
    {
        [Key]
        public int SellerID { get; set; }

        [Required]
        [StringLength(100)] 
        public string SellerName { get; set; }
        public string SellerAddress { get; set; }
        public string SellerContact { get; set; }
        public string ContactPerson { get; set; }

        public virtual ICollection<Toys> SellersToys { get; set; }

        public virtual ICollection<SellerReview> SellerReviews { get; set; }

        [NotMapped]
        public SingleFileUpload File { get; set; }

    }
    public class SingleFileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
