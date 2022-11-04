﻿namespace DotNet.Monitoring.Contracts.Services.Dtos;

public record BaseDto
{
  public int Id { get; set; }
  public DateTime CreatedDate { get; set; }
  public string? CreatedBy { get; set; }
  public string? LastModifiedBy { get; set; }
  public DateTime? LastModified { get; set; }
}