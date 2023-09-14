using System.ComponentModel.DataAnnotations;

namespace SS20Restaurant.Models;

public class Category
{
	[Key]
	public Guid CategoryId { get; set; }
	[Required]
	[MaxLength(50)]
	public string? CategoryName { get; set; }
}

