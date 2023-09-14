using System.ComponentModel.DataAnnotations;

namespace SS20Restaurant.Models;

public class Customer
{
	[Key]
	public Guid CustomerId { get; set; }
	[Required,MaxLength(50)]
	public string? Name { get; set; }
	[MaxLength(15),Phone]
	public string? Phone { get; set; }
	[MaxLength(50),EmailAddress]
	public string? Email { get; set; }
	[MaxLength(500)]
	[DataType(DataType.MultilineText)]
	public string? Address { get; set; }
}

