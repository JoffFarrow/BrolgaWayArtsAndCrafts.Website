using BrolgaWayArtsAndCrafts.Website.Models;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Services
{
	public class JsonFileProductsService
	{
		public JsonFileProductsService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}

		public IWebHostEnvironment WebHostEnvironment { get; }

		private string JsonFileName
		{
			get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
		}

		[return: MaybeNull]
		public IEnumerable<Product> GetProducts()
		{
			using (var jsonFileReader = File.OpenText(JsonFileName))
			{
				return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
					new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
			}
		}
	}
}