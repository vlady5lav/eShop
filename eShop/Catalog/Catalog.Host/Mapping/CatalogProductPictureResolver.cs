using Catalog.Host.Configurations;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class CatalogProductPictureResolver : IMemberValueResolver<CatalogProduct, CatalogProductDto, string, object>
{
    private readonly CatalogConfig _config;

    public CatalogProductPictureResolver(IOptionsSnapshot<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public object Resolve(CatalogProduct source, CatalogProductDto destination, string sourceMember, object destMember, ResolutionContext context)
    {
        return $"{_config.Host}/{_config.ImgUrl}/{sourceMember}";
    }
}
