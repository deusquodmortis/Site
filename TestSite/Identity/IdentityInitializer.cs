using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestSite.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Roller
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager =new RoleManager<ApplicationRole>(store);
                var role=new ApplicationRole(){Name = "admin",Description = "admin rolu"};
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolu" };
                manager.Create(role);
            }
            if (!context.Users.Any(i => i.Name == "mehmetkenan"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser(){Name="mehmet",Surname = "kenan",UserName = "deusquodmortis",Email = "unalkenan98@hotmail.com"};

                userManager.Create(user,"1234567");
                userManager.AddToRole(user.Id, "admin");
                userManager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "ahmetmehmet"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "ahmet", Surname = "mehmet", UserName = "ahmetmehmet", Email = "ahmetmehmet@hotmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }


            //User


            base.Seed(context);
        }
    }
}