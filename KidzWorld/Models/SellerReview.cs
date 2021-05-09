using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KidzWorld.Models
{
    public class SellerReview
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserID { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        public string ReviewText { get; set; }

        [Required]
        public int SellerID { get; set; }

        
        [ForeignKey("SellerID")]
        [InverseProperty("SellerReviews")]
        public Sellers SellersReviews { get; set; }


        public DateTime ReviewDate { get; set; }

    }
}
