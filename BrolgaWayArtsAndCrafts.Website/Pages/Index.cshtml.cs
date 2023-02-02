using BrolgaWayArtsAndCrafts.Website.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrolgaWayArtsAndCrafts.Website.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public JsonFileProductsService ProductService;
		public IEnumerable<Product> Products { get; private set; }

		public IndexModel(ILogger<IndexModel> logger,
			JsonFileProductsService productService)
		{
			_logger = logger;
			ProductService = productService;
		}

		public void OnGet()
		{
			Products = ProductService.GetProducts();
		}
	}
}