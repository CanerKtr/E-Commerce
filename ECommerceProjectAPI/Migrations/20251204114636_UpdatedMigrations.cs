using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_userId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_userId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Products_productId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Employees_mgrId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_cartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_productId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_customerId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_branchId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_supervisorId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_userId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Products_productId",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_orderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_productId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Products_productId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Employees_salesPersonId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "userLastName",
                table: "Users",
                newName: "UserLastName");

            migrationBuilder.RenameColumn(
                name: "userFirstName",
                table: "Users",
                newName: "UserFirstName");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "dateOfBirth",
                table: "Users",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Products",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "stockQuantity",
                table: "Products",
                newName: "StockQuantity");

            migrationBuilder.RenameColumn(
                name: "salesPersonId",
                table: "Products",
                newName: "SalesPersonId");

            migrationBuilder.RenameColumn(
                name: "productPrice",
                table: "Products",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "productCategory",
                table: "Products",
                newName: "ProductCategory");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Products",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_salesPersonId",
                table: "Products",
                newName: "IX_Products_SalesPersonId");

            migrationBuilder.RenameColumn(
                name: "storageCapacityGB",
                table: "Phones",
                newName: "StorageCapacityGB");

            migrationBuilder.RenameColumn(
                name: "screenSizeInches",
                table: "Phones",
                newName: "ScreenSizeInches");

            migrationBuilder.RenameColumn(
                name: "cameraMegapixels",
                table: "Phones",
                newName: "CameraMegapixels");

            migrationBuilder.RenameColumn(
                name: "brand",
                table: "Phones",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Phones",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "Orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "orderStatus",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "orderDate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "unitPrice",
                table: "OrderItems",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "OrderItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "discountPercentage",
                table: "OrderItems",
                newName: "DiscountPercentage");

            migrationBuilder.RenameColumn(
                name: "orderItemId",
                table: "OrderItems",
                newName: "OrderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_productId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_orderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameColumn(
                name: "screenSizeInches",
                table: "Laptops",
                newName: "ScreenSizeInches");

            migrationBuilder.RenameColumn(
                name: "ramSizeGB",
                table: "Laptops",
                newName: "RamSizeGB");

            migrationBuilder.RenameColumn(
                name: "processor",
                table: "Laptops",
                newName: "Processor");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Laptops",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "totalSales",
                table: "Employees",
                newName: "TotalSales");

            migrationBuilder.RenameColumn(
                name: "supervisorId",
                table: "Employees",
                newName: "SupervisorId");

            migrationBuilder.RenameColumn(
                name: "salary",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "branchId",
                table: "Employees",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Employees",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_supervisorId",
                table: "Employees",
                newName: "IX_Employees_SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_branchId",
                table: "Employees",
                newName: "IX_Employees_BranchId");

            migrationBuilder.RenameColumn(
                name: "customerLevel",
                table: "Customers",
                newName: "CustomerLevel");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Customers",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Customers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Carts",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "cartId",
                table: "Carts",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_customerId",
                table: "Carts",
                newName: "IX_Carts_CustomerId");

            migrationBuilder.RenameColumn(
                name: "unitPrice",
                table: "CartItems",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "CartItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "CartItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "cartId",
                table: "CartItems",
                newName: "CartId");

            migrationBuilder.RenameColumn(
                name: "cartItemId",
                table: "CartItems",
                newName: "CartItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_productId",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_cartId",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.RenameColumn(
                name: "totalSales",
                table: "Branches",
                newName: "TotalSales");

            migrationBuilder.RenameColumn(
                name: "mgrId",
                table: "Branches",
                newName: "MgrId");

            migrationBuilder.RenameColumn(
                name: "branchName",
                table: "Branches",
                newName: "BranchName");

            migrationBuilder.RenameColumn(
                name: "branchId",
                table: "Branches",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_mgrId",
                table: "Branches",
                newName: "IX_Branches_MgrId");

            migrationBuilder.RenameColumn(
                name: "publisher",
                table: "Books",
                newName: "Publisher");

            migrationBuilder.RenameColumn(
                name: "numberOfPages",
                table: "Books",
                newName: "NumberOfPages");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Books",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "Books",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Books",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Admins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Addresses",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "Addresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Addresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "addressName",
                table: "Addresses",
                newName: "AddressName");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "Addresses",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_userId",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StorageCapacityGB",
                table: "Phones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "ScreenSizeInches",
                table: "Phones",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "CameraMegapixels",
                table: "Phones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercentage",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "ScreenSizeInches",
                table: "Laptops",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "RamSizeGB",
                table: "Laptops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSales",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSales",
                table: "Branches",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPages",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Products_ProductId",
                table: "Books",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Employees_MgrId",
                table: "Branches",
                column: "MgrId",
                principalTable: "Employees",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_CustomerId",
                table: "Carts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_BranchId",
                table: "Employees",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_SupervisorId",
                table: "Employees",
                column: "SupervisorId",
                principalTable: "Employees",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Products_ProductId",
                table: "Laptops",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Products_ProductId",
                table: "Phones",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Employees_SalesPersonId",
                table: "Products",
                column: "SalesPersonId",
                principalTable: "Employees",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Products_ProductId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Employees_MgrId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_CustomerId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branches_BranchId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_SupervisorId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Products_ProductId",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Products_ProductId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Employees_SalesPersonId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserLastName",
                table: "Users",
                newName: "userLastName");

            migrationBuilder.RenameColumn(
                name: "UserFirstName",
                table: "Users",
                newName: "userFirstName");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "dateOfBirth");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Products",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "stockQuantity");

            migrationBuilder.RenameColumn(
                name: "SalesPersonId",
                table: "Products",
                newName: "salesPersonId");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Products",
                newName: "productPrice");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "ProductCategory",
                table: "Products",
                newName: "productCategory");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Products",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Products",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SalesPersonId",
                table: "Products",
                newName: "IX_Products_salesPersonId");

            migrationBuilder.RenameColumn(
                name: "StorageCapacityGB",
                table: "Phones",
                newName: "storageCapacityGB");

            migrationBuilder.RenameColumn(
                name: "ScreenSizeInches",
                table: "Phones",
                newName: "screenSizeInches");

            migrationBuilder.RenameColumn(
                name: "CameraMegapixels",
                table: "Phones",
                newName: "cameraMegapixels");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Phones",
                newName: "brand");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Phones",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Orders",
                newName: "totalAmount");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Orders",
                newName: "orderStatus");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "orderDate");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "customerId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "orderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_customerId");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderItems",
                newName: "unitPrice");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItems",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "OrderItems",
                newName: "discountPercentage");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "OrderItems",
                newName: "orderItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_orderId");

            migrationBuilder.RenameColumn(
                name: "ScreenSizeInches",
                table: "Laptops",
                newName: "screenSizeInches");

            migrationBuilder.RenameColumn(
                name: "RamSizeGB",
                table: "Laptops",
                newName: "ramSizeGB");

            migrationBuilder.RenameColumn(
                name: "Processor",
                table: "Laptops",
                newName: "processor");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Laptops",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "TotalSales",
                table: "Employees",
                newName: "totalSales");

            migrationBuilder.RenameColumn(
                name: "SupervisorId",
                table: "Employees",
                newName: "supervisorId");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Employees",
                newName: "branchId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Employees",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SupervisorId",
                table: "Employees",
                newName: "IX_Employees_supervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                newName: "IX_Employees_branchId");

            migrationBuilder.RenameColumn(
                name: "CustomerLevel",
                table: "Customers",
                newName: "customerLevel");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Customers",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Customers",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Carts",
                newName: "customerId");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carts",
                newName: "cartId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                newName: "IX_Carts_customerId");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "CartItems",
                newName: "unitPrice");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "CartItems",
                newName: "cartId");

            migrationBuilder.RenameColumn(
                name: "CartItemId",
                table: "CartItems",
                newName: "cartItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_productId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                newName: "IX_CartItems_cartId");

            migrationBuilder.RenameColumn(
                name: "TotalSales",
                table: "Branches",
                newName: "totalSales");

            migrationBuilder.RenameColumn(
                name: "MgrId",
                table: "Branches",
                newName: "mgrId");

            migrationBuilder.RenameColumn(
                name: "BranchName",
                table: "Branches",
                newName: "branchName");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Branches",
                newName: "branchId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_MgrId",
                table: "Branches",
                newName: "IX_Branches_mgrId");

            migrationBuilder.RenameColumn(
                name: "Publisher",
                table: "Books",
                newName: "publisher");

            migrationBuilder.RenameColumn(
                name: "NumberOfPages",
                table: "Books",
                newName: "numberOfPages");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Books",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Books",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Admins",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Addresses",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Addresses",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Addresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "AddressName",
                table: "Addresses",
                newName: "addressName");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Addresses",
                newName: "addressId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                newName: "IX_Addresses_userId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "storageCapacityGB",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "screenSizeInches",
                table: "Phones",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cameraMegapixels",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "discountPercentage",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "screenSizeInches",
                table: "Laptops",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ramSizeGB",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "totalSales",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "balance",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "totalSales",
                table: "Branches",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "numberOfPages",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_userId",
                table: "Addresses",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_userId",
                table: "Admins",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Products_productId",
                table: "Books",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Employees_mgrId",
                table: "Branches",
                column: "mgrId",
                principalTable: "Employees",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_cartId",
                table: "CartItems",
                column: "cartId",
                principalTable: "Carts",
                principalColumn: "cartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_productId",
                table: "CartItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_customerId",
                table: "Carts",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_userId",
                table: "Customers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branches_branchId",
                table: "Employees",
                column: "branchId",
                principalTable: "Branches",
                principalColumn: "branchId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_supervisorId",
                table: "Employees",
                column: "supervisorId",
                principalTable: "Employees",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_userId",
                table: "Employees",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Products_productId",
                table: "Laptops",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_orderId",
                table: "OrderItems",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_productId",
                table: "OrderItems",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customerId",
                table: "Orders",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Products_productId",
                table: "Phones",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Employees_salesPersonId",
                table: "Products",
                column: "salesPersonId",
                principalTable: "Employees",
                principalColumn: "userId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
