using System.ComponentModel.DataAnnotations;

namespace DotNet.Monitoring.Contracts.Services.Dtos;

public record ProductDto : BaseDto
{
  [Required]
  public string Name { get; set; } = string.Empty;
  public double Price { get; set; }
  public string? Description { get; set; }
  [MaxLength(30)]
  public string? ShortDescription { get; set; }
}