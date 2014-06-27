using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestarauntReview
    {
        public int Id{ get; set; }
        
        [Range(1,10)] //validation attributes
        [Required]    //validation attributes
        public int Rating { get; set; }
        
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        [Display(Name="User Name")]
        [DisplayFormat(NullDisplayText="anonymous")] //only for display in place of null, not saved to db
        public string ReviewerName { get; set; }
        public int RestarauntId { get; set; }

    }
}