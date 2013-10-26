using System;
using UsingEntityFrameworkModel;
using System.IO;
using EFTracingProvider;

class SolvingTheNplus1QueryProblem
{
	static void Main()
	{
		// Attach tracing to log all SQL commands into a text file
		EFTracingProviderConfiguration.RegisterProvider();
		NorthwindEntitiesWithSQLTracing northwindEntities = new NorthwindEntitiesWithSQLTracing();
		northwindEntities.Log = File.CreateText("Northwind-SQL-commands.log");

		// Perform queries
		using (northwindEntities.Log)
		{
			PrintCustomersAndRegionsWithQueryProblem(northwindEntities);
			PrintCustomersAndRegionsWithoutQueryProblem(northwindEntities);
		}
	}

	static void PrintCustomersAndRegionsWithQueryProblem(NorthwindEntities context)
    {
		foreach (var customer in context.Customers)
        {
			Console.Write("{0}'s orders:", customer.CompanyName);
			foreach (var order in customer.Orders)
			{
				Console.Write(" {0}", order.OrderID);
			}
			Console.WriteLine();
        }
    }

	static void PrintCustomersAndRegionsWithoutQueryProblem(NorthwindEntities context)
    {
		foreach (var customer in context.Customers.Include("Orders"))
		{
			Console.Write("{0}'s orders:", customer.CompanyName);
			foreach (var order in customer.Orders)
			{
				Console.Write(" {0}", order.OrderID);
			}
			Console.WriteLine();
		}
    }
}
