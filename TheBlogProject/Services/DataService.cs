using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheBlogProject.Data;
using TheBlogProject.Enums;
using TheBlogProject.Models;

namespace TheBlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<BlogUser> userManager)
        {
            _context = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            //Task: Create the DB from the Migrations
            await _context.Database.MigrateAsync();

            //Task 1: Seed a few roles into the system
            await SeedRolesAsync();

            //Task 2: Seed a few users into the system
            await SeedUsersAsync();

        }

        private async Task SeedRolesAsync()
        {
            //If there are already Roles in the system, do nothing.
            if (_context.Roles.Any())
            {
                return;
            }

            //Otherwise we want to create a few Roles
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }


        private async Task SeedUsersAsync()
        {
            //If there are already users in the system, do nothing.
            if (_context.Users.Any())
            {
                return;
            }

            //Otherwise we want to create a few Users

            //Step 1: Create an new instance of BlogUser for an admin user
            var adminUser = new BlogUser()
            {
                Email = "sandeed70@gmail.com",
                UserName = "sandeed70@gmail.com",
                FirstName = "Saeed",
                LastName = "Adam",
                PhoneNumber = "(800) 555-1212",
                EmailConfirmed = true
            };

            //Step 2: Use the User Manager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "saeed44@@S");


            //Step 3: Add this new user to the Administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());


            //------------------------------------------//

            //Step 1 repeat: Create a Moderator User
            var modUser = new BlogUser()
            {
                Email = "Ahmed@gmail.com",
                UserName = "Ahmed@gmail.com",
                FirstName = "Ahmed",
                LastName = "Mahmoud",
                PhoneNumber = "(800) 555-5050",
                EmailConfirmed = true
            };

            //Step 2 repeat: Use the User Manager to create a new user that is defined by modUser
            await _userManager.CreateAsync(modUser, "saeed44@@S");


            //Step 3 repeat: Add this new user to the Moderator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }


    }
}
