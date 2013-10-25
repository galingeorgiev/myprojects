using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class ShoppingCenter
{
	private static ShoppingCenterDBFast shoppingCenterDB = 
		new ShoppingCenterDBFast();

	private static StringBuilder output = new StringBuilder(1024 * 1024);

	static void Main()
	{
		System.Threading.Thread.CurrentThread.CurrentCulture =
			System.Globalization.CultureInfo.InvariantCulture;

		int n = int.Parse(Console.ReadLine());
		for (int i = 0; i < n; i++)
		{			
			string commandText = Console.ReadLine();
			ProcessCommand(commandText);
		}

		Console.WriteLine(output);
	}

	private static void ProcessCommand(string commandText)
	{
		int spaceIndex = commandText.IndexOf(' ');
		if (spaceIndex == -1)
		{
			throw new ArgumentException(
				"Invalid command: " + commandText);
		}
		string cmd = commandText.Substring(0, spaceIndex);
		string cmdArgumentsStr = commandText.Substring(spaceIndex + 1);
		string[] cmdArguments = cmdArgumentsStr.Split(';');
		for (int i = 0; i < cmdArguments.Length; i++)
		{
			cmdArguments[i] = cmdArguments[i].Trim();
		}
		ProcessCommand(cmd, cmdArguments);
	}

	private static void ProcessCommand(
		string cmdName, string[] cmdArguments)
	{
		switch (cmdName)
		{
			case "AddProduct":
				ProcessAddProduct(cmdArguments);
				break;
			case "DeleteProducts":
				ProcessDeleteProducts(cmdArguments);
				break;
			case "FindProductsByName":
				ProcessFindProductsByName(cmdArguments);
				break;
			case "FindProductsByPriceRange":
				ProcessFindProductsByPriceRange(cmdArguments);
				break;
			case "FindProductsByProducer":
				ProcessFindProductsByProducer(cmdArguments);
				break;
			default:
				throw new ArgumentException(
					"Invalid command: " + cmdName);
		}
	}

	private static void ProcessAddProduct(
		string[] cmdArguments)
	{
		string name = cmdArguments[0];
		float price = float.Parse(cmdArguments[1]);
		string producer = cmdArguments[2];
		Product product = new Product()
		{
			Name = name,
			Price = price,
			Producer = producer
		};
		shoppingCenterDB.AddProduct(product);
		Print("Product added");
	}
	
	private static void ProcessFindProductsByProducer(
		string[] cmdArguments)
	{
		string producer = cmdArguments[0];
		var products = shoppingCenterDB.FindProductsByProducer(producer);
		PrintProducts(products);
	}

	private static void ProcessFindProductsByPriceRange(
		string[] cmdArguments)
	{
		float fromPrice = float.Parse(cmdArguments[0]);
		float toPrice = float.Parse(cmdArguments[1]);
		var products = 
			shoppingCenterDB.FindProductsByPriceRange(fromPrice, toPrice);
		PrintProducts(products);
	}

	private static void ProcessFindProductsByName(
		string[] cmdArguments)
	{
		string name = cmdArguments[0];
		var products = shoppingCenterDB.FindProductsByName(name);
		PrintProducts(products);
	}
  
	private static void PrintProducts(IEnumerable<Product> products)
	{
		if (products.GetEnumerator().MoveNext())
		{
			foreach (var product in products)
			{
				Print(product.ToString());
			}
		}
		else
		{
			Print("No products found");
		}
	}

	private static void ProcessDeleteProducts(
		string[] cmdArguments)
	{
		int deletedCount;
		if (cmdArguments.Length == 1)
		{
			string producer = cmdArguments[0];
			deletedCount = shoppingCenterDB.DeleteProductsByProducer(
				producer);
		}
		else if (cmdArguments.Length == 2)
		{
			string name = cmdArguments[0];
			string producer = cmdArguments[1];
			deletedCount = shoppingCenterDB.
				DeleteProductsByNameAndProducer(name, producer);
		}
		else
		{
			throw new ArgumentException(
				"DeleteProducts command should have 1 or 2 arguments but " +
				cmdArguments.Length + "are given.");
		}

		if (deletedCount == 0)
		{
			Print("No products found");
		}
		else
		{
			Print("" + deletedCount + " products deleted");
		}
	}

	private static void Print(string text)
	{
		output.AppendLine(text);
	}
}

class Product : IComparable<Product>
{
	public string Name { get; set; }
	public float Price { get; set; }
	public string Producer { get; set; }

