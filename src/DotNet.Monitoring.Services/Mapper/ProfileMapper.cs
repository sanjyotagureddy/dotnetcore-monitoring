using AutoMapper;
using DotNet.Monitoring.Contracts.Entities;
using DotNet.Monitoring.Contracts.Services.Dtos;

namespace DotNet.Monitoring.Services.Mapper;

public class ProfileMapper : Profile
{
  public ProfileMapper()
  {
    CreateMap<ProductDto, Product>().ReverseMap();
  }
}