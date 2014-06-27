using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class OdeToFoodDb : DbContext
    {
        public OdeToFoodDb()
            : base("name=DefaultConnection") //connection hint from web.config
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaraunt> Restaraunts { get; set; }
        public DbSet<RestarauntReview> Reviews { get; set; }
        
    }
}