using SS20Restaurant.Models;

namespace SS20Restaurant.Repository;

public interface ISaleService
{
    Task<List<Sale>> GetSale();
    Task<Sale?> GetSale(Guid Id);
    Task<bool> Save(Sale sale);
    Task<bool> Delete(Guid Id);
    Task<bool> Update(Guid Id, Sale sale);
}

