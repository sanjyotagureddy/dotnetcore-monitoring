﻿using DotNet.Monitoring.Contracts.Entities.Base;

namespace DotNet.Monitoring.Contracts.Entities;

public class Product : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public double Price { get; set; }
  public string? Description { get; set; }
  public string? ShortDescription { get; set; }
}