	public int CompareTo(Product other)
	{
		int compareResult = this.Name.CompareTo(other.Name);
		if (compareResult == 0)
		{
			compareResult = this.Producer.CompareTo(other.Producer);
		}
		if (compareResult == 0)
		{
			compareResult = this.Price.CompareTo(other.Price);
		}
		return compareResult;
	}

	public override string ToString()
	{
		string result = "{" + string.Format(
			"{0};{1};{2:f2}", 
			this.Name, this.Producer, this.Price) + "}";
		return result;
	}
}

class ShoppingCenterDBSlow
{
	private List<Product> products = new List<Product>();

	public void AddProduct(Product product)
	{
		this.products.Add(product);
	}

	public int DeleteProductsByProducer(string producer)
	{
		int deletedCount = products.RemoveAll(p => p.Producer == producer);
		return deletedCount;
	}

	public int DeleteProductsByNameAndProducer(
		string name, string producer)
	{
		int deletedCount = products.RemoveAll(
			p => p.Name == name && p.Producer == producer);
		return deletedCount;
	}

	public IEnumerable<Product> FindProductsByName(string name)
	{
		var resultProducts =
			from p in this.products
			where p.Name == name
			orderby p.ToString()
			select p;
		return resultProducts;
	}

	public IEnumerable<Product> FindProductsByPriceRange(
		float fromPrice, float toPrice)
	{
		var resultProducts =
			from p in this.products
			where p.Price >= fromPrice && p.Price <= toPrice
			orderby p.ToString()
			select p;
		return resultProducts;
	}

	public IEnumerable<Product> FindProductsByProducer(string producer)
	{
		var resultProducts =
			from p in this.products
			where p.Producer == producer
			orderby p.ToString()
			select p;
		return resultProducts;
	}
}

class ShoppingCenterDBFast
{
	private MultiDictionary<string, Product> productsByProducer =
		new MultiDictionary<string, Product>(true);

	private MultiDictionary<Pair<string, string>, Product> productsByNameAndProducer =
		new MultiDictionary<Pair<string, string>, Product>(true);

	private MultiDictionary<string, Product> productsByName =
		new MultiDictionary<string, Product>(true);

	private OrderedMultiDictionary<float, Product> productsByPrice =
		new OrderedMultiDictionary<float, Product>(true);

	public void AddProduct(Product product)
	{
		this.productsByProducer.Add(product.Producer, product);
		Pair<string, string> nameAndProducer = 
			new Pair<string, string>(product.Name, product.Producer);
		this.productsByNameAndProducer.Add(nameAndProducer, product);
		this.productsByName.Add(product.Name, product);
		this.productsByPrice.Add(product.Price, product);
	}

	public int DeleteProductsByProducer(string producer)
	{
		var productsToDelete =
			this.productsByProducer[producer];
		int deletedCount = productsToDelete.Count;
		RemoveProducts(productsToDelete);
		return deletedCount;
	}

	private void RemoveProducts(ICollection<Product> productsToDelete)
	{
		foreach (var p in productsToDelete.ToList())
		{
			RemoveProduct(p);
		}
	}

	private void RemoveProduct(Product product)
	{
		this.productsByProducer.Remove(product.Producer, product);
		Pair<string, string> nameAndProducer =
			new Pair<string, string>(product.Name, product.Producer);
		this.productsByNameAndProducer.Remove(nameAndProducer, product);
		this.productsByName.Remove(product.Name, product);
		this.productsByPrice.Remove(product.Price, product);
	}

	public int DeleteProductsByNameAndProducer(
		string name, string producer)
	{
		Pair<string, string> nameAndProducer =
			new Pair<string, string>(name, producer);
		var productsToDelete =
			this.productsByNameAndProducer[nameAndProducer];
		int deletedCount = productsToDelete.Count;
		RemoveProducts(productsToDelete);
		return deletedCount;
	}

	public IEnumerable<Product> FindProductsByName(string name)
	{
		var matchedProducts = this.productsByName[name].OrderBy(p => p);
		return matchedProducts;
	}

	public IEnumerable<Product> FindProductsByPriceRange(
		float fromPrice, float toPrice)
	{
		var matchedProducts = 
			this.productsByPrice.Range(fromPrice, true, toPrice, true).
			Values.OrderBy(p => p);
		return matchedProducts;
	}

	public IEnumerable<Product> FindProductsByProducer(string producer)
	{
		var matchedProducts = 
			this.productsByProducer[producer].OrderBy(p => p);		
		return matchedProducts;
	}
}
