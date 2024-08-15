using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
     private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

   
    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        string query = "SELECT * FROM Product";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
    {
        string query = "SELECT ProductId,Title,Price,City,District,Name AS CategoryName From Product inner join Category on Product.ProductCategory=Category.CategoryId";
  
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }
    }
}