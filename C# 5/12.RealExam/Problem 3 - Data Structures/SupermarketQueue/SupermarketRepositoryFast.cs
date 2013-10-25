using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class SupermarketRepositoryFast : ISupermarketRepository
{
    BigList<string> repository = new BigList<string>();
    Bag<string> names = new Bag<string>();

    public void Append(string name)
    {
        this.repository.Add(name);
        this.names.Add(name);
    }

    public void Insert(int position, string name)
    {
        this.repository.Insert(position, name);
        this.names.Add(name);
    }

    public int Find(string name)
    {
        int occurences = this.names.NumberOfCopies(name);
        return occurences;
    }

    public IList<string> Serve(int count)
    {
        var servedNames = this.repository.Range(0, count).ToList();
        this.repository.RemoveRange(0, count);
        this.names.RemoveMany(servedNames);
        return servedNames;
    }
}
