﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kitchen.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidityPeriod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Ingredient = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromCalories = table.Column<int>(type: "int", nullable: false),
                    ToCalories = table.Column<int>(type: "int", nullable: false),
                    PosterId = table.Column<int>(type: "int", nullable: false),
                    DietTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Admins_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_DietTypes_DietTypeId",
                        column: x => x.DietTypeId,
                        principalTable: "DietTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Avarta = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VerifyCode = table.Column<int>(type: "int", nullable: true),
                    StartDateMember = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDateMember = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDays = table.Column<int>(type: "int", nullable: true),
                    MembershipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tutorials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepTile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StepContent = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutorials_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PosterId = table.Column<int>(type: "int", nullable: false),
                    PostCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    MembershipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Account", "Name", "Password" },
                values: new object[] { 1, "admin", "John Administrator", "12345" });

            migrationBuilder.InsertData(
                table: "DietTypes",
                columns: new[] { "Id", "DietName" },
                values: new object[,]
                {
                    { 1, "Daily" },
                    { 2, "Vegetarian" },
                    { 3, "Dietary" },
                    { 4, "Exercise" }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "expert@gmail.com", "John Expert", "12345" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "Price", "ValidityPeriod" },
                values: new object[,]
                {
                    { 1, 80000m, 1 },
                    { 2, 150000m, 2 },
                    { 3, 1600000m, 3 }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Kitchen Story" },
                    { 2, "Handbooks And tip" },
                    { 3, "Knowledge" },
                    { 4, "DeliciousFood" },
                    { 5, "Explore" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "DietTypeId", "FromCalories", "FromPrice", "ImageUrl", "Ingredient", "PostDate", "PosterId", "Title", "ToCalories", "ToPrice" },
                values: new object[,]
                {
                    { 1, "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, limit frequent hunger, and reduce calories in the body.", 1, 500, 30000m, "", "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", new DateTime(2024, 9, 29, 21, 49, 2, 807, DateTimeKind.Local).AddTicks(8103), 1, "Vegetable egg rolls", 800, 70000m },
                    { 2, "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, limit frequent hunger, and reduce calories in the body.", 2, 500, 30000m, "", "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", new DateTime(2024, 9, 29, 21, 49, 2, 807, DateTimeKind.Local).AddTicks(8116), 1, "Vegetable egg rolls", 800, 70000m },
                    { 3, "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, limit frequent hunger, and reduce calories in the body.", 3, 500, 30000m, "", "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", new DateTime(2024, 9, 29, 21, 49, 2, 807, DateTimeKind.Local).AddTicks(8118), 1, "Vegetable egg rolls", 800, 70000m },
                    { 4, "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, limit frequent hunger, and reduce calories in the body.", 4, 500, 30000m, "", "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", new DateTime(2024, 9, 29, 21, 49, 2, 807, DateTimeKind.Local).AddTicks(8120), 1, "Vegetable egg rolls", 800, 70000m },
                    { 5, "Protein in eggs is a source of essential amino acids that play an important role in the body, especially for the development of both weight and height in children. Protein in eggs helps maintain and repair body tissues, including muscles. Lecithin helps lose weight, breaks down and disperses fat in food. In addition, eggs contain many vitamins and minerals necessary for the brain and nervous system to function effectively. Vitamin A, B12 and selenium in eggs help strengthen the immune system. Choline in eggs plays an important role in breaking down the amino acid homocysteine, a key cause of heart disease. Folic acid in eggs helps prevent birth defects in children, and lutein and zeaxanthin prevent macular degeneration. In addition, protein in eggs will help you feel full longer, limit frequent hunger, and reduce calories in the body.", 1, 500, 30000m, "", "4 chicken eggs.1 Onion.1/2 carrot.Green onions 2 branches", new DateTime(2024, 9, 29, 21, 49, 2, 807, DateTimeKind.Local).AddTicks(8122), 1, "Vegetable egg rolls", 800, 70000m }
                });

            migrationBuilder.InsertData(
                table: "Tutorials",
                columns: new[] { "Id", "RecipeId", "StepContent", "StepTile" },
                values: new object[,]
                {
                    { 1, 1, "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot. Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. Remove to a bowl of ice cold water and soak for 5 minutes, then remove to a plate to drain. Beat the eggs", "Step 1 - Prepare vegetables" },
                    { 2, 1, "Crack 4 eggs into a clean bowl, season with 1 tablespoon of seasoning powder, beat well until the yolks and whites blend together.", "Step 2 - Crack" },
                    { 3, 1, "Place the pan on the stove, turn on medium heat and add 1 tablespoon of cooking oil to the pan\nWait for the oil to heat up, then add the eggs and fry for about 3-5 minutes\nWhen the eggs are cooked, put them on a plate, use a spoon to spread the raw sausage on top of the eggs, then add the string beans and carrots, use your hands to roll the ingredients tightly", "Step 3 - Frie eggs" },
                    { 4, 1, "Put the water on the stove, place the steamer basket on the pot, put the rolled eggs in the basket and steam for 7-10 minutes. Wait for the water to boil, then slice the eggs into circles about 1 inch long, arrange them on a plate to enjoy", "Step 4 - Put the water" },
                    { 5, 2, "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot. Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. Remove to a bowl of ice cold water and soak for 5 minutes, then remove to a plate to drain. Beat the eggs", "Step 1 - Prepare vegetables" },
                    { 6, 2, "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot. Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. Remove to a bowl of ice cold water and soak for 5 minutes, then remove to a plate to drain. Beat the eggs", "Step 1 - Prepare vegetables" },
                    { 7, 3, "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot. Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. Remove to a bowl of ice cold water and soak for 5 minutes, then remove to a plate to drain. Beat the eggs", "Step 1 - Prepare vegetables" },
                    { 8, 3, "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot. Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. Remove to a bowl of ice cold water and soak for 5 minutes, then remove to a plate to drain. Beat the eggs", "Step 1 - Prepare vegetables" },
                    { 9, 4, "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot. Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. Remove to a bowl of ice cold water and soak for 5 minutes, then remove to a plate to drain. Beat the eggs", "Step 1 - Prepare vegetables" },
                    { 10, 5, "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot. Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. Remove to a bowl of ice cold water and soak for 5 minutes, then remove to a plate to drain. Beat the eggs", "Step 1 - Prepare vegetables" },
                    { 11, 5, "Peel the carrots, wash them and cut them into long pieces\nCut off the 2 ends and then remove the fibers from both sides of the string beans, rinse with water and put in a basket to drain.\nPut the pot on the stove, add 200ml of water, boil over high heat. When the water boils, add 1/2 teaspoon of salt to the pot. Add carrots and string beans to a pot of boiling water and boil for about 5-7 minutes. Remove to a bowl of ice cold water and soak for 5 minutes, then remove to a plate to drain. Beat the eggs", "Step 2 - Prepare vegetables" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_UserId",
                table: "Plan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCategoryId",
                table: "Posts",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PosterId",
                table: "Posts",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DietTypeId",
                table: "Recipes",
                column: "DietTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_PosterId",
                table: "Recipes",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MembershipId",
                table: "Transactions",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutorials_RecipeId",
                table: "Tutorials",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MembershipId",
                table: "Users",
                column: "MembershipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Tutorials");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "DietTypes");

            migrationBuilder.DropTable(
                name: "Membership");
        }
    }
}
