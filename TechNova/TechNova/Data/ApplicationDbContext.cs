using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechNova.Shared.Classes.Entities;

namespace TechNova.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Cart> Carts { get; set; }
    //public DbSet<CartProduct> CartProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(p => new { p.UserId, p.RoleId });
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(x => x.UserId);
        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });


        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Future Tech" },
            new Category { Id = 2, Name = "Wearable Gadgets" },
            new Category { Id = 3, Name = "Smart Home Devices" },
            new Category { Id = 4, Name = "Virtual Reality" },
            new Category { Id = 5, Name = "Space Exploration Gear" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Title = "Quantum Computer", Price = 50000, OnSale = true, Discount = 10, ImgUri = "./img/Products/quantum_computer.jpg", ShortDescription = "Next-gen quantum computing.", LongDescription = "Harness the power of quantum computing with our cutting-edge desktop model, designed for complex simulations and cryptography.", Quantity = 25 },
            new Product { Id = 2, Title = "Holographic Display", Price = 15000, OnSale = false, ImgUri = "./img/Products/holographic_display.jpg", ShortDescription = "3D holographic projection.", LongDescription = "Experience immersive 3D projections in your living room with our high-definition holographic display system.", Quantity = 40 },
            new Product { Id = 3, Title = "Smart Fabric Suit", Price = 8000, OnSale = true, Discount = 10, ImgUri = "./img/Products/smart_fabric_suit.jpg", ShortDescription = "Adaptive temperature control suit.", LongDescription = "Stay comfortable in any climate with our smart fabric suit, featuring adaptive temperature control and health monitoring.", Quantity = 70 },
            new Product { Id = 4, Title = "Augmented Reality Glasses", Price = 7000, OnSale = false, ImgUri = "./img/Products/ar_glasses.jpg", ShortDescription = "AR enhanced vision.", LongDescription = "See the world like never before with our augmented reality glasses, offering real-time information overlay and interactive experiences.", Quantity = 85 },
            new Product { Id = 5, Title = "AI Personal Assistant", Price = 10000, OnSale = true, Discount = 20, ImgUri = "./img/Products/ai_personal_assistant.jpg", ShortDescription = "Your AI companion.", LongDescription = "Meet your new best friend and assistant, powered by advanced AI to help manage your life and entertain you.", Quantity = 50 },
            new Product { Id = 6, Title = "Virtual Reality Gaming Set", Price = 12000, OnSale = false, ImgUri = "./img/Products/vr_gaming_set.jpg", ShortDescription = "Immersive gaming experience.", LongDescription = "Step into another world with our virtual reality gaming set, designed for unparalleled immersion and interaction.", Quantity = 60 },
            new Product { Id = 7, Title = "Orbital Spacecraft Model", Price = 250000, OnSale = true, Discount = 30, ImgUri = "./img/Products/orbital_spacecraft.jpg", ShortDescription = "Personal space exploration.", LongDescription = "Explore the final frontier with your own orbital spacecraft, equipped with the latest in space travel technology.", Quantity = 10 },
            new Product { Id = 8, Title = "Bio-Enhancement Chip", Price = 4000, OnSale = false, ImgUri = "./img/Products/bio_enhancement_chip.jpg", ShortDescription = "Enhance your abilities.", LongDescription = "Upgrade your physical and cognitive abilities with our safe and reversible bio-enhancement chips.", Quantity = 100 },
            new Product { Id = 9, Title = "Teleportation Device", Price = 100000, OnSale = true, Discount = 10, ImgUri = "./img/Products/teleportation_device.jpg", ShortDescription = "Instant travel technology.", LongDescription = "Redefine the way you travel with our state-of-the-art teleportation device, offering instant transportation to preset locations.", Quantity = 15 },
            new Product { Id = 10, Title = "Nano Repair Kit", Price = 5000, OnSale = false, ImgUri = "./img/Products/nano_repair_kit.jpg", ShortDescription = "Self-repairing technology.", LongDescription = "Fix anything at a molecular level with our nano repair kit, from clothing to electronics, using advanced nanotechnology.", Quantity = 80 },
            new Product { Id = 11, Title = "Anti-Gravity Skateboard", Price = 20000, OnSale = true, Discount = 10, ImgUri = "./img/Products/anti_gravity_skateboard.jpg", ShortDescription = "Levitating skateboarding experience.", LongDescription = "Glide through the air with our anti-gravity skateboard, offering a frictionless and exhilarating riding experience.", Quantity = 40 },
            new Product { Id = 12, Title = "Smart Mirror", Price = 8000, OnSale = false, ImgUri = "./img/Products/smart_mirror.jpg", ShortDescription = "Interactive home mirror.", LongDescription = "Transform your morning routine with our smart mirror, displaying news, weather, and personal health stats while you get ready.", Quantity = 50 },
            new Product { Id = 13, Title = "Portable Fusion Reactor", Price = 150000, OnSale = true, Discount = 20, ImgUri = "./img/Products/portable_fusion_reactor.jpg", ShortDescription = "Unlimited clean energy.", LongDescription = "Power your home or spaceship with our portable fusion reactor, providing safe, clean, and limitless energy.", Quantity = 20 },
            new Product { Id = 14, Title = "Self-Cleaning Clothing", Price = 3000, OnSale = false, ImgUri = "./img/Products/self_cleaning_clothing.jpg", ShortDescription = "Hygiene and convenience.", LongDescription = "Never wash your clothes again with our self-cleaning clothing line, utilizing nanotechnology to repel dirt and odors.", Quantity = 100 },
            new Product { Id = 15, Title = "Mind-Controlled Drones", Price = 12000, OnSale = true, Discount = 20, ImgUri = "./img/Products/mind_controlled_drones.jpg", ShortDescription = "Thought-driven drone technology.", LongDescription = "Pilot drones with your mind using our cutting-edge neural interface, perfect for photography, racing, or surveillance.", Quantity = 30 },
            new Product { Id = 16, Title = "Underwater Habitat Module", Price = 250000, OnSale = false, ImgUri = "./img/Products/underwater_habitat.jpg", ShortDescription = "Explore oceanic depths.", LongDescription = "Live or work under the sea with our underwater habitat module, equipped with life support and research facilities.", Quantity = 5 },
            new Product { Id = 17, Title = "Genetic Customization Kit", Price = 50000, OnSale = true, Discount = 10, ImgUri = "./img/Products/genetic_customization_kit.jpg", ShortDescription = "Personalized genetic engineering.", LongDescription = "Design your future offspring or modify certain traits with our safe, ethical genetic customization kit.", Quantity = 25 },
            new Product { Id = 18, Title = "Haptic Feedback Suit", Price = 10000, OnSale = false, ImgUri = "./img/Products/haptic_feedback_suit.jpg", ShortDescription = "Full-body immersive experience.", LongDescription = "Feel the virtual world with our haptic feedback suit, providing realistic sensations for gaming, training, or virtual travel.", Quantity = 45 },
            new Product { Id = 19, Title = "Wireless Energy Transmitter", Price = 18000, OnSale = true, Discount = 30, ImgUri = "./img/Products/wireless_energy_transmitter.jpg", ShortDescription = "Cordless power supply.", LongDescription = "Power devices anywhere in your home without cables using our efficient and safe wireless energy transmitter.", Quantity = 60 },
            new Product { Id = 20, Title = "Artificial Intelligence Pet", Price = 7000, OnSale = false, ImgUri = "./img/Products/ai_pet.jpg", ShortDescription = "The ultimate companion.", LongDescription = "Enjoy the companionship of a pet that learns and evolves with you, without any of the hassle, thanks to our AI technology.", Quantity = 80 }
        );


        modelBuilder.Entity("CategoryProduct").HasData(
            new { CategoriesId = 1, ProductsId = 1 },
            new { CategoriesId = 1, ProductsId = 2 },
            new { CategoriesId = 1, ProductsId = 9 },
            new { CategoriesId = 1, ProductsId = 10 },
            new { CategoriesId = 1, ProductsId = 11 },
            new { CategoriesId = 1, ProductsId = 13 },
            new { CategoriesId = 1, ProductsId = 17 },
            new { CategoriesId = 1, ProductsId = 19 },
            new { CategoriesId = 2, ProductsId = 3 },
            new { CategoriesId = 2, ProductsId = 4 },
            new { CategoriesId = 2, ProductsId = 8 },
            new { CategoriesId = 2, ProductsId = 14 },
            new { CategoriesId = 2, ProductsId = 18 },
            new { CategoriesId = 3, ProductsId = 5 },
            new { CategoriesId = 3, ProductsId = 12 },
            new { CategoriesId = 3, ProductsId = 20 },
            new { CategoriesId = 4, ProductsId = 6 },
            new { CategoriesId = 4, ProductsId = 15 },
            new { CategoriesId = 5, ProductsId = 7 },
            new { CategoriesId = 5, ProductsId = 16 }

        );
    }
}


