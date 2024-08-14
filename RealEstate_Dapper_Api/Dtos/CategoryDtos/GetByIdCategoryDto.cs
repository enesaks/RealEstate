using System;

namespace RealEstate_Dapper_Api.Dtos.CategoryDtos;

public class GetByIdCategoryDto
{
    public int CategoryId { get; set; }
    public  string Name { get; set; }
    public bool Status { get; set; }
}
