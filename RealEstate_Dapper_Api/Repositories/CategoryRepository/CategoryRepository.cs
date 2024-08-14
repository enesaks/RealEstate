using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository
{
    private readonly Context _context;

    public CategoryRepository(Context context)
    {
        _context = context;
    }

    public async void CreateCategory(CreateCategoryDto createCategoryDto)
    {
        string query = "insert into Category (Name,Status) values (@name,@status)";
        var parameters = new DynamicParameters();
        parameters.Add("name",createCategoryDto.Name);
        parameters.Add("status",true);
        using(var connection = _context.CreateConnection()){
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteCategory(int id)
    {
        string query = "Delete From Category Where CategoryId=@categoryId";
        var parameters =new DynamicParameters();
        parameters.Add("@categoryId",id);
        using(var connection = _context.CreateConnection()){
            await connection.ExecuteAsync(query,parameters);
        }
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        string query = "SELECT * FROM Category";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIdCategoryDto> GetCategory(int id)
    {
        string query = "Select * From Category Where CategoryId=@id";
        var parameters = new DynamicParameters();
        parameters.Add("@id",id);
        using (var connection = _context.CreateConnection()){
            var values = await connection.QueryFirstAsync<GetByIdCategoryDto>(query,parameters);
            return values;
        }
    }

    public async void UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        string query = "Update Category Set Name=@name,Status=@status where CategoryId=@categoryId";
        var parameters = new DynamicParameters();
        parameters.Add("@name",updateCategoryDto.Name);
        parameters.Add("@status",updateCategoryDto.Status);
        parameters.Add("@categoryId",updateCategoryDto.CategoryId);
        using(var connection = _context.CreateConnection()){
            var values = await connection.ExecuteAsync(query,parameters);
        }
    }
}
