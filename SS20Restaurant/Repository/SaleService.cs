using System;
using Microsoft.EntityFrameworkCore;
using SS20Restaurant.Data;
using SS20Restaurant.Models;

namespace SS20Restaurant.Repository
{
	public class SaleService:ISaleService,IDisposable
	{
        private readonly AppDbContext _context;
		public SaleService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var sale = await _context.Sale.FindAsync(Id);
                if (sale is null) return false;
                _context.Sale.Remove(sale);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<List<Sale>> GetSale()
            =>await  _context.Sale.ToListAsync();

        public async Task<Sale?> GetSale(Guid Id)
            => await _context.Sale.FindAsync(Id);

        public async Task<bool> Save(Sale sale)
        {
            try
            {
                sale.SaleId = Guid.NewGuid();
                sale.InvoiceNumber = GenerateInvoiceNumber();
                _context.Sale.Add(sale);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private string GenerateInvoiceNumber()
            => DateTime.Now.ToString("yyMMddHHmmsstt");
        public async Task<bool> Update(Guid Id, Sale sale)
        {
            try
            {
                var s = await _context.Sale.FindAsync(Id);
                if (s is null) return false;
                _context.Sale.Attach(s);
                s.CustomerId = sale.CustomerId;
                s.Discount = sale.Discount;
                s.GrandTotal = sale.GrandTotal;
                s.IssueDate = sale.IssueDate;
                s.Noted = sale.Noted;
                s.Total = sale.Total;
                s.VAT = sale.VAT;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

