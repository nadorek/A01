using System.ComponentModel.DataAnnotations;

namespace AProduct.Web.Dtos;

public class ProductCreateDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string ImgUri { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string? Description { get; set; }
}