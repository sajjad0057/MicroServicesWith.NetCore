using Refit;
using Sajshop.web.Models.Catalog;

namespace Sajshop.web.Services;

/// <summary>
/// For mapping request with refit must be set same request parameter name with endpoint parameter name.
/// Otherwise refit cann't mapped automatically
/// </summary>
public interface ICatalogService
{
    [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);

    [Get("/catalog-service/products/{id}")]
    Task<GetProductByIdResponse> GetProduct(Guid id);

    [Get("/catalog-service/products/category/{category}")]
    Task<GetProductByCategoryResponse> GetProductsByCategory(string category);
}