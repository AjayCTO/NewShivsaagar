﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularJSAuthentication.API.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SHIVAMEcommerceDBEntities : DbContext
    {
        public SHIVAMEcommerceDBEntities()
            : base("name=SHIVAMEcommerceDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AllProductImage> AllProductImages { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerReview> CustomerReviews { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<emailrecord> emailrecords { get; set; }
        public virtual DbSet<EmailSender> EmailSenders { get; set; }
        public virtual DbSet<FeaturedSupplier> FeaturedSuppliers { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PlanFeature> PlanFeatures { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributesRelation> ProductAttributesRelations { get; set; }
        public virtual DbSet<ProductAttributeWithQuantity> ProductAttributeWithQuantities { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductStatu> ProductStatus { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<ThreshHold> ThreshHolds { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<GetAllEmail> GetAllEmails { get; set; }
        public virtual DbSet<GetAllUsersemail> GetAllUsersemails { get; set; }
        public virtual DbSet<GetAttribute> GetAttributes { get; set; }
        public virtual DbSet<ProductAttribute_view> ProductAttribute_view { get; set; }
        public virtual DbSet<ProductValues_view> ProductValues_view { get; set; }
    
        [DbFunction("SHIVAMEcommerceDBEntities", "SplitString")]
        public virtual IQueryable<SplitString_Result> SplitString(string input, string character)
        {
            var inputParameter = input != null ?
                new ObjectParameter("Input", input) :
                new ObjectParameter("Input", typeof(string));
    
            var characterParameter = character != null ?
                new ObjectParameter("Character", character) :
                new ObjectParameter("Character", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<SplitString_Result>("[SHIVAMEcommerceDBEntities].[SplitString](@Input, @Character)", inputParameter, characterParameter);
        }
    
        public virtual int GetProductsCount(string supplierId)
        {
            var supplierIdParameter = supplierId != null ?
                new ObjectParameter("SupplierId", supplierId) :
                new ObjectParameter("SupplierId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetProductsCount", supplierIdParameter);
        }
    
        public virtual int GetProductsDetail(string supplierId)
        {
            var supplierIdParameter = supplierId != null ?
                new ObjectParameter("SupplierId", supplierId) :
                new ObjectParameter("SupplierId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetProductsDetail", supplierIdParameter);
        }
    
        public virtual int InsertProduct(string name, string productCode, string description, string categoryName, string unitOfMeasure, string manuFacturer, Nullable<int> supplierID, ObjectParameter productID, Nullable<int> categoryID, Nullable<int> manufacturerID, Nullable<int> unitOfMeasureID)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var productCodeParameter = productCode != null ?
                new ObjectParameter("ProductCode", productCode) :
                new ObjectParameter("ProductCode", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("categoryName", categoryName) :
                new ObjectParameter("categoryName", typeof(string));
    
            var unitOfMeasureParameter = unitOfMeasure != null ?
                new ObjectParameter("UnitOfMeasure", unitOfMeasure) :
                new ObjectParameter("UnitOfMeasure", typeof(string));
    
            var manuFacturerParameter = manuFacturer != null ?
                new ObjectParameter("ManuFacturer", manuFacturer) :
                new ObjectParameter("ManuFacturer", typeof(string));
    
            var supplierIDParameter = supplierID.HasValue ?
                new ObjectParameter("SupplierID", supplierID) :
                new ObjectParameter("SupplierID", typeof(int));
    
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("categoryID", categoryID) :
                new ObjectParameter("categoryID", typeof(int));
    
            var manufacturerIDParameter = manufacturerID.HasValue ?
                new ObjectParameter("ManufacturerID", manufacturerID) :
                new ObjectParameter("ManufacturerID", typeof(int));
    
            var unitOfMeasureIDParameter = unitOfMeasureID.HasValue ?
                new ObjectParameter("UnitOfMeasureID", unitOfMeasureID) :
                new ObjectParameter("UnitOfMeasureID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertProduct", nameParameter, productCodeParameter, descriptionParameter, categoryNameParameter, unitOfMeasureParameter, manuFacturerParameter, supplierIDParameter, productID, categoryIDParameter, manufacturerIDParameter, unitOfMeasureIDParameter);
        }
    
        public virtual int InsertProductAttributes(string attributeValues, Nullable<decimal> productPrice, Nullable<decimal> productQuantity, Nullable<int> productId, Nullable<decimal> unitInStock, Nullable<decimal> unitWeight, Nullable<decimal> highQuantityThreshold, Nullable<decimal> lowQuantityThreshold, string productStatus, Nullable<int> statusID)
        {
            var attributeValuesParameter = attributeValues != null ?
                new ObjectParameter("AttributeValues", attributeValues) :
                new ObjectParameter("AttributeValues", typeof(string));
    
            var productPriceParameter = productPrice.HasValue ?
                new ObjectParameter("ProductPrice", productPrice) :
                new ObjectParameter("ProductPrice", typeof(decimal));
    
            var productQuantityParameter = productQuantity.HasValue ?
                new ObjectParameter("ProductQuantity", productQuantity) :
                new ObjectParameter("ProductQuantity", typeof(decimal));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            var unitInStockParameter = unitInStock.HasValue ?
                new ObjectParameter("UnitInStock", unitInStock) :
                new ObjectParameter("UnitInStock", typeof(decimal));
    
            var unitWeightParameter = unitWeight.HasValue ?
                new ObjectParameter("UnitWeight", unitWeight) :
                new ObjectParameter("UnitWeight", typeof(decimal));
    
            var highQuantityThresholdParameter = highQuantityThreshold.HasValue ?
                new ObjectParameter("HighQuantityThreshold", highQuantityThreshold) :
                new ObjectParameter("HighQuantityThreshold", typeof(decimal));
    
            var lowQuantityThresholdParameter = lowQuantityThreshold.HasValue ?
                new ObjectParameter("LowQuantityThreshold", lowQuantityThreshold) :
                new ObjectParameter("LowQuantityThreshold", typeof(decimal));
    
            var productStatusParameter = productStatus != null ?
                new ObjectParameter("ProductStatus", productStatus) :
                new ObjectParameter("ProductStatus", typeof(string));
    
            var statusIDParameter = statusID.HasValue ?
                new ObjectParameter("StatusID", statusID) :
                new ObjectParameter("StatusID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertProductAttributes", attributeValuesParameter, productPriceParameter, productQuantityParameter, productIdParameter, unitInStockParameter, unitWeightParameter, highQuantityThresholdParameter, lowQuantityThresholdParameter, productStatusParameter, statusIDParameter);
        }
    
        public virtual int SP_GetAllSortedProducts(Nullable<int> displayLength, Nullable<int> displayStart, string sortCol, string sortDir, string searchText, string supplierId)
        {
            var displayLengthParameter = displayLength.HasValue ?
                new ObjectParameter("DisplayLength", displayLength) :
                new ObjectParameter("DisplayLength", typeof(int));
    
            var displayStartParameter = displayStart.HasValue ?
                new ObjectParameter("DisplayStart", displayStart) :
                new ObjectParameter("DisplayStart", typeof(int));
    
            var sortColParameter = sortCol != null ?
                new ObjectParameter("SortCol", sortCol) :
                new ObjectParameter("SortCol", typeof(string));
    
            var sortDirParameter = sortDir != null ?
                new ObjectParameter("SortDir", sortDir) :
                new ObjectParameter("SortDir", typeof(string));
    
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var supplierIdParameter = supplierId != null ?
                new ObjectParameter("SupplierId", supplierId) :
                new ObjectParameter("SupplierId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_GetAllSortedProducts", displayLengthParameter, displayStartParameter, sortColParameter, sortDirParameter, searchTextParameter, supplierIdParameter);
        }
    
        public virtual int SP_GetAllSortedProductsFrontFace(Nullable<int> displayLength, Nullable<int> displayStart, string sortCol, string sortDir, string searchText, string filterText, string categories, string lowPrice, string highPrice, string isFeatured)
        {
            var displayLengthParameter = displayLength.HasValue ?
                new ObjectParameter("DisplayLength", displayLength) :
                new ObjectParameter("DisplayLength", typeof(int));
    
            var displayStartParameter = displayStart.HasValue ?
                new ObjectParameter("DisplayStart", displayStart) :
                new ObjectParameter("DisplayStart", typeof(int));
    
            var sortColParameter = sortCol != null ?
                new ObjectParameter("SortCol", sortCol) :
                new ObjectParameter("SortCol", typeof(string));
    
            var sortDirParameter = sortDir != null ?
                new ObjectParameter("SortDir", sortDir) :
                new ObjectParameter("SortDir", typeof(string));
    
            var searchTextParameter = searchText != null ?
                new ObjectParameter("SearchText", searchText) :
                new ObjectParameter("SearchText", typeof(string));
    
            var filterTextParameter = filterText != null ?
                new ObjectParameter("FilterText", filterText) :
                new ObjectParameter("FilterText", typeof(string));
    
            var categoriesParameter = categories != null ?
                new ObjectParameter("Categories", categories) :
                new ObjectParameter("Categories", typeof(string));
    
            var lowPriceParameter = lowPrice != null ?
                new ObjectParameter("LowPrice", lowPrice) :
                new ObjectParameter("LowPrice", typeof(string));
    
            var highPriceParameter = highPrice != null ?
                new ObjectParameter("HighPrice", highPrice) :
                new ObjectParameter("HighPrice", typeof(string));
    
            var isFeaturedParameter = isFeatured != null ?
                new ObjectParameter("IsFeatured", isFeatured) :
                new ObjectParameter("IsFeatured", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_GetAllSortedProductsFrontFace", displayLengthParameter, displayStartParameter, sortColParameter, sortDirParameter, searchTextParameter, filterTextParameter, categoriesParameter, lowPriceParameter, highPriceParameter, isFeaturedParameter);
        }
    }
}
