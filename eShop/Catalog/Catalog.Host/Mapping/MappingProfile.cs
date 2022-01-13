using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogProduct, CatalogProductDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogProductPictureResolver, string>(cp => cp.PictureFileName ?? string.Empty));
        CreateMap<CatalogBrand, CatalogBrandDto>();
        CreateMap<CatalogType, CatalogTypeDto>();
    }
}
