using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class Restaraunt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<RestarauntReview> Reviews { get; set; } //Need virtual here because of the db relationship w/o it will through error in reviews controller

    }
}