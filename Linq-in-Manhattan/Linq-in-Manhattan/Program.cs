using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Linq_in_Manhattan
{

	internal class Program
	{
		static void Main(string[] args)
		{
			string JsonFilePath = "../../../data.json";
			string JsonDataString = File.ReadAllText(JsonFilePath);
		    
			Root root= new Root();
			var JsonObj=JsonConvert.DeserializeObject<Root>(JsonDataString);
			// find neighborhoods
			var neighborhoods = JsonObj.features.Where(item=> item.properties.neighborhood != null);
			int countNeighborhoods = 0;
			  foreach(var neighborhood in neighborhoods) {
				countNeighborhoods++;	

			}
			  Console.WriteLine($"1.we have {countNeighborhoods} neighborhoods");

			// find  neighborhoods that do not have any names
			var neighborhoodsNoName = JsonObj.features.Where(item => item.properties.neighborhood != null && item.properties.neighborhood !="");
			int countneighborhoodsNoName = 0;
			foreach (var neighborhood in neighborhoodsNoName)

			{
				countneighborhoodsNoName++;

			}
			Console.WriteLine($"2.we have {countneighborhoodsNoName} neighborhoods with Names");

			// Remove the duplicates

			var neighborhoodsWithoutDuplicate = JsonObj.features.Where(item => item.properties.neighborhood != "").Select(item => item.properties.neighborhood).Distinct();
			int countneighborhoodsWithoutDuplicate = 0;
			foreach (var neighborhood in neighborhoodsWithoutDuplicate)

			{
				countneighborhoodsWithoutDuplicate++;

			}
			Console.WriteLine($"3.we have {countneighborhoodsWithoutDuplicate} neighborhoods without duplicates");

			//Rewrite the queries from above and consolidate all into one single query.

			// Rewrite at least one of these questions only using the opposing method (example: Use LINQ Query statements instead of LINQ method calls and vice versa.)

			Console.WriteLine();
			Console.WriteLine("***Output all of the neighborhoods in this data list using LINQ Query statements");
			var ListOfneighborhoods=from feature
									in JsonObj.features
									where feature.properties.neighborhood != null
									select feature;

			int countListOfneighborhoods = 0;
			foreach (var neighborhood in neighborhoods)
			{
				countListOfneighborhoods++;

			}

			Console.WriteLine($"5.we have {countListOfneighborhoods} neighborhoods");
		}
	}
	
	

	

	

	
}