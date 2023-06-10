using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptocurrenciesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Top20.json");
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);

            var deserializer = new DeserializerBuilder()
        .WithNamingConvention(UnderscoredNamingConvention.Instance)
        .Build();
            var deserializedObject = deserializer.Deserialize<object>(jsonContent);

            // Serialize to YAML
            var serializer = new SerializerBuilder()
                .Build();
            var yaml = serializer.Serialize(deserializedObject);

            string yamlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "output.yaml");
            System.IO.File.WriteAllText(yamlFilePath, yaml);

            // Return the YAML content as the response
            return Content(jsonContent, "application/json");
        }
    }
}
