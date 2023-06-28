using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Todo.Shared;

[Table("Shopping")]
public partial class Shopping
{
    [Key]
    [Column("ShoppingItemID")]
    public Guid ShoppingItemId { get; set; }

    [StringLength(50)]
    public string ShoppingItem { get; set; } = null!;

    public int Quantity { get; set; }

    public bool Done { get; set; }

    public bool Deleted { get; set; }
}
