namespace Catalog.UnitTests.Services;

public class CatalogServiceTest
{
    private readonly ICatalogService _catalogService;

    private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
    private readonly Mock<ICatalogProductRepository> _catalogProductRepository;
    private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;
    private readonly Mock<IMapper> _mapper;

    public CatalogServiceTest()
    {
        _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
        _catalogProductRepository = new Mock<ICatalogProductRepository>();
        _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();
        _mapper = new Mock<IMapper>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransaction()).Returns(dbContextTransaction.Object);

        _catalogService = new CatalogService(
            _dbContextWrapper.Object,
            _logger.Object,
            _mapper.Object,
            _catalogBrandRepository.Object,
            _catalogProductRepository.Object,
            _catalogTypeRepository.Object);
    }

    [Fact]
    public async Task GetProductsByPageAsync_Success()
    {
        // arrange
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 12;

        var pagingPaginatedItemsSuccess = new PaginatedItems<CatalogProduct>()
        {
            Data = new List<CatalogProduct>()
            {
                new CatalogProduct()
                {
                    Name = "TestName",
                },
            },
            TotalCount = testTotalCount,
        };

        var catalogProductSuccess = new CatalogProduct()
        {
            Name = "TestName",
        };

        var catalogProductDtoSuccess = new CatalogProductDto()
        {
            Name = "TestName",
        };

        _catalogProductRepository.Setup(s => s.GetByPageAsync(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize)))
            .ReturnsAsync(pagingPaginatedItemsSuccess);

        _mapper.Setup(s => s.Map<CatalogProductDto>(
            It.Is<CatalogProduct>(i => i.Equals(catalogProductSuccess)))).Returns(catalogProductDtoSuccess);

        // act
        var result = await _catalogService.GetProductsByPageAsync(testPageSize, testPageIndex);

        // assert
        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetProductsByPageAsync_Failed()
    {
        // arrange
        var testPageIndex = 1000;
        var testPageSize = 10000;

        _catalogProductRepository.Setup(s => s.GetByPageAsync(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize)))
            .Returns((Func<PaginatedItemsResponse<CatalogProductDto>>)null!);

        // act
        var result = await _catalogService.GetProductsByPageAsync(testPageSize, testPageIndex);

        // assert
        result.Should().BeNull();
    }
}
