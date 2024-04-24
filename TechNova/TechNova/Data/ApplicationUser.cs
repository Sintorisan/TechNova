using Microsoft.AspNetCore.Identity;
using TechNova.Shared.Classes.Entities;

namespace TechNova.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int CartId { get; set; }
        public Cart CurrentCart { get; set; } = new Cart();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
