namespace WebAPI.Skilltree.vs17.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// 
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_Details = new HashSet<Order_Detail>();
        }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>
        /// The supplier identifier.
        /// </value>
        public int? SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int? CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the quantity per unit.
        /// </summary>
        /// <value>
        /// The quantity per unit.
        /// </value>
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the units in stock.
        /// </summary>
        /// <value>
        /// The units in stock.
        /// </value>
        public short? UnitsInStock { get; set; }

        /// <summary>
        /// Gets or sets the units on order.
        /// </summary>
        /// <value>
        /// The units on order.
        /// </value>
        public short? UnitsOnOrder { get; set; }

        /// <summary>
        /// Gets or sets the reorder level.
        /// </summary>
        /// <value>
        /// The reorder level.
        /// </value>
        public short? ReorderLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Product"/> is discontinued.
        /// </summary>
        /// <value>
        ///   <c>true</c> if discontinued; otherwise, <c>false</c>.
        /// </value>
        public bool Discontinued { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>
        /// The order details.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Details { get; set; }
    }
}
