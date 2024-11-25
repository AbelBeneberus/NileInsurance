using Microsoft.AspNetCore.Identity;

namespace Election.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roleNames = { "Elector", "SuperAdmin", "Nominee" };
        
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Create a SuperAdmin user if not exists and assign SuperAdmin role
        var superAdminEmail = "superadmin@example.com";
        var superAdminPassword = "SuperAdminPassword123!";

        if (userManager.Users.All(u => u.UserName != superAdminEmail))
        {
            var user = new ApplicationUser() { UserName = superAdminEmail, Email = superAdminEmail };
            var result = await userManager.CreateAsync(user, superAdminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "SuperAdmin");
            }
        }

        // Repeat for other roles if necessary
    }
}