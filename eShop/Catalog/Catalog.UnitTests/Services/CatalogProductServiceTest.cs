namespace Catalog.UnitTests.Services;

public class CatalogProductServiceTest
{
    private readonly ICatalogProductService _catalogProductService;

    private readonly Mock<ICatalogProductRepository> _catalogProductRepository;
    private readonly Mock<IDbContextTransaction> _dbContextTransaction;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogProductService>> _logger;

    private readonly CatalogProduct _testItem;

    public CatalogProductServiceTest()
    {
        _catalogProductRepository = new Mock<ICatalogProductRepository>();
        _dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogProductService>>();

        _testItem = new CatalogProduct()
        {
            Id = 1,
            Name = "Name",
            Price = 1000,
            AvailableStock = 100,
            CatalogBrandId = 1,
            CatalogTypeId = 1,
            Description = "Description",
            PictureFileName = "1.png",
        };

        _dbContextWrapper.Setup(s => s.BeginTransaction()).Returns(_dbContextTransaction.Object);

        _catalogProductService = new CatalogProductService(_dbContextWrapper.Object, _logger.Object, _catalogProductRepository.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        // arrange
        _catalogProductRepository.Setup(
            s => s.AddAsync(
            It.Is<string>(i => i == _testItem.Name),
            It.Is<decimal>(i => i == _testItem.Price),
            It.Is<int>(i => i == _testItem.AvailableStock),
            It.Is<int>(i => i == _testItem.CatalogBrandId),
            It.Is<int>(i => i == _testItem.CatalogTypeId),
            It.Is<string>(i => i == _testItem.Description),
            It.Is<string>(i => i == _testItem.PictureFileName)))
            .ReturnsAsync(_testItem.Id);

        // act
        var result = await _catalogProductService.AddAsync(
            _testItem.Name,
            _testItem.Price,
            _testItem.AvailableStock,
            _testItem.CatalogBrandId,
            _testItem.CatalogTypeId,
            _testItem.Description,
            _testItem.PictureFileName);

        // assert
        result.Should().Be(_testItem.Id);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogProductRepository.Setup(
            s => s.AddAsync(
            It.Is<string>(i => i == _testItem.Name),
            It.Is<decimal>(i => i == _testItem.Price),
            It.Is<int>(i => i == _testItem.AvailableStock),
            It.Is<int>(i => i == _testItem.CatalogBrandId),
            It.Is<int>(i => i == _testItem.CatalogTypeId),
            It.Is<string>(i => i == _testItem.Description),
            It.Is<string>(i => i == _testItem.PictureFileName)))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogProductService.AddAsync(
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
    public async Task DeleteAsync_Success()
    {
        // arrange
        _catalogProductRepository.Setup(
            s => s.DeleteAsync(
            It.Is<int>(i => i == _testItem.Id)))
            .ReturnsAsync(_testItem.Id);

        // act
        var result = await _catalogProductService.DeleteAsync(_testItem.Id);

        // assert
        result.Should().Be(_testItem.Id);
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogProductRepository.Setup(
            s => s.DeleteAsync(
            It.Is<int>(i => i == _testItem.Id)))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogProductService.DeleteAsync(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        // arrange
        _catalogProductRepository.Setup(
            s => s.UpdateAsync(
            It.Is<int>(i => i == _testItem.Id),
            It.Is<string>(i => i == _testItem.Name),
            It.Is<decimal>(i => i == _testItem.Price),
            It.Is<int>(i => i == _testItem.AvailableStock),
            It.Is<int>(i => i == _testItem.CatalogBrandId),
            It.Is<int>(i => i == _testItem.CatalogTypeId),
            It.Is<string>(i => i == _testItem.Description),
            It.Is<string>(i => i == _testItem.PictureFileName)))
            .ReturnsAsync(_testItem.Id);

        // act
        var result = await _catalogProductService.UpdateAsync(
            _testItem.Id,
            _testItem.Name,
            _testItem.Price,
            _testItem.AvailableStock,
            _testItem.CatalogBrandId,
            _testItem.CatalogTypeId,
            _testItem.Description,
            _testItem.PictureFileName);

        // assert
        result.Should().Be(_testItem.Id);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogProductRepository.Setup(
            s => s.UpdateAsync(
            It.Is<int>(i => i == _testItem.Id),
            It.Is<string>(i => i == _testItem.Name),
            It.Is<decimal>(i => i == _testItem.Price),
            It.Is<int>(i => i == _testItem.AvailableStock),
            It.Is<int>(i => i == _testItem.CatalogBrandId),
            It.Is<int>(i => i == _testItem.CatalogTypeId),
            It.Is<string>(i => i == _testItem.Description),
            It.Is<string>(i => i == _testItem.PictureFileName)))
            .ReturnsAsync(testResult);

        // act
        var result = await _catalogProductService.UpdateAsync(
            _testItem.Id,
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
