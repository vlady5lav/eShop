namespace Catalog.UnitTests.Services;

public class CatalogProductServiceTest
{
    private readonly ICatalogProductService _catalogService;

    private readonly Mock<ICatalogProductRepository> _catalogProductRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;

    private readonly CatalogProduct _testItem = new CatalogProduct()
    {
        Name = "Name",
        Price = 1000,
        AvailableStock = 100,
        CatalogBrandId = 1,
        CatalogTypeId = 1,
        Description = "Description",
        PictureFileName = "1.png",
    };

    public CatalogProductServiceTest()
    {
        _catalogProductRepository = new Mock<ICatalogProductRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();

        _dbContextWrapper.Setup(s => s.BeginTransaction()).Returns(dbContextTransaction.Object);

        _catalogService = new CatalogProductService(_dbContextWrapper.Object, _logger.Object, _catalogProductRepository.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        // arrange
        var testResult = 1;

        _catalogProductRepository.Setup(s => s.AddAsync(
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>()))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogService
            .CreateProductAsync(
            _testItem.Name,
            _testItem.Price,
            _testItem.AvailableStock,
            _testItem.CatalogBrandId,
            _testItem.CatalogTypeId,
            _testItem.Description,
            _testItem.PictureFileName);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogProductRepository.Setup(s => s.AddAsync(
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>()))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogService
            .CreateProductAsync(
            _testItem.Name,
            _testItem.Price,
            _testItem.AvailableStock,
            _testItem.CatalogBrandId,
            _testItem.CatalogTypeId,
            _testItem.Description,
            _testItem.PictureFileName);

        // assert
        result.Should().Be(testResult);
    }
}
