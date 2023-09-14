using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS20Restaurant.Models;

public class Sale
{
	[Key]
	public Guid SaleId { get; set; }
	[ForeignKey("Customer")]
	public Guid CustomerId { get; set; }
	[DataType(DataType.Date)]
	public DateTime IssueDate { get; set; }
	[MaxLength(20)]
	[Display(Name ="Invoice Number")]
	public string? InvoiceNumber { get; set; }
	[MaxLength(500)]
	[DataType(DataType.MultilineText)]
	public string? Noted { get; set; }
	public double Total { get; set; }
	public int Discount { get; set; }
	public double GrandTotal { get; set; }
	public int VAT { get; set; }
	public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
	public Customer? Customer { get; set; }
}

