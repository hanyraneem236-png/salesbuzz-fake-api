using SalesBuzz.API.Models;
using SalesBuzz.API.DTOs;

namespace SalesBuzz.API.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();   
        Task<Product?> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);
    }

     public interface IProductService
    {
       IQueryable<ProductDto> GetAll();

        Task<ProductDto?> GetByIdAsync(int id);

        Task<ProductDto> CreateAsync(CreateProductDto dto);

        Task<bool> UpdateAsync(int id, UpdateProductDto dto);

        Task<bool> DeleteAsync(int id);

        Task<bool> PatchAsync(int id, PatchProductDto dto);
    }
}

