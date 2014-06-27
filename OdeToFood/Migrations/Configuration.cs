namespace OdeToFood.Migrations
{
    using OdeToFood.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    //using System.Web.Security;
    using WebMatrix.WebData;


    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            //AddOrUpdate
            context.Restaraunts.AddOrUpdate(r=>r.Name,
                new Restaraunt {Name="Sabatinos",City="Baltimore",Country="USA"},
                new Restaraunt {Name="Great Lake",City="chicago",Country="USA"},
                new Restaraunt {
                    Name="Smaka",City="Gothenberg",Country="Sweden",
                    Reviews=new List<RestarauntReview> {
                        new RestarauntReview {Rating=9,Body="Great Food",ReviewerName="Brad Rosen"}
                }
                });
            for (int i = 0; i < 1000; i++)
                context.Restaraunts.AddOrUpdate(r => r.Name, new Restaraunt { Name = i.ToString(), City = "Nowhere", Country = "USA" });


            SeedMemberShip();
        }

        private void SeedMemberShip()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("sallen", false) == null)
            {
                membership.CreateUserAndAccount("sallen", "imalittleteapot");
            }
            if (!roles.GetRolesForUser("sallen").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "sallen" }, new[] { "admin" });
            }
            if (!roles.GetRolesForUser("brosen").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "brosen" }, new[] { "admin" });
            }
        }
    }
}
