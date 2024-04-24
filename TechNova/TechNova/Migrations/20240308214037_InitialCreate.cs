using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechNova.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    DiscountPrice = table.Column<double>(type: "float", nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderFormModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCodeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFormModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    DiscountPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "CartCartProduct",
                columns: table => new
                {
                    CartProductsId = table.Column<int>(type: "int", nullable: false),
                    CartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartCartProduct", x => new { x.CartProductsId, x.CartsId });
                    table.ForeignKey(
                        name: "FK_CartCartProduct_CartProduct_CartProductsId",
                        column: x => x.CartProductsId,
                        principalTable: "CartProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartCartProduct_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFormId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderFormModel_OrderFormId",
                        column: x => x.OrderFormId,
                        principalTable: "OrderFormModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Future Tech" },
                    { 2, "Wearable Gadgets" },
                    { 3, "Smart Home Devices" },
                    { 4, "Virtual Reality" },
                    { 5, "Space Exploration Gear" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Discount", "DiscountPrice", "ImgUri", "LongDescription", "OnSale", "Price", "Quantity", "ShortDescription", "Title" },
                values: new object[,]
                {
                    { 1, 10.0, 0.0, "./img/Products/quantum_computer.jpg", "Harness the power of quantum computing with our cutting-edge desktop model, designed for complex simulations and cryptography.", true, 50000.0, 25, "Next-gen quantum computing.", "Quantum Computer" },
                    { 2, 0.0, 0.0, "./img/Products/holographic_display.jpg", "Experience immersive 3D projections in your living room with our high-definition holographic display system.", false, 15000.0, 40, "3D holographic projection.", "Holographic Display" },
                    { 3, 10.0, 0.0, "./img/Products/smart_fabric_suit.jpg", "Stay comfortable in any climate with our smart fabric suit, featuring adaptive temperature control and health monitoring.", true, 8000.0, 70, "Adaptive temperature control suit.", "Smart Fabric Suit" },
                    { 4, 0.0, 0.0, "./img/Products/ar_glasses.jpg", "See the world like never before with our augmented reality glasses, offering real-time information overlay and interactive experiences.", false, 7000.0, 85, "AR enhanced vision.", "Augmented Reality Glasses" },
                    { 5, 20.0, 0.0, "./img/Products/ai_personal_assistant.jpg", "Meet your new best friend and assistant, powered by advanced AI to help manage your life and entertain you.", true, 10000.0, 50, "Your AI companion.", "AI Personal Assistant" },
                    { 6, 0.0, 0.0, "./img/Products/vr_gaming_set.jpg", "Step into another world with our virtual reality gaming set, designed for unparalleled immersion and interaction.", false, 12000.0, 60, "Immersive gaming experience.", "Virtual Reality Gaming Set" },
                    { 7, 30.0, 0.0, "./img/Products/orbital_spacecraft.jpg", "Explore the final frontier with your own orbital spacecraft, equipped with the latest in space travel technology.", true, 250000.0, 10, "Personal space exploration.", "Orbital Spacecraft Model" },
                    { 8, 0.0, 0.0, "./img/Products/bio_enhancement_chip.jpg", "Upgrade your physical and cognitive abilities with our safe and reversible bio-enhancement chips.", false, 4000.0, 100, "Enhance your abilities.", "Bio-Enhancement Chip" },
                    { 9, 10.0, 0.0, "./img/Products/teleportation_device.jpg", "Redefine the way you travel with our state-of-the-art teleportation device, offering instant transportation to preset locations.", true, 100000.0, 15, "Instant travel technology.", "Teleportation Device" },
                    { 10, 0.0, 0.0, "./img/Products/nano_repair_kit.jpg", "Fix anything at a molecular level with our nano repair kit, from clothing to electronics, using advanced nanotechnology.", false, 5000.0, 80, "Self-repairing technology.", "Nano Repair Kit" },
                    { 11, 10.0, 0.0, "./img/Products/anti_gravity_skateboard.jpg", "Glide through the air with our anti-gravity skateboard, offering a frictionless and exhilarating riding experience.", true, 20000.0, 40, "Levitating skateboarding experience.", "Anti-Gravity Skateboard" },
                    { 12, 0.0, 0.0, "./img/Products/smart_mirror.jpg", "Transform your morning routine with our smart mirror, displaying news, weather, and personal health stats while you get ready.", false, 8000.0, 50, "Interactive home mirror.", "Smart Mirror" },
                    { 13, 20.0, 0.0, "./img/Products/portable_fusion_reactor.jpg", "Power your home or spaceship with our portable fusion reactor, providing safe, clean, and limitless energy.", true, 150000.0, 20, "Unlimited clean energy.", "Portable Fusion Reactor" },
                    { 14, 0.0, 0.0, "./img/Products/self_cleaning_clothing.jpg", "Never wash your clothes again with our self-cleaning clothing line, utilizing nanotechnology to repel dirt and odors.", false, 3000.0, 100, "Hygiene and convenience.", "Self-Cleaning Clothing" },
                    { 15, 20.0, 0.0, "./img/Products/mind_controlled_drones.jpg", "Pilot drones with your mind using our cutting-edge neural interface, perfect for photography, racing, or surveillance.", true, 12000.0, 30, "Thought-driven drone technology.", "Mind-Controlled Drones" },
                    { 16, 0.0, 0.0, "./img/Products/underwater_habitat.jpg", "Live or work under the sea with our underwater habitat module, equipped with life support and research facilities.", false, 250000.0, 5, "Explore oceanic depths.", "Underwater Habitat Module" },
                    { 17, 10.0, 0.0, "./img/Products/genetic_customization_kit.jpg", "Design your future offspring or modify certain traits with our safe, ethical genetic customization kit.", true, 50000.0, 25, "Personalized genetic engineering.", "Genetic Customization Kit" },
                    { 18, 0.0, 0.0, "./img/Products/haptic_feedback_suit.jpg", "Feel the virtual world with our haptic feedback suit, providing realistic sensations for gaming, training, or virtual travel.", false, 10000.0, 45, "Full-body immersive experience.", "Haptic Feedback Suit" },
                    { 19, 30.0, 0.0, "./img/Products/wireless_energy_transmitter.jpg", "Power devices anywhere in your home without cables using our efficient and safe wireless energy transmitter.", true, 18000.0, 60, "Cordless power supply.", "Wireless Energy Transmitter" },
                    { 20, 0.0, 0.0, "./img/Products/ai_pet.jpg", "Enjoy the companionship of a pet that learns and evolves with you, without any of the hassle, thanks to our AI technology.", false, 7000.0, 80, "The ultimate companion.", "Artificial Intelligence Pet" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 13 },
                    { 1, 17 },
                    { 1, 19 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 8 },
                    { 2, 14 },
                    { 2, 18 },
                    { 3, 5 },
                    { 3, 12 },
                    { 3, 20 },
                    { 4, 6 },
                    { 4, 15 },
                    { 5, 7 },
                    { 5, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartCartProduct_CartsId",
                table: "CartCartProduct",
                column: "CartsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderFormId",
                table: "Orders",
                column: "OrderFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CartId",
                table: "Users",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartCartProduct");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderFormModel");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
