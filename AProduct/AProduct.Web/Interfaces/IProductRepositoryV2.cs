using AProduct.Web.Entities;

namespace AProduct.Web.Interfaces;

public interface IProductRepositoryV2 
{
    Task<List<Product>> GetProductsPage(int pageSize, int pageNumber);
}