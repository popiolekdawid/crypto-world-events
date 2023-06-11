using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using System.Xml;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> Get()
        {
            string xmlpath = System.IO.Path.Combine("/xampp/htdocs/Projekt/WebApplication1/WebApplication1/Assets", "Ethereum-prices.xml");

            // odczyt danych z wykorzystaniem DOM
            Console.WriteLine("XML loaded by DOM Approach");
            var result = XMLReadWithDOMApproach.Read(xmlpath);
            string connectionString = "Server=localhost;Database=ethereum;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                IsolationLevel isolationLevel = IsolationLevel.Serializable; 
                using (MySqlTransaction transaction = connection.BeginTransaction(isolationLevel))
                {
                    try
                    {
                        using (var dbContext = new MyDbContext())
                        {

                            dbContext.Prices.ExecuteDelete();
                            for (int i = 0; i < result.GetLength(0); i++)
                            {
                                var myTable = new Price
                                {
                                    date = result[i, 0],
                                    price = result[i, 1]
                                };


                                dbContext.Prices.Add(myTable);
                            }
                            dbContext.SaveChanges();
                        }
                        transaction.Commit();
                        Console.WriteLine("Transaction successfull.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction rolled back");
                    }
                }
            }
           
            string[][] jaggedArray = ConvertToJaggedArray(result);
            string xml = SerializeToXml(jaggedArray);
            System.IO.File.WriteAllText("/xampp/htdocs/Projekt/WebApplication1/WebApplication1/Assets/output.xml", xml);
            Console.WriteLine("XML exported successfully.");

            return 202;
        }
        private static string SerializeToXml(string[][] data)
        {
            var xmlDoc = new XmlDocument();

            var rootElement = xmlDoc.CreateElement("root");
            xmlDoc.AppendChild(rootElement);

            foreach (var row in data)
            {
                var dataElement = xmlDoc.CreateElement("data");
                rootElement.AppendChild(dataElement);

                var dateElement = xmlDoc.CreateElement("date");
                dateElement.InnerText = row[0];
                dataElement.AppendChild(dateElement);

                var priceElement = xmlDoc.CreateElement("price");
                priceElement.InnerText = row[1];
                dataElement.AppendChild(priceElement);
            }

            using (var writer = new StringWriter())
            {
                xmlDoc.Save(writer);
                return writer.ToString();
            }
        }
        private static string[][] ConvertToJaggedArray(string[,] data)
        {
            int rows = data.GetLength(0);
            int columns = data.GetLength(1);

            string[][] jaggedArray = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new string[columns];

                for (int j = 0; j < columns; j++)
                {
                    jaggedArray[i][j] = data[i, j];
                }
            }

            return jaggedArray;
        }
    }
}
