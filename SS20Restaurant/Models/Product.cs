using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS20Restaurant.Models;

public class Product
{
	[Key]
	public Guid ProductId { get; set; }
	[Required]
	[MaxLength(50)]
	[Display(Name ="Product Name")]
	public string? ProductName { get; set; }
	public double Price { get; set; }
	public int QtyOnhand { get; set; }
	public int ReOrderQty { get; set; }
	public bool IsProduct { get; set; }
	[ForeignKey("Category")]
	public Guid CategoryId { get; set; }
	public Category? Category { get; set; }
}

