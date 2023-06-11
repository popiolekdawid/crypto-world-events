using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceReference1;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindMaxController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var allPrices = new double[] { };
            using (var dbContext = new MyDbContext())
            {
                var prices = dbContext.Prices.ToList();
                foreach (var price in prices)
                {
                    allPrices = allPrices.Append(double.Parse(price.price, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture)).ToArray();
                }

                MyFirstSOAPInterfaceClient client = new MyFirstSOAPInterfaceClient();
                int?[] nullableDoubleArray = Array.ConvertAll(allPrices, price => (int?)price);
                var response = await client.getAverageAsync(allPrices[allPrices.Length-1], allPrices[allPrices.Length-2], allPrices[allPrices.Length - 3], allPrices[allPrices.Length - 4], allPrices[allPrices.Length - 5], allPrices[allPrices.Length - 6], allPrices[allPrices.Length - 7]);
                Console.WriteLine(response);
                return response.ToString();
            }
        }
    }
}
