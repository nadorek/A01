using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AProduct.Web.Entities;

public class Product
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string ImgUri { get; set; }
    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public string? Description { get; set; }
}